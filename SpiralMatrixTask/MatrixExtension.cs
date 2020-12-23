using System;

#pragma warning disable CA1814
#pragma warning disable S2368

namespace SpiralMatrixTask
{
    /// <summary>
    /// Matrix manipulation.
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Fills the matrix with natural numbers, starting from 1 in the top-left corner, increasing in an inward, clockwise spiral order.
        /// </summary>
        /// <param name="size">Matrix size.</param>
        /// <returns>Filled matrix.</returns>
        /// <exception cref="ArgumentException">Thrown when matrix size less or equal zero.</exception>
        /// <example> size = 3
        ///     1 2 3
        ///     8 9 4
        ///     7 6 5.
        /// </example>
        /// <example> size = 4
        ///     1  2  3  4
        ///     12 13 14 5
        ///     11 16 15 6
        ///     10 9  8  7.
        /// </example>
        public static int[,] GetMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Size of matrix '{size}' cannot be less or equal zero.");
            }

            int rowStartIdx = 0, columnStartIdx = 0, rowEndIdx = size - 1, columnEndIdx = size - 1, value = 1;
            var matrix = new int[size, size];
            while (value <= size * size)
            {
                // Filling up right.
                for (int i = columnStartIdx; i <= columnEndIdx; i++)
                {
                    matrix[rowStartIdx, i] = value;
                    value++;
                }

                rowStartIdx++;

                // Filling up down.
                for (int i = rowStartIdx; i <= rowEndIdx; i++)
                {
                    matrix[i, columnEndIdx] = value;
                    value++;
                }

                columnEndIdx--;

                // Filling up left.
                for (int i = columnEndIdx; i >= columnStartIdx; i--)
                {
                    matrix[rowEndIdx, i] = value;
                    value++;
                }

                rowEndIdx--;

                // Filling up.
                for (int i = rowEndIdx; i >= rowStartIdx; i--)
                {
                    matrix[i, columnStartIdx] = value;
                    value++;
                }

                columnStartIdx++;
            }

            return matrix;
        }        
    }
}
