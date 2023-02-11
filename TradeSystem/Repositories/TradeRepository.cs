using TradeSystem.Models;

namespace TradeSystem.Repositories;

// 假裝這是一個封裝真實 DB 的 Repository
public class TradeRepository : ITradeRepository
{
    private static readonly Dictionary<int, Trade> Database = new()
    {
        { 1, new Trade { Id = 1, Status = TradeStatus.Payed } },
        { 2, new Trade { Id = 2, Status = TradeStatus.Captured } },
        { 3, new Trade { Id = 3, Status = TradeStatus.Refunded } },
    };

    public Trade? Get(int tradeId)
    {
        return Database.ContainsKey(tradeId)
            ? Database[tradeId]
            : null;
    }

    public void Update(Trade trade)
    {
        // update trade
    }
}