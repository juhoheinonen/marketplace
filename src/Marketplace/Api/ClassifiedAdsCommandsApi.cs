using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static Marketplace.Contracts.ClassifiedAds;

namespace Marketplace.Api
{
    [Route("/ad")]
    public class ClassifiedAdsCommandsApi : Controller
    {
        private readonly ClassifiedAdsApplicationService _applicationService;

        public ClassifiedAdsCommandsApi(ClassifiedAdsApplicationService applicationService)
        {
            this._applicationService = applicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(V1.Create request)
        {
            await _applicationService.Handle(request);

            return Ok();
        }

        [Route("name")]
        public async Task<IActionResult> Put(V1.SetTitle request)
        {
            await _applicationService.Handle(request);

            return Ok();
        }

        [Route("text")]
        public async Task<IActionResult> Put(V1.UpdateText request)
        {
            await _applicationService.Handle(request);

            return Ok();
        }

        [Route("price")]
        public async Task<IActionResult> Put(V1.UpdatePrice request)
        {
            await _applicationService.Handle(request);

            return Ok();
        }

        [Route("publish")]
        public async Task<IActionResult> Put(V1.RequestToPublish request)
        {
            await _applicationService.Handle(request);

            return Ok();
        }
    }
}