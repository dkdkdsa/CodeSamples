namespace CodeSamples.SCRIBBLE_BATTLE.Factory
{
    /// <summary>
    /// 샘플 팩토리
    /// </summary>
    internal class SampleFactory : IFactory<object>
    {
        public object CreateInstance()
        {
            //여기에는 인스턴스를 생성하고 반환해주는 로직이 있어야 합니다
            //EX
            return new object();
        }

    }
}
