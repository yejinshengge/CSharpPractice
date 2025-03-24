using CSharpToLua.API;

namespace CSharpToLua.State
{
    public partial class LuaState
    {
        public void Len(int idx)
        {
            object val = stack.Get(idx);
            if (val is string s)
            {
                stack.Push((long)s.Length);
            }
            else
            {
                throw new System.Exception("长度错误：仅支持字符串类型");
            }
        }

        public void Concat(int n)
        {
            if (n == 0)
            {
                stack.Push("");
            }
            else if (n >= 2)
            {
                for (int i = 1; i < n; i++)
                {
                    if (IsString(-1) && IsString(-2))
                    {
                        string s2 = ToString(-1);
                        string s1 = ToString(-2);
                        stack.Pop();
                        stack.Pop();
                        stack.Push(s1 + s2);
                    }
                    else
                    {
                        throw new System.Exception("连接错误：需要两个字符串");
                    }
                }
            }
            // n == 1时不执行任何操作
        }
    }
}
