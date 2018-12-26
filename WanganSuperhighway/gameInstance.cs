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

        public string NetworkId
        {
            get { return _networkId; }
            set { _networkId = value; }
        }
        public string GameName
        {
            get { return _gameName; }
            set { _gameName = value; }
        }
    }
}
