using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSamples.Samples.Factory
{
    public static class Factorys
    {

        private readonly static Dictionary<Type, IFactoryable> _factoryContainer = new();

        /// <summary>
        /// 팩토리를 바인딩하는 함수
        /// </summary>
        [RuntimeInitializeOnLoadMethod]
        public static void Bind()
        {
            _factoryContainer.Add(typeof(SampleObject), new SampleFactory());
        }

        /// <summary>
        /// 팩토리를 가져오는 함수
        /// </summary>
        /// <typeparam name="T">팩토리가 생성하는 오브젝트의 타입</typeparam>
        /// <returns>찾은 팩토리</returns>
        public static IFactory<T> GetFactroy<T>()
        {

            //해당하는 타입의 팩토리를 찾아 반환
            _factoryContainer.TryGetValue(typeof(T), out var factroy);

            //찾은 IFactoryable을 IFactory<T>형식으로 변환
            return factroy as IFactory<T>;

        }

    }
}