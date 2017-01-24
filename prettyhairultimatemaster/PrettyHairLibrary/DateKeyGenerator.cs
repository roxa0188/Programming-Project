using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary
{
    class DateKeyGenerator: IKeyGenerator
    {
        public int NextKey
        {
            get { return DateKey(); }
        }

        private int DateKey()
        {
            DateTime now = DateTime.Now;

            return now.Year + now.Month + now.Day + now.Hour + now.Minute + now.Second + now.Millisecond;
        }
    }
    }

