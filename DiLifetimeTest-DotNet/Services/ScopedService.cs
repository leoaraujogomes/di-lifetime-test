using DiLifetimeTest_DotNet.Interfaces;

namespace DiLifetimeTest_DotNet.Services
{
    public class ScopedService: IScoped
    {
        private readonly string _id;
        public ScopedService()
        {
            _id = Guid.NewGuid().ToString();
        }
        public string GetId()
        {
            return _id;
        }
    }
}