/*  Refactor the C# code from the Visual Studio Project "12. Refactoring-Homework.zip" to improve its internal quality. You might follow the following steps:
        1. Make some initial refactorings like:
            - Reformat the code.
            - Rename the ugly named variables.
        2. Make the code testable.
            - Think how to test console-based input / output.
        3. Write unite tests. Fix any bugs found in the mean time.
        4. Refactor the code following the guidelines from this chapter. Do it step by step. Run the unit tests after each major change.
*/

using System;

namespace Matrix
{
    public class WalkInMatrixDemo
    {
        public static void Main()
        {
            Console.Write("Enter matrix size : ");
            WalkInMatrix matrix = new WalkInMatrix(int.Parse(Console.ReadLine()));

            matrix.FillMatrix();

            Console.Write(matrix);
        }
    }
}
