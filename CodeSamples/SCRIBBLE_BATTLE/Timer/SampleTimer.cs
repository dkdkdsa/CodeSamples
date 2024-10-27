using System;

namespace CodeSamples.SCRIBBLE_BATTLE.Timer
{
    public class SampleTimer : ITimer<int>
    {
        private Action<int> _event;

        public void RegisterEvent(Action<int> timeChangeCallback)
        {
            //여기에서는 플레이어가 넘긴 이벤트를 구독해주는 로직이 있어야 합니다
            _event += timeChangeCallback;
        }

        public void UnregisterEvent(Action<int> timeChangeCallback)
        {
            //여기에서는 플레이어가 넘긴 이벤트를 구독해주는 로직이 있어야 합니다
            _event -= timeChangeCallback;
        }

        public void StartTimer<T>(T time)
        {
            //여기에서는 타이머를 시작하는 로직이 필요합니다
        }
    }
}
