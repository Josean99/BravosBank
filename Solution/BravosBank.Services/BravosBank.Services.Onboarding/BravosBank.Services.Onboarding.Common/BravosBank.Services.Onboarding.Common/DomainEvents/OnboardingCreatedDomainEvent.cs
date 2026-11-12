using BravosBank.Shared.EventSourcing.Communications.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Common.DomainEvents.Ticket
{
    public class OnboardingCreatedDomainEvent : DomainEvent
    {

        public OnboardingCreatedDomainEvent() : base(nameof(OnboardingCreatedDomainEvent))
        {

        }
    }
}
