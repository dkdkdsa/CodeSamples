namespace CodeSamples.SCRIBBLE_BATTLE.Factory
{   

    /// <summary>
    /// 
    /// </summary>
    public static class Factory
    {

        /// <summary>
        /// 바인딩된 팩토리를 가져오는 함수입니다
        /// </summary>
        /// <typeparam name="T">가져올 팩토리의 타입입니다</typeparam>
        /// <returns>찾은 팩토리를 반환합니다</returns>
        public static IFactory<T> GetFactory<T>()
        {
            //여기에서는 바인딩된 팩토리를 찾는 구현이 필요합니다
            return default;
        }

    }

}
