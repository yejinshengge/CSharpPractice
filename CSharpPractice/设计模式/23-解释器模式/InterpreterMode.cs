namespace CSharpPractice.设计模式._23_解释器模式;

public class InterpreterMode
{
    public static void InterpreterModeMain()
    {
        Context context = new Context();
        var exp1 = new TerminalExpression("1");
        var exp2 = new TerminalExpression("2");
        var res = new PlusNonTerminalExpression(exp1, exp2);

        Console.WriteLine("1+2="+res.Interpret(context));
        // 输出结果:
        // 1+2=3
    }
}
// 抽象表达式
abstract class AbstractExpression
{
    // 解释
    public abstract int Interpret(Context context);
}
// 解释器之外的全局信息
class Context
{
    private Dictionary<string, int> _map = new();

    public Context()
    {
        _map.Add("1",1);
        _map.Add("2",2);
        _map.Add("3",3);
    }

    public int Interpret(string key)
    {
        return _map[key];
    }
}
// 终结符表达式
class TerminalExpression : AbstractExpression
{
    private string _key;
    public TerminalExpression(string key)
    {
        _key = key;
    }
    public override int Interpret(Context context)
    {
        return context.Interpret(_key);
    }
}
// 加法非终结符表达式
class PlusNonTerminalExpression : AbstractExpression
{
    private AbstractExpression _exp1;
    private AbstractExpression _exp2;

    public PlusNonTerminalExpression(AbstractExpression exp1, AbstractExpression exp2)
    {
        _exp1 = exp1;
        _exp2 = exp2;
    }
    public override int Interpret(Context context)
    {
        return _exp1.Interpret(context) + _exp2.Interpret(context);
    }
}