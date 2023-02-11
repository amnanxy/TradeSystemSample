using TradeSystem.Models;

namespace TradeSystem.Repositories;

public interface ITradeRepository
{
    Trade? Get(int tradeId);
    void Update(Trade trade);
}