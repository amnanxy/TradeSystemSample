using TradeSystem.Models;
using TradeSystem.Repositories;

namespace TradeSystem.Services.Captures;

public class CaptureServicePreconditionDecorator : ICaptureService
{
    private readonly ICaptureService _captureService;
    private readonly ITradeRepository _tradeRepository;

    public CaptureServicePreconditionDecorator(ICaptureService captureService, ITradeRepository tradeRepository)
    {
        _captureService = captureService;
        _tradeRepository = tradeRepository;
    }

    public void Handle(int tradeId)
    {
        var trade = _tradeRepository.Get(tradeId);

        if (trade == null)
        {
            throw new Exception();
        }

        if (trade.Status != TradeStatus.Payed)
        {
            throw new InvalidOperationException();
        }

        // 後續會用 trade 的資料去拿其他單據資料做檢查

        _captureService.Handle(tradeId);
    }
}