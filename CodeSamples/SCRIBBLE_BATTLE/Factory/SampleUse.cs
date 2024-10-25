using UnityEngine;

namespace CodeSamples.SCRIBBLE_BATTLE.Factory
{

    /// <summary>
    /// 팩토리를 사용하는 샘플 클래스
    /// </summary>
    public class SampleUse : MonoBehaviour
    {

        private IFactory<object> _factory;

        private void Awake()
        {
            //여기에서는 Factory를 통하여 팩토리를 가져오는 로직이 있어야 합니다
            _factory = Factory.GetFactory<object>();
        }

        public void Use()
        {
            //가져온 팩토리로 지지고 볶고 하면 됩니다
            var sample = _factory.CreateInstance();
        }

    }

}
