namespace TradeSystem.Services.Refunds;

public interface IRefundService
{
    void Handle(int tradeId);
}