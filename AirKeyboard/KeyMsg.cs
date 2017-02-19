using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirKeyboard
{
    public class KeyMsg
    {
        public List<ushort> keyValues { get; set; }

        public KeyMsg(List<ushort> mKeyValue)
        {
            this.keyValues = mKeyValue;
        }
    }
}
