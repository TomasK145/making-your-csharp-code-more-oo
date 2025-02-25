﻿using System.Collections.Generic;

namespace RefactoringDemo
{
    static class ControlDigitAlgorithms
    {
        // Factory methods
        public static ControlDigitAlgorithm ForAccountingDepartment =>
            new ControlDigitAlgorithm(x => x.DigitsFromHighest(), MultiplyingFactors, 7);

        public static ControlDigitAlgorithm ForSalesDepartment =>
            new ControlDigitAlgorithm(x => x.DigitsFromLowest(), MultiplyingFactors, 9);

        private static IEnumerable<int> MultiplyingFactors
        {
            get
            {
                int factor = 3;
                while (true)
                {
                    yield return factor;
                    factor = 4 - factor;
                }
            }
        }
    }
}
