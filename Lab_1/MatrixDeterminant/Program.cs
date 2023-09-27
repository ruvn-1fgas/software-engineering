namespace Task.MatrixDeterminant;

internal class Program
{
    static void Main(string[] args)
    {
        int[][] matrix = new int[][] { new[] { 2, 5, 3 }, new[] { 1, -2, -1 }, new[] { 1, 3, 4 } };
        Matrix.Print(matrix);

        var result = Matrix.CalculateDeterminant(matrix);
        Console.WriteLine($"Determinant: {result}");
    }
}