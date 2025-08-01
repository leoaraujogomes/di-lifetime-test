using DiLifetimeTest_DotNet.Interfaces;

namespace DiLifetimeTest_DotNet.Services
{
    public class SingletonService: ISingleton
    {
        private readonly string _id;
        public SingletonService()
        {
            _id = Guid.NewGuid().ToString();
        }
        public string GetId()
        {
            return _id;
        }
    }
}