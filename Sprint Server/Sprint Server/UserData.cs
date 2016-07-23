using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_Server
{
    class UserData
    {
        private string Name { get; set; }
        private int level { get; set; }
        private int exp { get; set; }
        //private int something { get; set; }
        //private int something { get; set; }
        //private int something { get; set; }

        public UserData(string Name, int level, int exp)
        {
            this.Name = Name;
            this.level = level;
            this.exp = exp;
        }
    }
}
