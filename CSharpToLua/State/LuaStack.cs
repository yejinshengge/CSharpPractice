namespace CSharpToLua.State
{
    using System.Collections.Generic;

    /// <summary>
    /// Lua虚拟栈实现
    /// 功能：模拟Lua的调用栈结构
    /// 设计说明：
    /// 1. 使用动态List实现可扩展栈结构
    /// 2. 索引支持正负索引（正索引从1开始，负索引从-1开始）
    /// 3. 自动扩容机制保证栈空间
    /// </summary>
    public class LuaStack
    {
        private readonly List<object> slots = new();
        public int Top { get; private set; }

        /// <summary>
        /// 初始化指定容量的栈
        /// </summary>
        public LuaStack(int size)
        {
            // 预填充null元素模拟Lua栈初始状态
            for (int i = 0; i < size; i++)
            {
                slots.Add(null);
            }
            Top = 0;
        }

        /// <summary>
        /// 确保栈空间足够容纳n个元素
        /// </summary>
        public void Check(int n)
        {
            int free = slots.Count - Top;
            for (int i = free; i < n; i++)
            {
                slots.Add(null);
            }
        }

        /// <summary>
        /// 压入栈顶元素
        /// </summary>
        public void Push(object val)
        {
            if (Top == slots.Count)
            {
                throw new System.StackOverflowException("Lua栈溢出");
            }
            slots[Top++] = val;
        }

        /// <summary>
        /// 弹出栈顶元素
        /// </summary>
        public object Pop()
        {
            if (Top < 1)
            {
                throw new System.InvalidOperationException("Lua栈下溢");
            }
            var val = slots[--Top];
            slots[Top] = null; // 帮助GC回收
            return val;
        }

        /// <summary>
        /// 转换相对索引为绝对索引
        /// 索引规则：
        /// 正数：从栈底开始（1-based）
        /// 负数：从栈顶开始（-1表示栈顶）
        /// </summary>
        public int AbsIndex(int idx)
        {
            return idx >= 0 ? idx : idx + Top + 1;
        }

        /// <summary>
        /// 验证索引有效性
        /// </summary>
        public bool IsValid(int idx)
        {
            int absIdx = AbsIndex(idx);
            return absIdx > 0 && absIdx <= Top;
        }

        /// <summary>
        /// 获取指定索引处的值
        /// </summary>
        public object Get(int idx)
        {
            int absIdx = AbsIndex(idx);
            return absIdx > 0 && absIdx <= Top ? slots[absIdx - 1] : null;
        }

        /// <summary>
        /// 设置指定索引处的值
        /// </summary>
        public void Set(int idx, object val)
        {
            int absIdx = AbsIndex(idx);
            if (absIdx > 0 && absIdx <= Top)
            {
                slots[absIdx - 1] = val;
                return;
            }
            throw new System.ArgumentOutOfRangeException($"无效栈索引: {idx}");
        }

        /// <summary>
        /// 反转栈中指定范围的元素
        /// </summary>
        /// <param name="from">起始索引（包含）</param>
        /// <param name="to">结束索引（包含）</param>
        public void Reverse(int from, int to)
        {
            while (from < to)
            {
                (slots[to], slots[from]) = (slots[from], slots[to]);
                from++;
                to--;
            }
        }
    }
}
