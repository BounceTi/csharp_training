using System;

namespace addressbook_tests_white
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        public ContactData() { }
        public int CompareTo(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            if (LastName.CompareTo(other.LastName) != 0)
            {
                return LastName.CompareTo(other.LastName);
            }
            else
            {
                return FirstName.CompareTo(other.FirstName);
            }
        }

        public bool Equals(ContactData other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName
                && LastName == other.LastName;
        }
        public override string ToString()
        {
            return "First Name = " + FirstName + " \n"
                + " Last Name = " + LastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone1 { get; set; }
        public string Email1 { get; set; }
    }
}
