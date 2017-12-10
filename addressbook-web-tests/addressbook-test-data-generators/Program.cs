using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            string typeOfData = args[3];
            if (typeOfData == "group")
            {
                List<GroupData> groups = GenerateGroupsList(count);
                if (format == "csv")
                {
                    WriteGroupsCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsXmlFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            }
            else if (typeOfData == "user")
            {
                List<UserData> users = GenerateUsersList(count);
                if (format == "csv")
                {
                    WriteUsersCsvFile(users, writer);
                }
                else if (format == "xml")
                {
                    WriteUsersXmlFile(users, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            }
            else
            {
                System.Console.Write("Invalid value args[3] = " + typeOfData +
                    "\r\nPossible values: "
                    + "\r\n<group> = Groups; "
                    + "\r\n<user> = Users.");
            }
            writer.Close();
        }

        private static List<GroupData> GenerateGroupsList(int count)
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }
            return groups;
        }

        private static List<UserData> GenerateUsersList(int count)
        {
            List<UserData> users = new List<UserData>();
            for (int i = 0; i < count; i++)
            {
                users.Add(new UserData(TestBase.GenerateRandomString(30), TestBase.GenerateRandomString(30))
                {
                    Middlename = TestBase.GenerateRandomString(30),
                    Nickname = TestBase.GenerateRandomString(30),
                    Company = TestBase.GenerateRandomString(30),
                    Title = TestBase.GenerateRandomString(30),
                    Address = TestBase.GenerateRandomString(30),
                    HomePhone = TestBase.GenerateRandomString(30),
                    MobilePhone = TestBase.GenerateRandomString(30),
                    WorkPhone = TestBase.GenerateRandomString(30),
                    Fax = TestBase.GenerateRandomString(30),
                    Email = TestBase.GenerateRandomString(30),
                    Email2 = TestBase.GenerateRandomString(30),
                    Email3 = TestBase.GenerateRandomString(30),
                    Homepage = TestBase.GenerateRandomString(30),
                    Address2 = TestBase.GenerateRandomString(30),
                    Phone2 = TestBase.GenerateRandomString(30),
                    Notes = TestBase.GenerateRandomString(30)
                });
            }
            return users;
        }

        static void WriteGroupsCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteUsersCsvFile(List<UserData> users, StreamWriter writer)
        {
            foreach (UserData user in users)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6},${7},${8},${9},${10},${11},${12},${13},${14},${15},${16},${17}",
                    user.Firstname,
                    user.Lastname,
                    user.Middlename,
                    user.Nickname,
                    user.Company,
                    user.Title,
                    user.Address,
                    user.HomePhone,
                    user.MobilePhone,
                    user.WorkPhone,
                    user.Fax,
                    user.Email,
                    user.Email2,
                    user.Email3,
                    user.Homepage,
                    user.Address2,
                    user.Phone2,
                    user.Notes
                    ));
            }
        }

        static void WriteGroupsXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteUsersXmlFile(List<UserData> users, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<UserData>)).Serialize(writer, users);
        }
    }
}
