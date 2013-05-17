using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;
using System.Text;

namespace WalkInMatrixTests
{
    [TestClass]
    public class WalkInMatrixTests
    {
        [TestMethod]
        public void ToString_MatrixOfOneCell()
        {
            WalkInMatrix matrix = new WalkInMatrix(1);
            matrix.FillMatrix();

            var expected = "  1" + Environment.NewLine;
            var actual = matrix.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_MatrixOfSixCells()
        {
            WalkInMatrix matrix = new WalkInMatrix(6);
            matrix.FillMatrix();
            var actual = matrix.ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("  1 16 17 18 19 20");
            sb.Append(Environment.NewLine);
            sb.Append(" 15  2 27 28 29 21");
            sb.Append(Environment.NewLine);
            sb.Append(" 14 35  3 26 30 22");
            sb.Append(Environment.NewLine);
            sb.Append(" 13 34 36  4 25 23");
            sb.Append(Environment.NewLine);
            sb.Append(" 12 33 32 31  5 24");
            sb.Append(Environment.NewLine);
            sb.Append(" 11 10  9  8  7  6");
            sb.Append(Environment.NewLine);

            var expected = sb.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_MatrixOfZeroCellsException()
        {
            WalkInMatrix matrix = new WalkInMatrix(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexOutOfRangeException()
        {
            WalkInMatrix matrix = new WalkInMatrix(2);
            int exceptionExpected = matrix[2, 2];
        }
    }
}
