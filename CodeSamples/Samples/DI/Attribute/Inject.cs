using System;

namespace CodeSamples.Samples.DI
{
    /// <summary>
    /// 의존성 주입이 필요함을 나타내는 속성
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
    public class Inject : Attribute
    {
    }
}
