using System;

namespace EmployeeDomain.Models
{
    public class Beneficiary
    {
        protected bool Equals(Beneficiary other)
        {
            return Id.Equals(other.Id) && string.Equals(FirstName, other.FirstName) && string.Equals(MiddleName, other.MiddleName) && string.Equals(LastName, other.LastName) && Cost == other.Cost;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Beneficiary) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (MiddleName != null ? MiddleName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Cost.GetHashCode();
                return hashCode;
            }
        }

        public Guid? Id { get;  set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public decimal Cost { get; set; }
    }
}
