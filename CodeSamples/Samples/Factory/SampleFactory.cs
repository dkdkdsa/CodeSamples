namespace CodeSamples.Samples.Factory
{
    public class SampleObject { }

    public class SampleFactory : IFactory<SampleObject>
    {
        public SampleObject CreateInstance()
        {
            //타입에 해당하는 오브젝트를 생성 후 반환
            return new SampleObject();
        }
    }
}
