using CodeSamples.Samples.DI;

namespace CodeSamples.Samples.Factory
{
    public class SampleInstaller : TargetInstaller<SampleUse>
    {
        protected override void InstallBinding(DIContainer container)
        {
            //샘플에서 사용하는 팩토리를 바인딩
            container.Bind<IFactory<SampleUse>>(Factorys.GetFactroy<SampleUse>());
        }
    }
}
