using System;
using System.Collections.Generic;
using CSharpToLua.Number;

namespace CSharpToLua.State;

/// <summary>
/// Lua表实现类，模拟Lua的table数据结构
/// 包含数组部分（连续数字索引）和哈希部分（非连续键）
/// 遵循Lua 5.3规范实现1-based索引
/// </summary>
public class LuaTable
{
    // 数组部分，用于存储连续数字索引的值（1-based）
    private List<object> _arr;

    // 哈希表部分，用于存储非连续键值对
    private Dictionary<object, object> _map;

    // 元表
    public LuaTable Metatable;

    /// <summary>
    /// 获取数组部分的逻辑长度（忽略末尾的null）
    /// </summary>
    public int Length => _arr?.Count ?? 0;

    /// <summary>
    /// 构造函数，创建Lua表
    /// </summary>
    /// <param name="arraySize">预估数组部分大小（容量预分配）</param>
    /// <param name="recordSize">预估哈希表部分大小（容量预分配）</param>
    public LuaTable(int arraySize = 0, int recordSize = 0)
    {
        if (arraySize > 0)
        {
            // 初始化数组部分，使用指定容量但保持实际元素为空
            // 注意：这里不预填充null元素，因为Lua表的数组部分会自动扩展
            _arr = new List<object>(arraySize);
        }

        if (recordSize > 0)
        {
            // 初始化哈希表部分，使用指定初始容量减少扩容次数
            _map = new Dictionary<object, object>(recordSize);
        }
    }

    /// <summary>
    /// 获取表中指定键对应的值
    /// </summary>
    /// <param name="key">查找键，支持任意类型</param>
    /// <returns>
    /// 找到的值，若不存在返回null（对应Lua的nil）
    /// </returns>
    public object Get(object key)
    {
        // 首先处理浮点数键的特殊情况（Lua中1.0和1是等价的键）
        key = FloatToInteger(key);

        // 处理数组部分访问
        if (key is long index)
        {
            // Lua数组索引从1开始，转换为0-based索引
            // 仅当索引在有效范围内时访问数组
            if (index >= 1 && index <= _arr?.Count)
            {
                return _arr[(int)index - 1];
            }
        }

        // 处理哈希表部分访问
        if (_map != null && _map.TryGetValue(key, out var value))
        {
            return value;
        }

        // 未找到返回null（对应Lua的nil）
        return null;
    }

    /// <summary>
    /// 将浮点型键转换为整型（如果可能）
    /// </summary>
    /// <param name="key">原始键</param>
    /// <returns>
    /// 当键为整数值的double时返回long类型，否则返回原类型
    /// </returns>
    private static object FloatToInteger(object key)
    {
        if (key is double d)
        {
            // 检查是否为整数值（小数部分为0且不在无限大状态）
            (long i, bool res) = LuaMath.FloatToInteger(d);
            if(res) return i;
        }
        return key;
    }

    /// <summary>
    /// 向表中插入或更新键值对
    /// </summary>
    /// <param name="key">键，不能为null或NaN</param>
    /// <param name="val">值，null表示删除该键</param>
    /// <exception cref="ArgumentException">当键为null或NaN时抛出</exception>
    public void Put(object key, object val)
    {
        // 参数校验
        if (key == null)
        {
            throw new ArgumentException("table index is null!");
        }
        
        if (key is double d && double.IsNaN(d))
        {
            throw new ArgumentException("table index is NaN!");
        }

        // 处理浮点数键转换
        key = FloatToInteger(key);

        // 尝试处理数组部分
        if (key is long idx && idx >= 1)
        {
            // 转换为0-based索引
            int arrayIndex = (int)(idx - 1);
            
            // 情况1：索引在现有数组范围内
            if (arrayIndex < _arr?.Count)
            {
                _arr[arrayIndex] = val;
                
                // 如果设置末尾元素为null，需要收缩数组
                if (arrayIndex == _arr.Count && val == null)
                {
                    ShrinkArray();
                }
                return;
            }
            
            // 情况2：索引正好是数组长度+1
            if (idx == (_arr?.Count ?? 0) + 1)
            {
                // 从哈希表中移除该键（如果存在）
                _map?.Remove(key);
                
                if (val != null)
                {
                    _arr ??= new List<object>();
                    _arr.Add(val);
                    ExpandArray(); // 尝试扩展数组
                }
                return;
            }
        }

        // 处理哈希表部分
        if (val != null)
        {
            _map ??= new Dictionary<object, object>(8);
            _map[key] = val;
        }
        else
        {
            _map?.Remove(key);
        }
    }

    /// <summary>
    /// 收缩数组，移除末尾的null元素
    /// </summary>
    private void ShrinkArray()
    {
        if (_arr == null) return;

        // 从后向前查找第一个非null元素
        int newSize = _arr.Count;
        while (newSize > 0 && _arr[newSize - 1] == null)
        {
            newSize--;
        }

        // 调整数组大小
        if (newSize < _arr.Count)
        {
            _arr = _arr.GetRange(0, newSize);
        }
    }

    /// <summary>
    /// 扩展数组，将哈希表中连续的整数键迁移到数组
    /// </summary>
    private void ExpandArray()
    {
        if (_map == null) return;

        // 从当前数组长度+1开始检查
        long nextIndex = (_arr?.Count ?? 0) + 1;
        while (true)
        {
            if (_map.TryGetValue(nextIndex, out object val))
            {
                _arr.Add(val);
                _map.Remove(nextIndex);
                nextIndex++;
            }
            else
            {
                break;
            }
        }
    }

    /// <summary>
    /// 检查表是否具有指定元方法
    /// </summary>
    /// <param name="fieldName">元方法名称</param>
    /// <returns>
    /// 如果表具有指定元方法，返回true；否则返回false
    /// </returns>
    public bool HasMetafield(string fieldName)
    {
        return Metatable != null && Metatable.Get(fieldName) != null;
    }
}

