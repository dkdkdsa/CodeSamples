using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.SCRIBBLE_BATTLE.Timer
{
    public static class TimerHelper
    {
        public static ITimer<T> StartTimer<T>()
        {
            //지정한 타입의 타이머를 찾아오기
            ITimer<T> timer = default;

            //지정한 타입의 타이머를 시작하기
            timer.StartTimer<T>(default);

            return timer;
        }
    }
}
