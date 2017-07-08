using Fibon.Api.Repository;
using Fibon.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System.Threading.Tasks;

namespace Fibon.Api.Controllers
{
    [Route("[controller]")]
    public class FibonacciController : Controller
    {
        private readonly IRepository _repository;
        private readonly IBusClient _busClient;


        public FibonacciController(IRepository repository, IBusClient busClient)
        {
            _repository = repository;
            _busClient = busClient ;
        }

        [HttpGet("{number}")]
        public IActionResult Get(int number)
        {
            int? result = _repository.Get(number);
            if(result.HasValue)
            {
                return Content(result.Value.ToString());
            }
            return Content("Not ready...");
        }

        [HttpPost("{number}")]
        public async Task<IActionResult> Post(int number)
        {
            int? result = _repository.Get(number);
            if(!result.HasValue)
            {
                await _busClient.PublishAsync(new CalculateValueCommand { Number = number });
            }
            return Accepted($"fibonacci/{number}", null);
        }

    }
}
