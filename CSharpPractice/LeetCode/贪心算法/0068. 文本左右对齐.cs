using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.贪心算法;

/**
 * 给定一个单词数组 words 和一个长度 maxWidth ，重新排版单词，使其成为每行恰好有 maxWidth 个字符，且左右两端对齐的文本。
    
    你应该使用 “贪心算法” 来放置给定的单词；也就是说，尽可能多地往每行中放置单词。必要时可用空格 ' ' 填充，使得每行恰好有 maxWidth 个字符。
    
    要求尽可能均匀分配单词间的空格数量。如果某一行单词间的空格不能均匀分配，则左侧放置的空格数要多于右侧的空格数。
    
    文本的最后一行应为左对齐，且单词之间不插入额外的空格。
    
    注意:
    
    单词是指由非空格字符组成的字符序列。
    每个单词的长度大于 0，小于等于 maxWidth。
    输入单词数组 words 至少包含一个单词。
 */
public class LeetCode_0068
{
    public static void Test()
    {
        LeetCode_0068 obj = new LeetCode_0068();
        Tools.PrintEnumerator(obj.FullJustify(new []{"What","must","be","acknowledgment","shall","be"},16));
    }
    
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        List<string> res = new List<string>();
        StringBuilder builder = new StringBuilder();
        int index = 0;
        while (index < words.Length)
        {
            builder.Clear();
            int startIndex = index;
            int totalLen = 0;
            while (index < words.Length && totalLen + words[index].Length+(index-startIndex) <= maxWidth )
            {
                totalLen += words[index].Length;
                index++;
            }
            
            // 需要填多少空格
            int spaceNum = maxWidth - totalLen;

            // 不是最后一行
            if (index < words.Length)
            {
                // 总共几个空位
                var blockNum = (index - startIndex - 1);
                // 平均分配在字符串之间
                var spacePerBlock = blockNum == 0?spaceNum:(spaceNum / blockNum);
                // 余下的空格
                var restSpace = blockNum == 0?0:(spaceNum % blockNum);

                for (int i = startIndex; i < index; i++)
                {
                    builder.Append(words[i]);
                    if (i < index - 1||startIndex == index-1)
                    {
                        builder.Append(new string(' ', spacePerBlock + (restSpace > 0 ? 1 : 0)));
                        restSpace--;
                    }
                }
                
            }
            // 最后一行特殊处理
            else
            {
                for (int i = startIndex; i < index; i++)
                {
                    builder.Append(words[i]);
                    if (i < index - 1)
                    {
                        builder.Append(' ');
                        spaceNum--;
                    }
                }

                builder.Append(new string(' ', spaceNum));
            }
            
            
            res.Add(builder.ToString());
            
        }
        
        return res;
    }
}