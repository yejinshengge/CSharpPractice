using CSharpToLua.API;

namespace CSharpToLua.State
{
    public partial class LuaState
    {
        public void Len(int idx)
        {
            object val = Stack.Get(idx);
            if (val is string s)
            {
                Stack.Push((long)s.Length);
                return;
            }
            else{
                var (res,ok) = LuaValue.CallMetamethod(val,val,"__len",this);
                if(ok){
                    Stack.Push(res);
                    return;
                }
            }
            if(val is LuaTable t)
            {
                Stack.Push((long)t.Length);
                return;
            }
            throw new System.Exception("长度错误：仅支持字符串类型");
            
        }

        public void Concat(int n)
        {
            if (n == 0)
            {
                Stack.Push("");
            }
            else if (n >= 2)
            {
                for (int i = 1; i < n; i++)
                {
                    if (IsString(-1) && IsString(-2))
                    {
                        string s2 = ToString(-1);
                        string s1 = ToString(-2);
                        Stack.Pop();
                        Stack.Pop();
                        Stack.Push(s1 + s2);
                        continue;
                    }
                    // 调用元方法
                    var a = Stack.Pop();
                    var b = Stack.Pop();
                    var (res,ok) = LuaValue.CallMetamethod(a,b,"__concat",this);
                    if(ok){
                        Stack.Push(res);
                        continue;
                    }
                    throw new System.Exception("连接错误：需要两个字符串");
                }
            }
            // n == 1时不执行任何操作
        }
    }
}
