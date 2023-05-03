using Solver.DataTypes;
using Solver.ViewModels;

namespace SolverTests
{
    public class GetResultTests
    {
        SolverViewModel solverVM;
        FunctionalCoordinates funcCoords;
        [SetUp]
        public void Setup()
        {
            solverVM = new SolverViewModel();
            funcCoords = new FunctionalCoordinates();
        }

        [Test]
        public void TestLinearFunc()
        {
            var linear = solverVM.FunctionsList.First();
            linear.ValuesXY.Add(funcCoords);
            funcCoords.ViewModelCaller = linear;
            funcCoords.X = 5;
            funcCoords.Y = 0;
            linear.A = 2;
            linear.B = 3;
            linear.C = 5;
            Assert.AreEqual(18, funcCoords.Result);
        }
        [Test]
        public void TestQuadFunc()
        {
            var quad = solverVM.FunctionsList.ElementAt(1);
            quad.A = 20;
            quad.B = 150;
            quad.C = 50;
            Assert.AreEqual(5770, quad.GetResult(11f, 22f));
        }
        [Test]
        public void TestCubicFunc()
        {
            var cubic = solverVM.FunctionsList.ElementAt(2);
            cubic.A = 2;
            cubic.B = 7;
            cubic.C = 400;
            Assert.AreEqual(629, cubic.GetResult(3f, -5f));
        }
        [Test]
        public void TestFourthPowFunc()
        {
            var fourthPower = solverVM.FunctionsList.ElementAt(3);
            fourthPower.A = 11;
            fourthPower.B = 16;
            fourthPower.C = 5000;
            Assert.AreEqual(115128, fourthPower.GetResult(10f, 2f));
        }
        [Test]
        public void TestFifthPowFunc()
        {
            var fifthPower = solverVM.FunctionsList.ElementAt(4);
            fifthPower.A = 11;
            fifthPower.B = -111;
            fifthPower.C = 10000;
            Assert.AreEqual(-1603887, fifthPower.GetResult(4f, -11f));
        }
    }
}