using System;
using UnityEngine;

namespace CodeSamples.SCRIBBLE_BATTLE.Weapon
{

    /// <summary>
    /// 무기를 핸들링하는 개체의 추상형 인터페이스입니다.
    /// </summary>
    public interface IWeaponHandler
    {

        /// <summary>
        /// 무기를 장착하였을 때 발행되는 이벤트입니다.
        /// </summary>
        public event Action OnEquipWeaponEvent;

        /// <summary>
        /// 무기를 장착해제 하였을 때 발행되는 이벤트입니다.
        /// </summary>
        public event Action OnReleaseWeaponEvent;

        /// <summary>
        /// 공격 하였을 때 발행되는 이벤트입니다.
        /// </summary>
        public event Action OnAttackWeaponEvent;

        /// <summary>
        /// 무기가 회전할 때 발행되는 이벤트입니다.
        /// </summary>
        public event Action<Vector2> OnWeaponRotate;

        /// <summary>
        /// 무기 장착을 추상화한 함수입니다.
        /// 매계변수로 추상화된 무기를 넘기고 상속을 받은 
        /// 개체에서 실질적인 장착 로직을 구현해야 합니다.
        /// </summary>
        /// <param name="weapon"></param>
        public void EquipWeapon(IWeapon weapon);

        /// <summary>
        /// 추상화된 장착해제 함수입니다.
        /// 상속을 받은 개체에서 무기를 장착 해제하는 로직을 구현해야 하고
        /// 장착한 무기의 Release함수를 호출해주어야 합니다.
        /// </summary>
        public void ReleaseWeapon();

        /// <summary>
        /// 추상화된 공격 함수입니다.
        /// 이 함수를 구현하는 개체에서는 장착한 무기의 공격 함수를 실행해주어야 합니다.
        /// 무기의 공격 함수가 마우스 입력 타입을 필요로 하기에
        /// 이 함수도 매계변수로 마우스 입력 정보를 받도록 하였습니다.
        /// </summary>
        /// <param name="input">마우스 입력 정보입니다.</param>
        public void AttackWeapon(MouseInputType input);
        
        /// <summary>
        /// 추상화된 회전 함수입니다.
        /// 이 함수를 구현하는 개체에서는 창착한 무기의 회전 함수를 실행해주어야 합니다.
        /// 무기의 회전 함수가 마우스 방향 정보를 필요로 하기에
        /// 이 함수도 매계변수로 마우스 방향 정보를 받도록 하였습니다
        /// </summary>
        /// <param name="dir"></param>
        public void RotateWeapon(Vector2 dir);

    }

}