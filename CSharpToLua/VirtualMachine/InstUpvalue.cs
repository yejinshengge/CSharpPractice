using CSharpToLua.API;

namespace CSharpToLua.VirtualMachine;

public static class InstUpValue
{
    /// <summary>
    /// 把某个全局变量放入指定寄存器
    /// </summary>
    /// <param name="inst"></param>
    /// <param name="vm"></param>
    public static void GetTabUp(Instruction inst,ILuaVm vm){
        var (a,_,c) = inst.ABC();
        a+=1;

        vm.PushGlobalTable();
        vm.GetRK(c);
        vm.GetTable(-2);
        vm.Replace(a);
        vm.Pop(1);
    }
}
