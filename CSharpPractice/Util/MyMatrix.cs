using System.Text;

namespace CSharpPractice.Util;

public class MyMatrix
{
    private int[,] _matrix;
    public int RowNum { get; }
    public int ColNum { get; }

    public int this[int row, int col]
    {
        get => _matrix[row, col];
        set => _matrix[row, col] = value;
    }
    public MyMatrix(int rowNum,int colNum)
    {
        _matrix = new int[rowNum, colNum];
        RowNum = rowNum;
        ColNum = colNum;
    }

    public MyMatrix Multiply(MyMatrix b)
    {
        if (ColNum != b.RowNum)
            throw new Exception("矩阵1的列数与矩阵2的行数需相同");
        MyMatrix newMatrix = new MyMatrix(RowNum, b.ColNum);
        for (int i = 0; i < RowNum; i++)
        {
            for (int j = 0; j < ColNum; j++)
            {
                for (int k = 0; k < b.ColNum; k++)
                {
                    newMatrix[i, k] = (int)(((long)this[i, j] * b[j, k] + newMatrix[i, k])%1000000007);
                }
            }
        }
        return newMatrix;
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < RowNum; i++)
        {
            for (int j = 0; j < ColNum; j++)
            {
                str.Append(_matrix[i, j] + " ");
            }
            str.Append("\n");
        }
        return str.ToString();
    }

    public static void MyMatrixMain()
    {
        MyMatrix a = new MyMatrix(3, 3)
        {
            [0, 0] = 1,
            [0, 1] = 0,
            [0, 2] = 0,
            [1, 0] = 0,
            [1, 1] = 1,
            [1, 2] = 0,
            [2, 0] = 0,
            [2, 1] = 0,
            [2, 2] = 1
        };
        MyMatrix b = new MyMatrix(3, 3)
        {
            [0, 0] = 6,
            [0, 1] = 6,
            [0, 2] = 6,
            [1, 0] = 6,
            [1, 1] = 6,
            [1, 2] = 6,
            [2, 0] = 6,
            [2, 1] = 6,
            [2, 2] = 6
        };
        Console.WriteLine(a.Multiply(b));
    }
}