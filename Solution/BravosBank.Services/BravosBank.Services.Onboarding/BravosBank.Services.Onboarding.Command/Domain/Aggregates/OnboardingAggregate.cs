using BravosBank.Shared.EventSourcing.Persistance;
using Ticketing.Common.DomainEvents.Ticket;

namespace BravosBank.Services.Onboarding.Domain.Aggregates
{
    public class OnboardingAggregate : AggregateRoot
    {
        public bool Active { get; set; }

        public OnboardingAggregate()
        {
            
        }
        public OnboardingAggregate(OnboardingCreateCommand command)
        {
            var ticketCreatedEvent = new OnboardingCreatedDomainEvent
            {
                Id = command.Id
            };

            RaiseEvent(ticketCreatedEvent);
        }

        public void Apply(OnboardingCreatedDomainEvent @event)
        {
            _id = @event.Id;
            Active = true;
        }
    }
}
