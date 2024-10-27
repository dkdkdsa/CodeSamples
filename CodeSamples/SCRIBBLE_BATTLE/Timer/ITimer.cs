using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.SCRIBBLE_BATTLE.Timer
{
    public interface ITimer<T>
    {
        /// <summary>
        /// 시간 이벤트를 구독합니다
        /// </summary>
        /// <param name="timeChangeCallback">이벤트</param>
        public void RegisterEvent(Action<T> timeChangeCallback);

        /// <summary>
        /// 시간 이벤트를 구독 해제합니다
        /// </summary>
        /// <param name="timeChangeCallback">이벤트</param>
        public void UnregisterEvent(Action<T> timeChangeCallback);

        /// <summary>
        /// 타이머를 시작합니다
        /// </summary>
        /// <typeparam name="T">시간의 타입</typeparam>
        /// <param name="time">설정할 시간</param>
        public void StartTimer<T>(T time);
    }
}
