
using System.Collections.Immutable;
using System.Text;

namespace CSharpPractice.LeetCode.动态规划.记忆化搜索;

/**
 * 在 LeetCode 商店中， 有 n 件在售的物品。每件物品都有对应的价格。然而，也有一些大礼包，每个大礼包以优惠的价格捆绑销售一组物品。
    
    给你一个整数数组 price 表示物品价格，其中 price[i] 是第 i 件物品的价格。另有一个整数数组 needs 表示购物清单，其中 needs[i] 是需要购买第 i 件物品的数量。
    
    还有一个数组 special 表示大礼包，special[i] 的长度为 n + 1 ，其中 special[i][j] 表示第 i 个大礼包中内含第 j 件物品的数量，且 special[i][n] （也就是数组中的最后一个整数）为第 i 个大礼包的价格。
    
    返回 确切 满足购物清单所需花费的最低价格，你可以充分利用大礼包的优惠活动。你不能购买超出购物清单指定数量的物品，即使那样会降低整体价格。任意大礼包可无限次购买。
 */
public class LeetCode_0638
{
    public static void Test()
    {
        LeetCode_0638 obj = new LeetCode_0638();
        Console.WriteLine(obj.ShoppingOffers(new List<int>(){2,5},
            new List<IList<int>>(){new List<int>(){3,0,5},new List<int>(){1,2,10} },
            new List<int>(){3,2}));
        
        Console.WriteLine(obj.ShoppingOffers(new List<int>(){2,3,4},
            new List<IList<int>>(){new List<int>(){1,1,0,4},new List<int>(){2,2,1,9} },
            new List<int>(){1,2,1}));
        
    }
    
    public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
    {
        // 预处理礼包,过滤比直接买更贵的礼包
        IList<IList<int>> realSp = new List<IList<int>>();
        foreach (var sp in special)
        {
            int totalCount = 0;
            int totalPrice = 0;
            for (int i = 0; i < sp.Count-1; i++)
            {
                totalCount += sp[i];
                totalPrice += sp[i] * price[i];
            }

            if (totalCount > 0 && totalPrice > sp[^1]) 
                realSp.Add(sp);
        }
        
        return _dfs(price, realSp, needs.ToImmutableList());
    }

    private Dictionary<ImmutableList<int>, int> _cache = new Dictionary<ImmutableList<int>, int>();
    private int _dfs(IList<int> price, IList<IList<int>> special,ImmutableList<int> needs)
    {
        // 命中缓存,直接返回
        if (_cache.TryGetValue(needs, out var cacheVal)) return cacheVal;
        // 直接购买
        int total = 0;
        for (int i = 0; i < needs.Count; i++)
        {
            total += needs[i] * price[i];
        }
        
        // 遍历礼包,找出合适的购买
        for (int i = 0; i < special.Count; i++)
        {
            List<int> nextNeeds = new List<int>();
            
            // 礼包中有物品数量超出需求,直接跳过
            bool valid = true;
            for (int j = 0; j < price.Count; j++)
            {
                if (special[i][j] > needs[j])
                {
                    valid = false;
                    break;
                }
                nextNeeds.Add(needs[j] - special[i][j]);
            }
            
            if(valid) 
                total = Math.Min(total, _dfs(price, special, nextNeeds.ToImmutableList())+special[i][^1]);
        }

        _cache[needs] = total;
        return total;
    }
}