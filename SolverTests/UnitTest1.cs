using Solver.DataTypes;
using Solver.ViewModels;

namespace SolverTests
{
    public class Tests
    {
        SolverViewModel solverVM;
        FunctionalVector2 funcVec2;
        [SetUp]
        public void Setup()
        {
            solverVM = new SolverViewModel();
            funcVec2 = new FunctionalVector2();
        }

        [Test]
        public void TestLinearFunc()
        {
            var linear = solverVM.FunctionsList.First();
            linear.A = 2;
            linear.B = 3;
            linear.C = 5;
            Assert.AreEqual(18, linear.GetResult(5, 0));
        }
        [Test]
        public void TestQuadFunc()
        {
            var linear = solverVM.FunctionsList.ElementAt(1);
            linear.A = 20;
            linear.B = 150;
            linear.C = 50;
            Assert.AreEqual(5770, linear.GetResult(11, 22));
        }
        [Test]
        public void TestCubicFunc()
        {
            var linear = solverVM.FunctionsList.ElementAt(2);
            linear.A = 2;
            linear.B = 7;
            linear.C = 400;
            Assert.AreEqual(629, linear.GetResult(3, -5));
        }
        [Test]
        public void TestFourthPowFunc()
        {
            var linear = solverVM.FunctionsList.ElementAt(3);
            linear.A = 11;
            linear.B = 16;
            linear.C = 5000;
            Assert.AreEqual(115128, linear.GetResult(10, 2));
        }
        [Test]
        public void TestFifthPowFunc()
        {
            var linear = solverVM.FunctionsList.ElementAt(4);
            linear.A = 11;
            linear.B = -111;
            linear.C = 10000;
            Assert.AreEqual(-1603887, linear.GetResult(4, -11));
        }
    }
}