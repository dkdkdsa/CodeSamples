using Unity.Netcode;

namespace CodeSamples.SCRIBBLE_BATTLE.Weapon
{
    /// <summary>
    /// IWeaponHandler를 네트워크 동기화 시키는 클래스 입니다.
    /// </summary>
    public class SampleNetworkWeapon : NetworkBehaviour
    {
        public override void OnNetworkSpawn()
        {
            //이 부분에서는 무기 핸들러의 이벤트를 구독하는 구현이 있어야 합니다
            //Owner일때 만 구독을 하는 조건도 필요할 것 같습니다
        }

        /// <summary>
        /// 무기 실행 이벤트를 받을 시 실행하는 ServerRPC입니다
        /// </summary>
        [ServerRpc]
        private void EquipWeaponServerRPC()
        {
            //이부분에서는 무기를 장착했다는 것을 모든 클라이언트에게 알려주어야 합니다
            //Ex
            EquipWeaponClientRPC();
        }

        /// <summary>
        /// 무기 실행 이벤트를 받을 시 실행하는 ClientRPC입니다
        /// </summary>
        [ClientRpc]
        private void EquipWeaponClientRPC()
        {
            //이부분에서는 장착한 무기를 동기화 시켜주어야 합니다
            //상황에 따라서는 Owner이면 실행하지 않는 조건이 필요할 수 있습니다
            //여기에서는 무기 핸들러에 장착 부분을 실행하여 동기화 해야합니다
        }
    }
}