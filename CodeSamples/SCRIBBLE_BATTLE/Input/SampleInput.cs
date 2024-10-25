using System;

namespace CodeSamples.SCRIBBLE_BATTLE.Input
{
    public class SampleInput : IInputContainer
    {
        private void Update()
        {
            //실제로 사용자 입력을 감지하여 이벤트를 발행하는 로직이 필요합니다
        }

        public void RegisterEvent(int key, Action<object> @event)
        {
            //이 부분에서는 사용자가 넘긴 event를 구독해주는 구현이 필요합니다
        }

        public void UnregisterEvent(int key, Action<object> @event)
        {
            //이 부분에서는 사용자가 넘긴 event를 구독 해제해주는 구현이 필요합니다
        }

    }
}
