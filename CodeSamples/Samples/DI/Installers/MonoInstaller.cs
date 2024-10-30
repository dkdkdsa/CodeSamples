using UnityEngine;

namespace CodeSamples.Samples.DI
{
    /// <summary>
    /// 기본 Installer
    /// </summary>
    public sealed class MonoInstaller : MonoInstallerBase
    {
        protected sealed override void InstallBinding(DIContainer container)
        {
            //자신의 모든 컴포넌트를 받아오기
            var compos = GetComponents<Component>();

            foreach (var compo in compos)
            {
                //컴포넌트를 바인딩
                container.Bind(compo.GetType(), compo);
            }
        }
    }
}
