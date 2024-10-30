namespace CodeSamples.Samples.Factory
{
    
    /// <summary>
    /// 이것이 팩토리임을 나타내는 Interface
    /// </summary>
    public interface IFactoryable { }

    /// <summary>
    /// 팩토리의 추상형 Interface
    /// </summary>
    /// <typeparam name="T">생성 할 인스턴스의 타입</typeparam>
    public interface IFactory<T> : IFactoryable
    {

        /// <summary>
        /// 인스턴스를 생성하는 함수
        /// </summary>
        /// <returns>생성된 인스턴스</returns>
        public T CreateInstance();

    }
}