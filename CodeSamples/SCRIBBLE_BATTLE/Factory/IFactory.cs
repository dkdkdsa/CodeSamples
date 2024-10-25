namespace CodeSamples.SCRIBBLE_BATTLE.Factory
{

    /// <summary>
    /// 추상화된 팩토리 인터페이스입니다
    /// </summary>
    /// <typeparam name="T">생성할 개체의 타입입니다</typeparam>
    public interface IFactory<T>
    {

        /// <summary>
        /// 인스턴스를 생성하는 함수입니다
        /// 이 함수를 구현하는 개체에서는 올바를 타입의 인스턴스를 생성하여 반환해야 합니다
        /// </summary>
        /// <returns>생성된 인스턴스입니다</returns>
        public T CreateInstance();

    }

}