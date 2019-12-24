using MediatR;
using System;
using System.Collections.Generic;
using ANIONO.DddCommon.DddApplicationCore.Interfaces;

namespace ANIONO.DddCommon.DddApplicationCore.SeedWork
{
    public class Entity<T> : IDomainEvent where T : IEquatable<T>
    {
        private int? _requestedHashCode;
        private T _Id;

        public virtual T Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

        public bool IsTransient()
        {
            return this.Id.Equals(default);
        }

        public Entity<T> GetCopy()
        {
            return MemberwiseClone() as Entity<T>;
        }

        public Entity<T> GetCopyOverrideId(T newId)
        {
            var copy = GetCopy();
            copy.Id = newId;

            return copy;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<T>))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity<T> item = (Entity<T>)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }        

        public static bool operator ==(Entity<T> left, Entity<T> right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity<T> left, Entity<T> right)
        {
            return !(left == right);
        }
        
        #region Domain Events
        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
        #endregion
    }
}
