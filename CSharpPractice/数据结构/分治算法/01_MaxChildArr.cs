using CSharpPractice.Util;

namespace CSharpPractice.Class02;

public class MaxChildArr {
    public static void MaxChildArrMain()
    {
        MaxChildArr obj = new();
        for (int i = 0; i < 1000; i++)
        {
            int[] arr = Util.Tools.RandomArr(10, -10, 10);
            var res1 = obj.FindMaxChildArr(arr);
            var res2 = obj.FindMaxChildArr2(arr);
            if (res1.Length != res2.Length)
            {
                Console.WriteLine("结果不一致！");
                break;
            }
            bool flag = false;
            for (int j = 0; j < res1.Length; j++)
            {
                if (res1[j] != res2[j])
                {
                    flag = true;
                    Console.WriteLine("结果不一致！");
                    break;
                }
            }
            if(flag) break;
        }
        
    }

    private int[] FindMaxChildArr(int[] arr)
    {
        int start=0, end = 0;
        int max = arr[0];
        
        for (int j = 0; j < arr.Length; j++)
        {
            if(arr[j]==0) continue;
            int sum = 0;
            for (int k = j; k < arr.Length; k++)
            {
                sum += arr[k];
                if (sum > max)
                {
                    start = j;
                    end = k;
                    max = sum;
                }
            }
        }

        int[] res = new int[end - start+1];
        Array.Copy(arr,start,res,0,end-start+1);
        return res;
    }

    struct MaxChildArrRes
    {
        public int Left { get; }
        public int Right { get; }
        public int Sum { get; }

        public MaxChildArrRes(int left, int right, int sum)
        {
            Left = left;
            Right = right;
            Sum = sum;
        }
    }

    private int[] FindMaxChildArr2(int[] arr)
    {
        var res = FindMaxChildArr2Process(arr, 0, arr.Length-1);
        int[] resArr = new int[res.Right - res.Left + 1];
        Array.Copy(arr,res.Left,resArr,0,res.Right - res.Left + 1);
        return resArr;
    }
    private MaxChildArrRes FindMaxChildArr2Process(int[] arr,int left,int right)
    {
        // 左右指针重合时直接返回
        if (left == right) return new MaxChildArrRes(left, right, arr[left]);
        // 分别查找左侧和右侧的最大子数组
        int mid = (left + right) / 2;
        var leftRes = FindMaxChildArr2Process(arr, left, mid);
        var rightRes = FindMaxChildArr2Process(arr, mid+1, right);
        
        // 考虑左右指针分别在两侧的情况
        int leftMax = Int32.MinValue;
        int leftSum = 0;
        int leftIndex = 0;
        for (int i = mid; i >= left; i--)
        {
            leftSum += arr[i];
            if (leftSum > leftMax)
            {
                leftMax = leftSum;
                leftIndex = i;
            }
        }
        
        int rightMax = Int32.MinValue;
        int rightSum = 0;
        int rightIndex = 0;
        for (int i = mid+1; i <= right; i++)
        {
            rightSum += arr[i];
            if (rightSum > rightMax)
            {
                rightMax = rightSum;
                rightIndex = i;
            }
        }
        
        // 返回结果
        if (leftRes.Sum >= rightRes.Sum && leftRes.Sum >= leftMax + rightMax) return leftRes;
        if (rightRes.Sum >= leftRes.Sum && rightRes.Sum >= leftMax + rightMax) return rightRes;
        return new MaxChildArrRes(leftIndex, rightIndex, leftMax + rightMax);
    }
}
    

