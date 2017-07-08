using Fibon.Api.Repository;
using Fibon.Messages.Events;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fibon.Api.Handlers
{
    public class ValueCalculatedEventHandler : IEventHandler<ValueCalculatedEvent>
    {

        private readonly IRepository _repository;
        private readonly IBusClient _busClient;

        public ValueCalculatedEventHandler(IRepository repository, IBusClient busClient)
        {
            _busClient = busClient;
            _repository = repository;
        }

        public async Task HandleAsync(ValueCalculatedEvent @event)
        {
            await Task.Run(() => { _repository.Insert(@event.Number, @event.Value); } );
        }
    }
}
