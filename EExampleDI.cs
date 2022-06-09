namespace ERTWebApi.UnitTests
{
    public class EExampleDI
    {
        private IExampleDI _exampleDI { get; set; }
        public EExampleDI(IExampleDI exampleDI)
        {
            _exampleDI = exampleDI;
        }


        public int add(int a, int b) {
            return _exampleDI.add(a , b);
        }

        public int multiple(int a, int b)
        {
            return _exampleDI.mutliple(a, b);
        }
    }
}
