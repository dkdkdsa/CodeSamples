using CodeSamples.Samples.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace CodeSamples.Samples.DI
{

    /// <summary>
    /// MonoBehaviour에 의존성을 주입해주는 클래스
    /// </summary>
    [DefaultExecutionOrder(-100)]
    public abstract class MonoInstallerBase : MonoBehaviour
    {

        /// <summary>
        /// 바인딩된 인스턴스들을 저장하는 저장수
        /// </summary>
        private DIContainer _container;

        private void Awake()
        {
            //저장소를 새로 생성
            _container = new();

            //커스텀 바인딩 함수를 호출하여 타입을 바인딩함
            InstallBinding(_container);

            //바인딩된 인스턴스들을 기반으로 의존성을 주입
            Install();
        }

        /// <summary>
        /// 의존성 주입을 위한 인스턴스를 바인딩 하는 함수
        /// </summary>
        /// <param name="container">바인딩 컨테이너</param>
        protected abstract void InstallBinding(DIContainer container);

        /// <summary>
        /// 의존성을 주입
        /// </summary>
        private protected virtual void Install()
        {

            //방문할 GameObject들을 저장
            Stack<GameObject> objs = new Stack<GameObject>();

            //자신의 오브젝트를 Push(자신의 오브젝트가 시작)
            objs.Push(gameObject);

            //Stack에 요소가 있는 동안 탐색을 진행
            while(objs.Count > 0)
            {

                //Pop으로 오브젝트 빼기
                var obj = objs.Pop();

                //자식에 다른 MonoInstaller가 있다면 관여하지 않도록
                if (obj != gameObject && obj.TryGetComponent<MonoInstallerBase>(out var _))
                    continue;

                //모든 컴포넌트 불러오기
                var compos = GetComponents<Component>();

                //모든 컴포넌트를 순회하며 의존성을 주입
                foreach (var compo in compos)
                {

                    //의존성 주입이 가능한지 채크
                    if (!CheckInstalling(compo))
                        continue;

                    //필드에 의존성을 주입
                    SetFields(compo);

                    //함수에 의존성을 주입
                    SetMethods(compo);

                    //프로퍼티에 의존성을 주입
                    SetPropertys(compo);
                }

                //오브젝트에 자식을 전부 찾아온 후
                var childs = obj.GetChilds();

                //Stack에 Push하여 전부 방문할 수 있게 함
                foreach (var o in childs)
                    objs.Push(o.gameObject);

            }
        }

        /// <summary>
        /// 컴포넌트가 의존성 주입이 가능한지 채크
        /// </summary>
        /// <param name="compo">컴포넌트</param>
        /// <returns>의존성 주입 가능 여부</returns>
        private bool CheckInstalling(Component compo)
        {

            //자신의 오브젝트에서 특정 오브젝트를 타겟으로 하는 Installer들을 찾아옴
            var installers = GetComponents<ITargetInstaller>();

            foreach (var installer in installers)
            {
                //Installer를 순회하며 이 컴포넌트를 타겟으로하는 Intaller가 있는지 검사
                if(installer.GetGenericType() == compo.GetType())
                {
                    //있다면 이 컴포넌트에서는 의존성주입이 불가
                    return false;
                }
            }

            //아니라면 가능
            return true;

        }

        /// <summary>
        /// 프로퍼티에 의존성을 주입하는 함수
        /// </summary>
        /// <param name="compo">주입할 컴포넌트</param>
        private protected void SetPropertys(Component compo)
        {

            //컴포넌트에 타입을 가져옴
            var type = compo.GetType();

            //중복된 프로퍼티(EX. 부모의 public 프로퍼티 등)에 주입을 막기위한 HashSet
            HashSet<PropertyInfo> check = new();

            //타입이 null이 아닌 경우까지 반복(부모 클래스가 Object면 null)
            while (type != null)
            {

                var propertys = type
                    //타입의 모든 프로퍼티를 찾아오기
                    .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    //그중 Inject어트리뷰트가 있는 것들을 필터링
                    .Where(x => x.GetCustomAttribute<Inject>() != null);

                foreach (var property in propertys)
                {
                    //이미 주입한 프로퍼티라면 주입을 하지 못하도록
                    if (check.Contains(property))
                        continue;

                    //프로퍼티에 의존성을 주입
                    property.SetValue(compo, FindInstnace(property.PropertyType));

                    //방문 표시
                    check.Add(property);
                }

                //자신의 부모 타입으로 올라가며 검사
                type = type.BaseType;

            }

        }

        /// <summary>
        /// 함수에 의존성을 주입
        /// </summary>
        /// <param name="compo">컴포넌트</param>
        private protected void SetMethods(Component compo)
        {

            //컴포넌트에 타입을 가져옴
            var type = compo.GetType();

            //중복된 함수(EX. 부모의 public 함수 등)에 주입을 막기위한 HashSet
            HashSet<MethodInfo> check = new();

            //타입이 null이 아닌 경우까지 반복(부모 클래스가 Object면 null)
            while (type != null)
            {
                var methods = type
                    //타입의 모든 함수를 찾아오기
                    .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    //그중 Inject어트리뷰트가 있는 것들을 필터링
                    .Where(x => x.GetCustomAttribute<Inject>() != null);

                foreach (var method in methods)
                {
                    //이미 주입한 함수라면 주입을 하지 못하도록
                    if (check.Contains(method))
                        continue;

                    //함수에 매계변수를 가져오기
                    var @params = method.GetParameters();

                    //매계변수를 담을 배열을 생성
                    object[] objs = new object[@params.Length];

                    for (int i = 0; i < @params.Length; i++)
                        //매계변수를 찾아 할당
                        objs[i] = FindInstnace(@params[i].ParameterType);

                    //의존성을 주입
                    method.Invoke(compo, objs);

                    //방문 표시
                    check.Add(method);
                }

                //자신의 부모 타입으로 올라가며 검사
                type = type.BaseType;

            }
        }

        /// <summary>
        /// 필드에 의존성을 주입
        /// </summary>
        /// <param name="compo">컴포넌트</param>
        private protected void SetFields(Component compo)
        {

            //컴포넌트에 타입을 받아오기
            var type = compo.GetType();

            //중복된 필드(EX. 부모의 public 필드 등)에 주입을 막기위한 HashSet
            HashSet<FieldInfo> check = new();

            //타입이 null이 아닌 경우까지 반복(부모 클래스가 Object면 null)
            while (type != null)
            {

                var fields = type
                    //타입의 모든 필드를 찾아오기
                    .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    //그중 Inject어트리뷰트가 있는 것들을 필터링
                    .Where(x => x.GetCustomAttribute<Inject>() != null);

                foreach (var field in fields)
                {

                    //이미 주입한 필드라면 주입을 하지 못하도록
                    if (check.Contains(field))
                        continue;

                    //필드에 의존성을 주입
                    field.SetValue(compo, FindInstnace(field.FieldType));

                    //방문 표시
                    check.Add(field);
                }

                //자신의 부모 타입으로 올라가며 검사
                type = type.BaseType;

            }
 
        }

        /// <summary>
        /// 인스턴스를 찾기
        /// </summary>
        /// <param name="t">찾을 타입</param>
        /// <returns></returns>
        private object FindInstnace(Type t)
        {

            //Container에서 가져오기 시도
            var o = _container.Get(t);

            //Container에서 가져오지 못했다면?
            if(o == null)
                //컴포넌트에서 가져오기
                o = GetComponent(t);

            //찾은 인스턴스 반환
            return o;
        }

    }
}