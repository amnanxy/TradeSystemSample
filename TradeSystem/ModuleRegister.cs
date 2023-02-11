using Autofac;
using TradeSystem.Repositories;
using TradeSystem.Services.Captures;
using TradeSystem.Services.Refunds;

namespace TradeSystem;

public class ModuleRegister : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TradeRepository>()
            .As<ITradeRepository>()
            .InstancePerLifetimeScope();
        builder.RegisterDecorator<TradeRepositoryCacheDecorator, ITradeRepository>();

        builder.RegisterType<CaptureService>()
            .As<ICaptureService>()
            .InstancePerLifetimeScope();
        builder.RegisterDecorator<CaptureServicePreconditionDecorator, ICaptureService>();

        builder.RegisterType<RefundService>()
            .As<IRefundService>()
            .InstancePerLifetimeScope();
        builder.RegisterDecorator<RefundServicePreconditionDecorator, IRefundService>();
    }
}