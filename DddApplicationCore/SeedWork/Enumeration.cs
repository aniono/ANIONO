using System;
using System.Collections.Generic;
using System.Text;

namespace ANIONO.DddCommon.DddApplicationCore.SeedWork
{
    public abstract class Enumeration : IComparable<Enumeration>
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public Enumeration(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public static int AbsoluteDifference(Enumeration a, Enumeration b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException();

            return Math.Abs(a.Id - b.Id);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Enumeration otherValue))
                return false;

            return Id.Equals(otherValue.Id) && GetType().Equals(obj.GetType());
        }

        public override int GetHashCode() => this.Id.GetHashCode();

        public override string ToString() => this.Name;

        public int CompareTo(Enumeration other)
        {
            if (other == null)
                return this.Id;

            return this.Id.CompareTo(other.Id);
        }
    }
}