using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class UserCreationTests : AuthTestBase
    {
        public static IEnumerable<UserData> RandomUserDataProvider()
        {
            List<UserData> users = new List<UserData>();
            for (int i = 0; i < 5; i++)
            {
                users.Add(new UserData(GenerateRandomString(30), GenerateRandomString(30))
                {
                   Middlename = GenerateRandomString(30),
                   Nickname = GenerateRandomString(30),
                   Company = GenerateRandomString(30),
                   Title  = GenerateRandomString(30),
                   Address = GenerateRandomString(30),
                   HomePhone = GenerateRandomString(30),
                   MobilePhone = GenerateRandomString(30),
                   WorkPhone = GenerateRandomString(30),
                   Fax = GenerateRandomString(30),
                   Email = GenerateRandomString(30),
                   Email2 = GenerateRandomString(30),
                   Email3 = GenerateRandomString(30),
                   Homepage = GenerateRandomString(30),
                   Address2 = GenerateRandomString(30),
                   Phone2 = GenerateRandomString(30),
                   Notes = GenerateRandomString(30)
                });
            }

            return users;

        }

        public static IEnumerable<UserData> UserDataFromCsvFile()
        {
            List<UserData> users = new List<UserData>();
            string[] lines = File.ReadAllLines(@"users.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                users.Add(new UserData(parts[0], parts[1])
                {
                    Middlename = parts[2],
                    Nickname = parts[3],
                    Company = parts[4],
                    Title = parts[5],
                    Address = parts[6],
                    HomePhone = parts[7],
                    MobilePhone = parts[8],
                    WorkPhone = parts[9],
                    Fax = parts[10],
                    Email = parts[11],
                    Email2 = parts[12],
                    Email3 = parts[13],
                    Homepage = parts[14],
                    Address2 = parts[15],
                    Phone2 = parts[16],
                    Notes = parts[17]
                });
            }
            return users;
        }

        public static IEnumerable<UserData> UserDataFromXmlFile()
        {
           // List<UserData> groups = new List<UserData>();
            return (List<UserData>)
                new XmlSerializer(typeof(List<UserData>))
                .Deserialize(new StreamReader(@"users.xml"));
        }

        public static IEnumerable<UserData> UserDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<UserData>>(
                File.ReadAllText(@"users.json"));
        }

        public static IEnumerable<UserData> UserDataFromExcelFile()
        {
            List<UserData> users = new List<UserData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"users.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                users.Add(new UserData()
                {
                    Firstname = range.Cells[i, 1].Value,
                    Lastname = range.Cells[i, 2].Value,
                    Middlename = range.Cells[i, 3].Value,
                    Nickname = range.Cells[i, 4].Value,
                    Company = range.Cells[i, 5].Value,
                    Title = range.Cells[i, 6].Value,
                    Address = range.Cells[i, 7].Value,
                    HomePhone = range.Cells[i, 8].Value,
                    MobilePhone = range.Cells[i, 9].Value,
                    WorkPhone = range.Cells[i, 10].Value,
                    Fax = range.Cells[i, 11].Value,
                    Email = range.Cells[i, 12].Value,
                    Email2 = range.Cells[i, 13].Value,
                    Email3 = range.Cells[i, 14].Value,
                    Homepage = range.Cells[i, 15].Value,
                    Address2 = range.Cells[i, 16].Value,
                    Phone2 = range.Cells[i, 17].Value,
                    Notes = range.Cells[i, 18].Value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return users;
        }

        [Test, TestCaseSource("UserDataFromExcelFile")] //UserDataFromCsvFile
        public void UserCreationTest(UserData user)
        {
            List<UserData> oldUsers = app.Users.GetUserList();

            app.Users.Create(user);

            Assert.AreEqual(oldUsers.Count + 1, app.Users.GetUserCount());

            List<UserData> newUsers = app.Users.GetUserList();
            oldUsers.Add(user);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);
        }
    }
}

