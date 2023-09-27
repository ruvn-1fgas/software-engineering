namespace Task.MatrixDeterminant
{
    /// <summary>
    /// Represents a matrix and provides methods to calculate its determinant.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Calculates the determinant of the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix to calculate the determinant of.</param>
        /// <returns>The determinant of the matrix.</returns>
        public static int CalculateDeterminant(int[][] matrix)
        {
            int determinant = 0;
            if (matrix.Length != matrix[0].Length)
                return -1;
            if (matrix.Length == 1)
                return matrix[0][0];

            for (int i = 0; i < matrix.Length; i++)
                determinant += (int)Math.Pow(-1, i) * matrix[0][i] * CalculateDeterminant(GetMinor(matrix, i));

            return determinant;
        }

        /// <summary>
        /// Gets the minor of the specified matrix at the specified position.
        /// </summary>
        /// <param name="matrix">The matrix to get the minor of.</param>
        /// <param name="position">The position of the minor.</param>
        /// <returns>The minor of the matrix at the specified position.</returns>
        public static int[][] GetMinor(int[][] matrix, int position)
        {
            int[][] minor = new int[matrix.Length - 1][];
            for (int i = 0; i < minor.Length; i++)
                minor[i] = new int[minor.Length];

            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 0; j < position; j++)
                    minor[i - 1][j] = matrix[i][j];
                for (int j = position + 1; j < matrix.Length; j++)
                    minor[i - 1][j - 1] = matrix[i][j];
            }
            return minor;
        }

        /// <summary>
        /// Prints the specified matrix to the console.
        /// </summary>
        /// <param name="matrix">The matrix to print.</param>
        public static void Print(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < matrix.Length; j++)
                    Console.Write($"{matrix[i][j]} ");
                Console.WriteLine("|");
            }
        }

        public static string ToString(int[][] matrix)
        {
            string result = "";
            for (int i = 0; i < matrix.Length; i++)
            {
                result += "| ";
                for (int j = 0; j < matrix.Length; j++)
                    result += $"{matrix[i][j]} ";
                result += "|\n";
            }
            return result;
        }
    }
}