using System;

namespace CodeSamples.SCRIBBLE_BATTLE.Input
{

    /// <summary>
    /// Input의 추상형 인터페이스입니다
    /// </summary>
    public interface IInputContainer
    {
        /// <summary>
        /// Input이벤트를 구독하는 함수입니다
        /// </summary>
        public void RegisterEvent(int key, Action<object> @event);

        /// <summary>
        /// 구독을 해제하는 함수입니다
        /// </summary>
        public void UnregisterEvent(int key, Action<object> @event);
    }
}
