using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class UserData : IEquatable<UserData>, IComparable<UserData>
    {
        private string firstName;
        private string lastName;

        public UserData(string firstname, string lastname)
        {
            this.firstName = firstname;
            this.lastName = lastname;
        }

        public string Firstname
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public bool Equals(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return lastName == other.lastName && firstName == other.firstName;
        }
        public override int GetHashCode()
        {
            return (lastName+firstName).GetHashCode();
        }

        public int CompareTo(UserData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (lastName.CompareTo(other.lastName)!= 0)
            {
                return lastName.CompareTo(other.lastName);
            }
            else if (firstName.CompareTo(other.firstName) != 0)
            {
                return firstName.CompareTo(other.firstName);
            }

            return 0;
        }

        public override string ToString()
        {
            return string.Format("LastName: {0},FirstName: {1}", lastName, firstName);
        }
    }
}
