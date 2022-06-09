using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ERTWebApi.UnitTests
{
    public class TExampleDI_WithoutMoq
    {
        public EExampleDI testClass { get; set; }

        public TExampleDI_WithoutMoq()
        {
            // eexampledi classındaki constructorda 
            //kullanılan interfaceten türemiş bir class kullanmam gerekir moq kullanmazsam.
            testClass = new EExampleDI(new SExampleDI());

            //moq yani hayali bir obje vermek yerine gerçek  dünyadan bir servis verildi. 
            // normalde moq ile bir metot test edilmek istendiğinde o servise direkt gitmez, return de ne dönmesini istiyorsak onu vermiş gibi çalışmış gözükür.
            //ama moq yerine gerçek projeden bir servis verilince o servise gider, debugda da zaten servise girer.
        }

        [Theory]
        [InlineData(1, 2, 3)]
        public void Add_SimpleValues_ReturnTotalValue(int a, int b, int expectedTotal)
        {
            var actualTotal = testClass.add(a, b);
            Assert.Equal(expectedTotal, actualTotal);
        }

    }
}
