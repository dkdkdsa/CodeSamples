namespace CodeSamples.Samples.DI
{
    /// <summary>
    /// 저장된 인스턴스를 반환하는 컨테이너
    /// </summary>
    internal class InstanceContainer : IBindContainer
    {

        /// <summary>
        /// 저장된 인스턴스
        /// </summary>
        private object _instance;

        internal InstanceContainer(object o)
        {
            //생성자에서 인스턴스를 저장
            _instance = o;
        }

        object IBindContainer.GetInstance()
        {
            //저장된 인스턴스를 반환
            return _instance;
        }
    }
}