using CSharpToLua.API;

namespace CSharpToLua.VirtualMachine;

public static class InstUpValue
{
    /// <summary>
    /// 根据键从该表里取值，然后把值放入目标寄存器中
    /// a:目标寄存器
    /// b:upvalue索引
    /// c:键索引
    /// </summary>
    /// <param name="inst"></param>
    /// <param name="vm"></param>
    public static void GetTabUp(Instruction inst,ILuaVm vm){
        var (a,b,c) = inst.ABC();
        a+=1;
        b+=1;

        vm.GetRK(c);
        vm.GetTable(vm.LuaUpvalueIndex(b));
        vm.Replace(a);
    }

    /// <summary>
    /// 根据键往该表里写入值
    /// a:upvalue索引
    /// b:键索引
    /// c:值索引
    /// </summary>
    /// <param name="inst"></param>
    /// <param name="vm"></param>
    public static void SetTabUp(Instruction inst,ILuaVm vm){
        var (a,b,c) = inst.ABC();
        a+=1;

        vm.GetRK(b);
        vm.GetRK(c);
        vm.SetTable(vm.LuaUpvalueIndex(a));
    }
    /// <summary>
    /// 把当前闭包的某个Upvalue值拷贝到目标寄存器中
    /// </summary>
    /// <param name="inst"></param>
    /// <param name="vm"></param>
    public static void GetUpVal(Instruction inst,ILuaVm vm)
    {
        var (a,b,_) = inst.ABC();
        a+=1;
        b+=1;
        vm.Copy(vm.LuaUpvalueIndex(b),a);
    }

    /// <summary>
    /// 使用寄存器中的值给当前闭包的Upvalue赋值
    /// </summary>
    /// <param name="inst"></param>
    /// <param name="vm"></param>
    public static void SetUpVal(Instruction inst,ILuaVm vm)
    {
        var (a,b,_) = inst.ABC();
        a+=1;
        b+=1;
        vm.Copy(a,vm.LuaUpvalueIndex(b));
    }

}
