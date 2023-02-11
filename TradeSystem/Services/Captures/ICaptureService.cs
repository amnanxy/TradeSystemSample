namespace TradeSystem.Services.Captures;

public interface ICaptureService
{
    void Handle(int tradeId);
}