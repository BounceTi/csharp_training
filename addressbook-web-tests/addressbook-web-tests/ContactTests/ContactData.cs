using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string firstName;
        private string lastName;
        private string middleName = "";
        private string nickname = "";
        private object photo;
        private string title = "";
        private string company = "";
        private string address = "";
        private string telephoneHome = "";
        private string telephoneMobile = "";
        private string telephoneWork = "";
        private string telephoneFax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homePage = "";
        private string birthday = "";
        private string anniversary = "";
        private string group = "";
        private string secondaryAddress = "";
        private string secondaryHome = "";
        private string notes = "";

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName 
        { 
            get { return firstName; } 
            set { firstName = value;} 
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string MiddleName { get => middleName; set => middleName = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public object Photo { get => photo; set => photo = value; }
        public string Title { get => title; set => title = value; }
        public string Company { get => company; set => company = value; }
        public string Address { get => address; set => address = value; }
        public string TelephoneHome { get => telephoneHome; set => telephoneHome = value; }
        public string TelephoneMobile { get => telephoneMobile; set => telephoneMobile = value; }
        public string TelephoneWork { get => telephoneWork; set => telephoneWork = value; }
        public string TelephoneFax { get => telephoneFax; set => telephoneFax = value; }
        public string Email { get => email; set => email = value; }
        public string Email2 { get => email2; set => email2 = value; }
        public string Email3 { get => email3; set => email3 = value; }
        public string HomePage { get => homePage; set => homePage = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public string Anniversary { get => anniversary; set => anniversary = value; }
        public string Group { get => group; set => group = value; }
        public string SecondaryAddress { get => secondaryAddress; set => secondaryAddress = value; }
        public string SecondaryHome { get => secondaryHome; set => secondaryHome = value; }
        public string Notes { get => notes; set => notes = value; }
    }
}
