using FireSharp.Config;
using FireSharp.Interfaces;

namespace lovelove.Dbconfig
{
    public class DbSettings
    {
        public IFirebaseConfig Config { get; private set; }

        public DbSettings()
        {
            Config = new FirebaseConfig
            {
                AuthSecret = "uWgYGkr51O5H75fjHvNAlnnlAsRWCn3PUUBLVQAo",
                BasePath = "https://mynewproject-1a041-default-rtdb.firebaseio.com"
            };
        }
    }
}
