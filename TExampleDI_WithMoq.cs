using Moq;
using System;
using Xunit;

namespace ERTWebApi.UnitTests
{
    public class TExampleDI_WithMoq
    {
        public Mock<IExampleDI> myMock { get; set; }
        public EExampleDI testClass { get; set; }

        public TExampleDI_WithMoq()
        {
            myMock = new Mock<IExampleDI>();
            testClass = new EExampleDI(myMock.Object);

        }

        [Theory]
        [InlineData(1, 2, 3)]
        public void Add_SimpleValues_ReturnTotalValue(int a, int b, int expectedTotal)
        {
            myMock.Setup(x => x.add(a, b)).Returns(expectedTotal);
            var actualTotal = testClass.add(a, b);
            Assert.Equal(expectedTotal, actualTotal);

            //metotun çalýþýp çalýþmadýðýný, çalýþtýysa kaç kere çalýþtýðýný kontrol eder.
            myMock.Verify(x => x.add(a, b), Times.Once);            
            
        }
        
        [Theory]
        [InlineData(5, 2, 10)]
        public void Multiple_SimpleValues_ReturnValues(int a, int b, int expectedValue)
        {
            myMock.Setup(x => x.mutliple(a, b)).Returns(expectedValue);
            var actualValue = testClass.multiple(a, b);

            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData(5, 2, 10)]
        [InlineData(3, 2, 6)]
        public void Multiple_SimpleValues_ReturnValues2(int a, int b, int expectedValue)
        {
            int actualValue = 0;
            myMock.Setup(x => x.mutliple(It.IsAny<int>(), It.IsAny<int>())).Callback<int, int>((x,y)=> actualValue = x*y );

            testClass.multiple(a, b);

            Assert.Equal(expectedValue, actualValue);
        }


        [Theory]
        [InlineData(0, 5)]
        public void Multiple_ZeroValues_ReturnException(int a, int b)
        {
            myMock.Setup(x => x.mutliple(a, b)).Throws(new Exception("a=0 olamaz"));
            
            Exception ex = Assert.Throws<Exception>(()=> testClass.multiple(a, b));

            Assert.Equal("a=0 olamaz", ex.Message);
        }

    }
}
