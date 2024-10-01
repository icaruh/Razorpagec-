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
                AuthSecret = "---",
                BasePath = "---"
            };
        }
    }
}
