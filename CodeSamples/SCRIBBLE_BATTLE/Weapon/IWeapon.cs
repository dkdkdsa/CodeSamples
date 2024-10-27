using UnityEngine;

namespace CodeSamples.SCRIBBLE_BATTLE.Weapon
{
    /// <summary>
    /// 무기의 추상화 인터페이스입니다
    /// </summary>
    public interface IWeapon
    {
        /// <summary>
        /// 추상화된 공격 함수입니다.
        /// 무기의 공격의 경우 마우스 입력에 따라 여러 공격 방법을 가질 수 있도록(EX. 클릭시 발사, 홀드 시 차징)
        /// 매계변수로 마우스 입력 형식을 넘겨 주었습니다.
        /// </summary>
        /// <param name="mouse">마우스의 입력 형식입니다(Up, Down)</param>
        public void Attack(MouseInputType mouse);

        /// <summary>
        /// 추상화된 회전 함수입니다
        /// 매계변수로 마우스 방향을 받아서 구현할 수 있도록 디자인 하였습니다.
        /// </summary>
        /// <param name="dir">마우스의 방향입니다</param>
        public void RotateWeapon(Vector2 dir);

        /// <summary>
        /// 무기 장착을 해제할때 호출되는 함수입니다.
        /// 무기 장착이 해제된다면 무기에서 여러 행동(무기 오브젝트 삭제 등)을 해줘야 할 수도 있기에 추상화 하였습니다.
        /// </summary>
        public void Release();
    }
}