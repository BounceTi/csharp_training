using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System.Xml.Serialization;
using WebAddressbookTests;
using System.Runtime.Serialization;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];

            if (dataType == "groups") {
                List<GroupData> groups = new();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
                WriteToFiles(filename, format, groups);
            } 
            else if (dataType == "contacts")
            {
                List<ContactData> contacts = new();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    {
                        MiddleName = TestBase.GenerateRandomString(10),
                        Address = TestBase.GenerateRandomString(10)
                    });
                }
                WriteToFiles(filename, format, contacts);
            } else
            {
                Console.Out.Write("Unrecognized format of data type" + dataType);
            }
        }

        private static void WriteToFiles<T>(string filename, string format, List<T> data)
        {
            var writer = new StreamWriter(filename);
            if (format == "xml")
            {
                WriteToXmlFile(data, writer);
            }
            else if (format == "json")
            {
                WriteToJsonFile(data, writer);
            }
            else
            {
                Console.Out.Write("Unrecognized format " + format);
            }
            writer.Close();
        }
        private static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new();
            app.Visible = false;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet();

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
            app.Quit();
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        private static void WriteToXmlFile<T>(List<T> data, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<T>)).Serialize(writer, data);
        }
        static void WriteToJsonFile<T>(List<T> data, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(data, Formatting.Indented));
        }
    }
}
