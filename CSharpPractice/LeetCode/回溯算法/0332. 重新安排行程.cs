using System.Collections.Specialized;
using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.回溯算法;

/**
给你一份航线列表 tickets ，其中 tickets[i] = [fromi, toi] 表示飞机出发和降落的机场地点。请你对该行程进行重新规划排序。
所有这些机票都属于一个从 JFK（肯尼迪国际机场）出发的先生，所以该行程必须从 JFK 开始。如果存在多种有效的行程，请你按字典排序返回最小的行程组合。
例如，行程 ["JFK", "LGA"] 与 ["JFK", "LGB"] 相比就更小，排序更靠前。
假定所有机票至少存在一种合理的行程。且所有的机票 必须都用一次 且 只能用一次。
 */
public class LeetCode_0332
{
    public static void Test()
    {
        LeetCode_0332 obj = new LeetCode_0332();
        var list = obj.FindItinerary(new List<IList<string>>()
        {
            // new List<string>() { "MUC","LHR" },
            // new List<string>() { "JFK","MUC" },
            // new List<string>() { "SFO","SJC" },
            // new List<string>() { "LHR","SFO" },
            
            // new List<string>() { "JFK","SFO" },
            // new List<string>() { "JFK","ATL" },
            // new List<string>() {"SFO","ATL"},
            // new List<string>() { "ATL","JFK" },
            // new List<string>() { "ATL","SFO" },
            
            new List<string>() { "JFK","KUL" },
            new List<string>() { "JFK","NRT" },
            new List<string>() { "NRT","JFK" },
        });
        
        Tools.PrintEnumerator(list);
    }

    private Dictionary<string, IList<IList<string>>> _dic = new Dictionary<string, IList<IList<string>>>();
    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        var list = tickets.OrderBy(e => e[1]).ToList();
        
        for (int i = 0; i < tickets.Count; i++)
        {
            _dic.TryAdd(list[i][0], new List<IList<string>>());
            _dic[list[i][0]].Add(list[i]);
        }
        _path.Add("JFK");
        DoFindItinerary("JFK",new HashSet<IList<string>>(),tickets.Count+1);
        return _res;
    }

    private List<string> _path = new List<string>();
    private List<string> _res = new List<string>();
    private bool DoFindItinerary(string from,HashSet<IList<string>> valid,int total)
    {
        if (_path.Count == total)
        {
            _res = new List<string>(_path);
            return true;
        }

        if (!_dic.ContainsKey(from)) return false;
        var list = _dic[from];
        for (int i = 0; i < list.Count; i++)
        {
            if(valid.Contains(list[i]))
                continue;
            valid.Add(list[i]);
            _path.Add(list[i][1]);
            if(DoFindItinerary(list[i][1], valid, total)) return true;
            _path.RemoveAt(_path.Count-1);
            valid.Remove(list[i]);
        }

        return false;
    }
}