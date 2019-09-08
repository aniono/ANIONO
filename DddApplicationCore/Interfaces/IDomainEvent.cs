using MediatR;
using System.Collections.Generic;

namespace ANIONO.DddCommon.DddApplicationCore.Interfaces
{
    public interface IDomainEvent
    {
        IReadOnlyCollection<INotification> DomainEvents { get; }

        void AddDomainEvent(INotification eventItem);

        void RemoveDomainEvent(INotification eventItem);

        void ClearDomainEvents();
    }
}