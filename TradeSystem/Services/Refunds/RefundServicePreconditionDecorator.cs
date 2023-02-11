using TradeSystem.Models;
using TradeSystem.Repositories;

namespace TradeSystem.Services.Refunds;

public class RefundServicePreconditionDecorator : IRefundService
{
    private readonly IRefundService _refundService;
    private readonly ITradeRepository _tradeRepository;

    public RefundServicePreconditionDecorator(IRefundService refundService, ITradeRepository tradeRepository)
    {
        _refundService = refundService;
        _tradeRepository = tradeRepository;
    }

    public void Handle(int tradeId)
    {
        var trade = _tradeRepository.Get(tradeId);

        if (trade == null)
        {
            throw new Exception();
        }

        if (trade.Status != TradeStatus.Captured)
        {
            throw new InvalidOperationException();
        }
        
        // 後續會用 trade 的資料去拿其他單據資料做檢查

        _refundService.Handle(tradeId);
    }
}