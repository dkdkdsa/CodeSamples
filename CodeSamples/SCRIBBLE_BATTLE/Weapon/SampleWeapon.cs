using UnityEngine;

namespace CodeSamples.SCRIBBLE_BATTLE.Weapon
{
    /// <summary>
    /// IWeapon을 구현하는 샘플 무기입니다 
    /// 무기는 유니티 메시지 함수를 사용할 수도 있으므로 MonoBehaviour를 상속 받았습니다
    /// </summary>
    public class SampleWeapon : MonoBehaviour, IWeapon
    {
        private void Awake()
        {
            //이 부분에서는 무기의 초기화가 있을 수 있습니다
            //총알을 사용하는 무기라면 총알 팩토리를 찾아 온다던가
            //무기의 값들(공격력, 공격 속도 등)을 초기화 하는 구현이 있을 수 있습니다
        }

        /// <summary>
        /// IWeapon에서 상속된 공격 함수입니다
        /// </summary>
        /// <param name="mouse">마우스 입력 정보</param>
        public void Attack(MouseInputType mouse)
        {
            //이 부분에서는 마우스 입력정보를 확인하는 로직이 있을 수 있습니다
            //예를들어
            //단발 권총의 경우 MouseInputType이 Down일때만 공격을 하여야 합니다.
            //차징이 있는 무기의 경우 MouseInputType이 Down일때는 차징 로직을 실행하고
            //MouseInputType이 Up이 들어오면 공격 로직을 실행 해야합니다.

            //이 부분에서는 실질적인 공격 동작이 있어야 합니다
            //총알을 사용하는 무기라면 총알을 발사 하는 로직이 있을 것 이고
            //근접 무기라면 타겟을 케스팅하는 로직이 있을 것 입니다
        }

        /// <summary>
        /// IWeapon에서 상속된 회전 함수입니다
        /// </summary>
        /// <param name="dir"></param>
        public void RotateWeapon(Vector2 dir)
        {
            //이 부분에서는 무기가 회전하는 로직이 있어야 합니다
        }
        
        /// <summary>
        /// IWeapon에서 상속된 장착 해제 함수입니다
        /// </summary>
        public void Release()
        {
            //이 부분에서는 무기가 장착 해제될때 실행할 로직이 있어야 합니다.

            //예를 들어 무기의 오브젝트를 삭제하여 준다던가(무기 핸들러는 추상화된 무기를 받기에 무기 오브젝트를 삭제할 수 없음)
            //장착 해제할때 무기만의 독특한 기믹이 나오는 로직이 있을 수 있을거 같습니다
        }

    }
}