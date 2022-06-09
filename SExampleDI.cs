using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERTWebApi.UnitTests
{
    class SExampleDI : IExampleDI
    {
        public int add(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;

            return a + b;
        }

        public int mutliple(int a, int b)
        {
            if (a == 0)
                throw new Exception("a=0 olamaz");

            return a * b;
        }
    }
}
