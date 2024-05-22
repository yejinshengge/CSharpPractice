using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_01_07
{
    public static void Test()
    {
        LeetCode_01_07 obj = new LeetCode_01_07();
        var tArray = Tools.ConstructTArray("[[1,2,3],[4,5,6],[7,8,9]]");
        //var tArray = Tools.ConstructTArray("[[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]");    
        obj.Rotate(tArray);
        Tools.PrintArr(tArray);
    }
    
    public void Rotate(int[][] matrix) {
        for (int i = 0; i < matrix.Length/2; i++)
        {
            for (int j = i; j < matrix[i].Length - i-1; j++)
            {
                var index1 = matrix.Length - i - 1;
                var index2 = matrix.Length - j - 1;
                
                int first = matrix[i][j];
                matrix[i][j] = matrix[index2][i];
                matrix[index2][i] = matrix[index1][index2];
                matrix[index1][index2] = matrix[j][index1];
                matrix[j][index1] = first;
            }
        }
    }
}