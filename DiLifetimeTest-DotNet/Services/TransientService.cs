using DiLifetimeTest_DotNet.Interfaces;

namespace DiLifetimeTest_DotNet.Services
{
    public class TransientService: ITransient
    {
        private readonly string _id;
        public TransientService()
        {
            _id = Guid.NewGuid().ToString();
        }
        public string GetId()
        {
            return _id;
        }
    }
}