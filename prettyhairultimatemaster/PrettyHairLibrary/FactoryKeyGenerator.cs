using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary
{
    class FactoryKeyGenerator
    {
       public static IKeyGenerator SelectMethod(int type)
        {
            switch(type)
            {
                case 1: return new DateKeyGenerator();
                case 2: return new RandomKeyGenerator();
                case 3: return EntityKeyGenerator.Instance;
                default: return null;

            }

        }
    }
}
