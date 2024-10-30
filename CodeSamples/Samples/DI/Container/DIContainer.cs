using System;
using System.Collections.Generic;

namespace CodeSamples.Samples.DI
{

    /// <summary>
    /// 바인딩 데이터를 가지고 있는 클래스
    /// </summary>
    public sealed class DIContainer
    {

        /// <summary>
        /// 바인딩 데이터를 저장하는 딕셔너리
        /// </summary>
        private readonly Dictionary<Type, IBindContainer> _bindContainer = new();

        /// <summary>
        /// 오브젝트를 바인딩
        /// </summary>
        /// <typeparam name="T">바인딩할 타입</typeparam>
        /// <param name="o">바인딩할 오브젝트</param>
        public void Bind<T>(T o)
        {
            Bind(typeof(T), o);
        }

        public void Bind(Type t, object o)
        {
            //인스턴스를 반환하는 컨테이너 클래스 생성 후 타입에 바인딩
            _bindContainer.Add(t, new InstanceContainer(o));
        }

        /// <summary>
        /// 오브젝트를 반환하는 함수를 바인딩
        /// </summary>
        /// <typeparam name="T">바인딩할 타입</typeparam>
        /// <param name="o">타겟 함수</param>
        public void Bind<T>(Func<object> o)
        {
            Bind(typeof(T), o);
        }

        /// <summary>
        /// 오브젝트를 반환하는 함수를 바인딩
        /// </summary>
        /// <param name="t">바인딩할 타입</param>
        /// <param name="o">오브젝트 생성 함수</param>
        public void Bind(Type t, Func<object> o) 
        {
            //함수를 실행하여 반환하는 컨테이너 생성 후 바인딩
            _bindContainer.Add(t, new FuncContainer(o));
        }

        /// <summary>
        /// 바인딩된 오브젝트를 가져옴
        /// </summary>
        /// <param name="type">오브젝트의 타입</param>
        /// <returns>오브젝트의 인스턴스</returns>
        internal object Get(Type type)
        {
            return _bindContainer.TryGetValue(type, out var o) ? o.GetInstance() : default;
        }
    }
}