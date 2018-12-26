using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanganSuperhighway
{
    class gameInstance
    {
        protected string _networkId;
        protected string _gameName;
        public gameInstance() {
        }

        public string networkId
        {
            get { return _networkId; }
            set { _networkId = networkId; }
        }
        public string gameName
        {
            get { return _gameName; }
            set { _gameName = gameName; }
        }
    }
}
