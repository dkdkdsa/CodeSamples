using UnityEngine;

namespace CodeSamples.SCRIBBLE_BATTLE.Factory
{
    /// <summary>
    /// 팩토리들을 저장하는 콘테이너 클래스입니다
    /// </summary>
    public class FactoryContainer : MonoBehaviour
    {

        public void Awake()
        {
            //이 부분에서는 싱글톤 초기화 로직이 있어야 합니다
        }

        private void InitContainer()
        {
            //이 부분에서는 팩토리를 찾고 바인딩하는 로직이 있어야 합니다
        }

    }

}
