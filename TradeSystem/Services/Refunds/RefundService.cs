using TradeSystem.Models;
using TradeSystem.Repositories;

namespace TradeSystem.Services.Refunds;

public class RefundService : IRefundService
{
    private readonly ITradeRepository _tradeRepository;

    public RefundService(ITradeRepository tradeRepository)
    {
        _tradeRepository = tradeRepository;
    }

    public void Handle(int tradeId)
    {
        var trade = _tradeRepository.Get(tradeId);

        trade.Status = TradeStatus.Refunded;
        
        // 中間還有其他單據變更與狀態變更記錄
        
        _tradeRepository.Update(trade);
    }
}