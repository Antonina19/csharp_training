using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class UserData : IEquatable<UserData>, IComparable<UserData>
    {


        public UserData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }
 
        public string Lastname { get; set; }

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
            return Lastname == other.Lastname && Firstname == other.Firstname;
        }
        public override int GetHashCode()
        {
            return (Lastname + Firstname).GetHashCode();
        }

        public int CompareTo(UserData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Lastname.CompareTo(other.Lastname) != 0)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            else if (Firstname.CompareTo(other.Firstname) != 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }

            return 0;
        }

        public override string ToString()
        {
            return string.Format("LastName: {0},FirstName: {1}", Lastname, Firstname);
        }

        public string Id { get; set; }
    }
}
