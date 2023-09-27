namespace Task.MatrixDeterminant.Test
{
    /// <summary>
    /// Contains unit tests for the Matrix class.
    /// </summary>
    [TestClass]
    public class MatrixTests
    {
        /// <summary>
        /// Tests the CalculateDeterminant method with valid input.
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(DeterminantTestData), DynamicDataSourceType.Method)]
        public void DeterminantValidTest(int[][] matrix, int expected)
        {
            int result = Matrix.CalculateDeterminant(matrix);
            Assert.AreEqual(expected, result, $"Expected: {expected}, Actual: {result}");
        }

        private static IEnumerable<object[]> DeterminantTestData()
        {
            yield return new object[] { new int[][] { new int[] { 1 } }, 1 };
            yield return new object[] { new int[][] { new int[] { 1, 3 }, new int[] { 2, 5 } }, -1 };
            yield return new object[] { new int[][] { new int[] { 2, 5, 3 }, new int[] { 1, -2, -1 }, new int[] { 1, 3, 4 } }, -20 };
        }

        /// <summary>
        /// Tests the GetMinor method with valid input.
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(MinorTestData), DynamicDataSourceType.Method)]
        public void GetMinorValidTest(int[][] matrix, int position, int[][] expected)
        {
            int[][] actual = Matrix.GetMinor(matrix, position);
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].Length, actual[i].Length);
                for (int j = 0; j < expected[i].Length; j++)
                {
                    Assert.AreEqual(expected[i][j], actual[i][j]);
                }
            }
        }

        private static IEnumerable<object[]> MinorTestData()
        {
            yield return new object[] {
                new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } },
                0,
                new int[][] { new int[] { 5, 6 }, new int[] { 8, 9 } }
            };
            yield return new object[] {
                new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } },
                1,
                new int[][] { new int[] { 4, 6 }, new int[] { 7, 9 } }
            };
            yield return new object[] {
                new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } },
                2,
                new int[][] { new int[] { 4, 5 }, new int[] { 7, 8 } }
            };
        }
    }
}