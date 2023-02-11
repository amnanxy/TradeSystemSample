using TradeSystem.Models;
using TradeSystem.Repositories;

namespace TradeSystem.Services.Captures;

public class CaptureService : ICaptureService
{
    private readonly ITradeRepository _tradeRepository;

    public CaptureService(ITradeRepository tradeRepository)
    {
        _tradeRepository = tradeRepository;
    }

    public void Handle(int tradeId)
    {
        var trade = _tradeRepository.Get(tradeId);
        
        trade.Status = TradeStatus.Captured;
        
        // 中間還有其他單據變更與狀態變更記錄
        
        _tradeRepository.Update(trade);
    }
}