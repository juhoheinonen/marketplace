using System.Threading.Tasks;

namespace Marketplace.Framework
{
    public interface IApplicationService {
        public Task Handle(object command);
    }
}