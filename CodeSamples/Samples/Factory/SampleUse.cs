using CodeSamples.Samples.DI;
using UnityEngine;

namespace CodeSamples.Samples.Factory
{
    public class SampleUse : MonoBehaviour
    {

        //의존성 주입으로 팩토리를 찾아오기
        [Inject] private IFactory<SampleObject> _factory;

        /// <summary>
        /// 인스턴스를 생성해야할 부분
        /// </summary>
        public void AnyUse()
        {
            //팩토리로 인스턴스를 생성
            var obj = _factory.CreateInstance();
        }

    }
}
