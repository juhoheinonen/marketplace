using System;
using System.Threading.Tasks;

namespace Marketplace.Api
{
    public class ClassifiedAdsApplicationService : IApplicationService
    {
        private readonly IEntityStore _store;

        public async Task Handle(object command)
        {
            switch (command)
            {
                case Contracts.ClassifiedAds.V1.Create cmd:
                    break;
                default:
                    throw new InvalidOperationException($"The command {command.GetType().FullName} is unknown");
            }
        }
    }
}