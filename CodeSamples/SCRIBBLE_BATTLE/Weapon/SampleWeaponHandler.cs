using System;
using UnityEngine;

namespace CodeSamples.SCRIBBLE_BATTLE.Weapon
{

    /// <summary>
    /// IWeaponHandler을 구현하는 샘플 무기 핸들러입니다 
    /// 무기 핸들러는 유니티 메시지 함수를 사용할 수도 있으므로 MonoBehaviour를 상속 받았습니다
    /// </summary>
    public class SampleWeaponHandler : MonoBehaviour, IWeaponHandler
    {

        /// <summary>
        /// IWeaponHandler에서 상속된 무기 장착시 발생하는 이벤트입니다
        /// </summary>
        public event Action OnEquipWeaponEvent;

        /// <summary>
        /// IWeaponHandler에서 상속된 무기 장착 해제시 발생하는 이벤트입니다
        /// </summary>
        public event Action OnReleaseWeaponEvent;

        /// <summary>
        /// IWeaponHandler에서 상속된 공격시 발생하는 이벤트입니다
        /// </summary>
        public event Action OnAttackWeaponEvent;

        /// <summary>
        /// 
        /// </summary>
        public event Action<Vector2> OnRotateWeaponEvent;

        /// <summary>
        /// IWeaponHandler에서 상속받은 무기 공격 함수입니다
        /// </summary>
        /// <param name="input">마우스 입력 정보</param>
        public void AttackWeapon(MouseInputType input)
        {
            //이 부분에서는 무기를 장착 중인지 확인하는 로직이 있어야 합니다
            //무기를 장착중이 아니라면 공격이 실행되면 안되기 때문입니다

            //이 부분에서는 핸들링하는 무기의 공격 함수를 실행해주는 함수가 있어야 합니다

            //이 부분에서는 공격 이벤트를 발행해주는 구현이 있어야 합니다
            //EX
            OnAttackWeaponEvent?.Invoke();
        }

        /// <summary>
        /// IWeaponHandler에서 상속받은 무기 장착 함수입니다
        /// </summary>
        /// <param name="weapon"></param>
        public void EquipWeapon(IWeapon weapon)
        {
            //여기에는 무기의 장착 로직이 있어야 합니다

            //장착한 무기를 저장하는 방법은
            //내부에 변수를 만들어서 할당해주는 방법도 좋을것 같고
            //외부에서 관리해주는 방법도 좋을것 같습니다

            //이 부분에서는 장착 이벤트를 발행해주는 구현이 있어야 합니다
            //EX
            OnEquipWeaponEvent?.Invoke();
        }

        /// <summary>
        /// IWeaponHandler에서 상속받은 무기 회전 함수입니다
        /// </summary>
        /// <param name="dir"></param>
        public void RotateWeapon(Vector2 dir)
        {
            //이곳에는 무기의 회전 함수를 호출하는 로직이 있어야 합니다

            //이 부분에서는 회전 이벤트를 발행해주는 구현이 있어야 합니다
            //EX
            OnRotateWeaponEvent?.Invoke(dir);
        }

        /// <summary>
        /// IWeaponHandler에서 상속받은 무기 장착 해제 함수입니다
        /// </summary>
        public void ReleaseWeapon()
        {
            //이곳에는 무기를 장착 해제하는 로직이 구현되어야 합니다

            //이 부분에서는 장착 해제 이벤트를 발행해주는 구현이 있어야 합니다
            //EX
            OnReleaseWeaponEvent?.Invoke();
        }

    }
}