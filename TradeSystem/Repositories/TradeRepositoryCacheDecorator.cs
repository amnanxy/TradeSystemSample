using TradeSystem.Models;

namespace TradeSystem.Repositories;

public class TradeRepositoryCacheDecorator : ITradeRepository
{
    private readonly ITradeRepository _tradeRepository;
    private readonly Dictionary<int, Trade> _cache;

    public TradeRepositoryCacheDecorator(ITradeRepository tradeRepository)
    {
        _tradeRepository = tradeRepository;
        _cache = new Dictionary<int, Trade>();
    }

    public Trade? Get(int tradeId)
    {
        if (_cache.ContainsKey(tradeId))
        {
            return _cache[tradeId];
        }
        
        var trade = _tradeRepository.Get(tradeId);

        if (trade == null)
        {
            return null;
        }

        _cache[tradeId] = trade;
        
        return trade;
    }

    public void Update(Trade trade)
    {
        _tradeRepository.Update(trade);
    }
}