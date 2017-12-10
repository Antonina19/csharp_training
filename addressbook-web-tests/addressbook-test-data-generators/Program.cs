using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WebAddressbookTests;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfData = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];

            if (typeOfData == "group")
            {
                List<GroupData> groups = GenerateGroupsList(count);
                if (format == "excel")
                {
                    WriteGroupsExcelFile(groups, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);
                    if (format == "csv")
                    {
                        WriteGroupsCsvFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteGroupsXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        WriteGroupsJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format " + format);
                    }
                    writer.Close();
                }
            }
            else if (typeOfData == "user")
            {
                List<UserData> users = GenerateUsersList(count);
                if (format == "excel")
                {
                    WriteUsersExcelFile(users, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);
                    if (format == "csv")
                    {
                        WriteUsersCsvFile(users, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteUsersXmlFile(users, writer);
                    }
                    else if (format == "json")
                    {
                        WriteUsersJsonFile(users, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format " + format);
                    }
                    writer.Close();
                }
            }
            else
            {
                System.Console.Write("Invalid value args[0] = " + typeOfData +
                    "\r\nPossible values: "
                    + "\r\n<group> = GroupData type; "
                    + "\r\n<user> = UserData type.");
            }
            //writer.Close();
        }



        private static void WriteGroupsExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        private static void WriteUsersExcelFile(List<UserData> users, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (UserData user in users)
            {
                sheet.Cells[row, 1] = user.Firstname;
                sheet.Cells[row, 2] = user.Lastname;
                sheet.Cells[row, 3] = user.Middlename;
                sheet.Cells[row, 4] = user.Nickname;
                sheet.Cells[row, 5] = user.Title;
                sheet.Cells[row, 6] = user.Company;
                sheet.Cells[row, 7] = user.Address;
                sheet.Cells[row, 8] = user.HomePhone;
                sheet.Cells[row, 9] = user.MobilePhone;
                sheet.Cells[row, 10] = user.WorkPhone;
                sheet.Cells[row, 11] = user.Fax;
                sheet.Cells[row, 12] = user.Email;
                sheet.Cells[row, 13] = user.Email2;
                sheet.Cells[row, 14] = user.Email3;
                sheet.Cells[row, 15] = user.Homepage;
                sheet.Cells[row, 16] = user.Address2;
                sheet.Cells[row, 17] = user.Phone2;
                sheet.Cells[row, 18] = user.Notes;
                row++;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
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

        static void WriteGroupsJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteUsersJsonFile(List<UserData> users, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
