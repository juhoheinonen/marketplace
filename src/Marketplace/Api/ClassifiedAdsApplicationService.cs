using System;
using System.Threading.Tasks;
using Marketplace.Domain;
using Marketplace.Framework;

namespace Marketplace.Api
{
    public class ClassifiedAdsApplicationService : IApplicationService
    {
        private readonly IEntityStore _store;
        private ICurrencyLookup _currencyLookup;

        public async Task Handle(object command)
        {
            ClassifiedAd classifiedAd;
            switch (command)
            {
                case Contracts.ClassifiedAds.V1.Create cmd:
                    if (await _store.Exists<ClassifiedAd>(cmd.Id.ToString()))
                    {
                        throw new InvalidOperationException($"Entity with id {cmd.Id} already exists.");
                    }
                    classifiedAd = new ClassifiedAd(new ClassifiedAdId(cmd.Id), new UserId(cmd.OwnerId));
                    await _store.Save(classifiedAd);
                    break;
                default:
                    throw new InvalidOperationException($"The command {command.GetType().FullName} is unknown");
            }
        }
    }
}