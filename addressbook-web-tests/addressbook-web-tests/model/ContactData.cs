using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "First Name = " + FirstName + "\n" 
                + "Last Name = " + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName) + LastName.CompareTo(other.LastName);
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }
        public string Nickname { get; set; }
        public object Photo { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string TelephoneHome { get; set; }
        public string TelephoneMobile { get; set; }
        public string TelephoneWork { get; set; }
        public string TelephoneFax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string HomePage { get; set; }
        public string Birthday { get; set; }
        public string Anniversary { get; set; }
        public string Group { get; set; }
        public string SecondaryAddress { get; set; }
        public string SecondaryHome { get; set; }
        public string Notes { get; set; }
        public string Id { get; set; }
    }
}
