using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using WebAddressbookTests;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];
            string dataType = args[3];
            StreamWriter writer = new StreamWriter(filename);

            if (dataType == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });
                }
                if (format == "excel")
                {
                    WriteGroupsToExcelfile(groups, filename);
                }
                else
                {
                    if (format == "csv")
                    {
                        WriteGroupsToCSVfile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteGroupsToXMLfile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        WriteGroupsToJsonfile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognize format" + format);
                    }
                }
            }
            else if (dataType == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                    {
                        LastName = TestBase.GenerateRandomString(20)
                    });
                }
                if (format == "excel")
                {
                    WriteContactsToExcelfile(contacts, filename);
                }
                else
                {
                    if (format == "csv")
                    {
                        WriteContactsToCSVfile(contacts, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteContactsToXMLfile(contacts, writer);
                    }
                    else if (format == "json")
                    {
                        WriteContactsToJsonfile(contacts, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognize format" + format);
                    }
                }
            }
            else
            {
                Console.WriteLine("Unrecognized data type " + dataType + "\n Use: groups or contacts");
            }
            writer.Close();
}

        static void WriteContactsToJsonfile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteContactsToXMLfile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void WriteContactsToCSVfile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1}",
                    contact.LastName,
                    contact.FirstName));
            }
        }

        static void WriteContactsToExcelfile(List<ContactData> contacts, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet();

            int row = 0;
            foreach (ContactData contact in contacts)
            {
                sheet.Cells[row, 1] = contact.FirstName;
                sheet.Cells[row, 2] = contact.LastName;
                row++;
            }
            string fullpath = (Path.Combine(Directory.GetCurrentDirectory(), filename));
            File.Delete(fullpath);
            wb.SaveAs(fullpath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void WriteGroupsToExcelfile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet();

            int row = 0;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row,1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row ++;
            }
            string fullpath = (Path.Combine(Directory.GetCurrentDirectory(), filename));
            File.Delete(fullpath);
            wb.SaveAs(fullpath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void WriteGroupsToCSVfile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name,
                    group.Header,
                    group.Footer));
            } 
        }
        static void WriteGroupsToXMLfile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void WriteGroupsToJsonfile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

    }
}