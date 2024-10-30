using System;
using UnityEngine;

namespace CodeSamples.Samples.DI
{
    /// <summary>
    /// TargetInstaller의 기본 함수의 추상형 Interface
    /// </summary>
    internal interface ITargetInstaller
    {

        /// <summary>
        /// 타겟으로하는 타입 가져오기
        /// </summary>
        /// <returns>타입</returns>
        internal Type GetGenericType();

    }

    /// <summary>
    /// 특정 컴포넌트를 타겟으로 하는 Installer
    /// </summary>
    /// <typeparam name="T">타겟 컴포넌트 타입</typeparam>
    public abstract class TargetInstaller<T> : MonoInstallerBase, ITargetInstaller where T : Component
    {

        private protected override void Install()
        {

            //타겟으로하는 컴포넌트 가져오기
            var compo = GetComponent<T>();

            //필드에 의존성 주입
            SetFields(compo);

            //함수에 의존성 주입
            SetMethods(compo);
            
            //프로퍼티에 의존성 주입
            SetPropertys(compo);

        }

        Type ITargetInstaller.GetGenericType()
        {
            //타겟 타입 반환
            return typeof(T);
        }
    }
}
