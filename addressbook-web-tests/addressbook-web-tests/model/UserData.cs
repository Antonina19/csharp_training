using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class UserData : IEquatable<UserData>, IComparable<UserData>
    {
        private string allEmails;
        private string allPhones;
        private string userInfo;


        public UserData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

        public string AllPhones
        {
            get {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone) + CleanUpPhone(Phone2).Trim();
                }
            }
            set {
                allPhones = value;
            }
        }

        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone,"[ -()]","") + "\r\n";
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[ -()]", "") + "\r\n";
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
            if (Object.Equals(this.Lastname, other.Lastname))
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);

        }

        public override string ToString()
        {
            return "firstname=" + Firstname +
                "\nmiddlename=" + Middlename +
                "\nlastname=" + Lastname +
                "\nnickname=" + Nickname +
                "\ncompany=" + Company +
                "\ntitle=" + Title +
                "\naddress=" + Address +
                "\nhomePhone=" + HomePhone +
                "\nmobilePhone=" + MobilePhone +
                "\nworkPhone=" + WorkPhone +
                "\nfax=" + Fax +
                "\nemail=" + Email +
                "\nemail2=" + Email2 +
                "\nemail3=" + Email3 +
                "\nhomepage=" + Homepage +
                "\naddress2=" + Address2 +
                "\nphone2= " + Phone2 +
                "\nnotes=" + Notes;
        }

        public string Id { get; set; }

        public string FIO(string firstname, string middlename, string lastname)
        {
            string buff = "";
            if (firstname !=null && firstname != "")
            {
                buff = Firstname + " ";
            }
            if (middlename != null && middlename != "")
            {
                buff = buff + Middlename + " ";
            }
            if (lastname != null && lastname != "")
            {
                buff = buff + Lastname + " ";
            }
            return buff.Trim();
        }

        public string PhonesList(string homePhone, string mobilePhone, string workPhone, string fax)
        {
            string buff = "";
            if (homePhone != null && homePhone != "")
            {
                buff = buff + "H: " + FinishString(HomePhone);
            }
            if (mobilePhone != null && mobilePhone != "")
            {
                buff = buff + "M: " + FinishString(MobilePhone);
            }
            if (workPhone != null && workPhone != "")
            {
                buff = buff + "W: " + FinishString(WorkPhone);
            }
            if (fax != null && fax != "")
            {
                buff = buff + "F: " + FinishString(Fax);
            }
            return buff.Trim();
        }

        public string EmailList(string email, string email2, string email3, string homepage)
        {
            string buff = "";
            if (email != null && email != "")
            {
                buff = buff + FinishString(email);
            }
            if (email2 != null && email2 != "")
            {
                buff = buff + FinishString(email2);
            }
            if (email3 != null && email3 != "")
            {
                buff = buff + FinishString(email3);
            }
            if (homepage != null && homepage != "")
            {
                buff = buff + FinishString(StringHomepage(homepage));
            }
            return buff.Trim();
        }

        private string StringHomepage(string homepage)
        {
            if (homepage == null || homepage == "")
            {
                return "";
            }
            return "Homepage:" + "\r\n" + homepage;
        }

        public string StringPhone2(string phone2)
        {
            if (phone2 == null || phone2 == "")
            {
                return "";
            }
            return "P: " + Phone2;

        }

        public string FinishString(string entry)
        {
            if (entry == null || entry == "")
            {
                return "";
            }
            return entry + "\r\n";
        }

        public string StartString(string entry)
        {
            if (entry == null || entry == "")
            {
                return "";
            }
            return  "\r\n" + entry;
        }

        public string UserInfo
        {
            get
            {
                if (userInfo != null)
                {
                    return userInfo;
                }
                else
                {
                    return (FinishString(FinishString(UserInfoList(Firstname, Middlename, Lastname, Nickname, Title, Company, Address)))
                        + FinishString(FinishString(PhonesList(HomePhone, MobilePhone, WorkPhone, Fax)))
                        + FinishString(FinishString(EmailList(Email, Email2, Email3, Homepage)))
                        + StartString(Address2)
                        + FinishString(StartString(StartString(StringPhone2(Phone2))))
                        + StartString(Notes)).Trim();
                }
            }
            set
            {
                userInfo = value;
            }
        }

        private string UserInfoList(string firstname, string middlename, string lastname, string nickname, string title, string company, string address)
        {
            return FinishString(FIO(firstname, middlename, lastname))
                + FinishString(nickname)
                + FinishString(title)
                + FinishString(company)
                + FinishString(address).Trim();
        }
    }
}
