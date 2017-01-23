using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary
{
    class RandomKeyGenerator : IKeyGenerator
    {
        public int NextKey
        {
            get { return RandomKey(); }
        }


    private int RandomKey()
        {
            Random random = new Random();

            return random.Next(0, 1000);
            


        }
    }
}
