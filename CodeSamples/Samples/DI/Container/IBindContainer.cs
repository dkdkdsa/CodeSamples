namespace CodeSamples.Samples.DI
{
    /// <summary>
    /// 오브젝트를 바인딩 할 컨테이너의 추상형 interface
    /// </summary>
    internal interface IBindContainer
    {
        //인스턴스를 반환하는 함수
        internal object GetInstance();
    }
}
