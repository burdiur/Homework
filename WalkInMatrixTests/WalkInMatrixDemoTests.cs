using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Matrix;

namespace WalkInMatrixTests
{
    [TestClass]
    public class WalkInMatrixDemoTests
    {
        [TestMethod]
        public void Main_ConsoleUserInputForAMatrixWithSixRows()
        {
            string matrixSize = "6";
            Console.SetIn(new System.IO.StringReader(matrixSize));
            
            var actual = new StringBuilder();
            Console.SetOut(new System.IO.StringWriter(actual));
            
            WalkInMatrixDemo.Main();

            var expected = new StringBuilder();
            expected.Append("Enter matrix size :   1 16 17 18 19 20");
            expected.Append(Environment.NewLine);
            expected.Append(" 15  2 27 28 29 21");
            expected.Append(Environment.NewLine);
            expected.Append(" 14 35  3 26 30 22");
            expected.Append(Environment.NewLine);
            expected.Append(" 13 34 36  4 25 23");
            expected.Append(Environment.NewLine);
            expected.Append(" 12 33 32 31  5 24");
            expected.Append(Environment.NewLine);
            expected.Append(" 11 10  9  8  7  6");
            expected.Append(Environment.NewLine);

            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
