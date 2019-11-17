using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XML
{
    class XmlDemo
    {
        public static void Main()
        {
            XDocument document = XDocument.Load("Input_students.xml");

            List<Student> resultStudents = new List<Student>();

            XElement studentsElement = document.Element("Students");
            IEnumerable<XElement> students = studentsElement.Elements("Student");
            foreach (var studentElement in students)
            {

                Student student = new Student();
                resultStudents.Add(student);
                student.FirstName = studentElement.Attribute("firstName").Value;
                student.LastName = studentElement.Attribute("lastName").Value;
                student.Email = studentElement.Element("Email").Value;
                student.PhoneNumber = studentElement.Element("PhoneNumber").Value;
                student.BirthDate = GetBirthDate(studentElement);
                student.ExtraData = GetExtraData(studentElement);
                student.Courses = studentElement.Element("Courses").Elements("Courses").Select(p => p.Value).ToList();

                resultStudents.Add(student);
            }
            resultStudents.Add(new Student
            {
                FirstName = "Name",
                LastName = "LastName",
                PhoneNumber = "911",
                BirthDate = new DateTime(1111, 1, 1),
                Email = "hosdf@gmail.com",
                ExtraData = new Dictionary<string, string> { { "testkey", "testval" } },
                Courses = new List<string> { "Testsadas" }
            });


            foreach (var student in resultStudents)
            {
                Console.WriteLine($"{student.BirthDate} + {student.FirstName}");
            }
            SaveTofFile(resultStudents);
        }

        private static Dictionary<string, string> GetExtraData(XElement studentElement)
        {
            Dictionary<string, string> extraDataDictionary = new Dictionary<string, string>();
            var extraDateCol = studentElement.Element("ExtraData");
            var extraDateNodes = extraDateCol.Elements("ExtraDataElement");
            foreach (var extraDateElement in extraDateNodes)
            {
                var atribute = extraDateElement.Attribute("name");
                extraDataDictionary.Add(atribute.Value, extraDateElement.Value);
            }
            return extraDataDictionary;
        }

        private static DateTime GetBirthDate(XElement studentElement)
        {
            if (studentElement == null)
                throw new ArgumentNullException("");
            string stringDate = studentElement.Element("BirthDate").Value;
            return DateTime.ParseExact(stringDate, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }

        private static void SaveTofFile(List<Student> resultstudent)
        {
            XDocument xDocument = new XDocument();
            XElement studentsElement = new XElement("Students");
            foreach (var student in resultstudent)
            {
                XElement studentElement = new XElement("Student", new XAttribute("firstName", student.FirstName), new XAttribute("lastName", student.LastName));
                studentElement.Add(new XElement("BirthDate", student.BirthDate));
                studentElement.Add(new XElement("Email", student.BirthDate.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture)));
                studentElement.Add(new XElement("PhoneNumber", student.PhoneNumber));
                XElement extradataelement = new XElement("ExtraData");
                foreach (var extraData in student.ExtraData)
                {
                    extradataelement.Add(new XElement("ExtraDataElement", new XAttribute("name", extraData.Key), extraData.Value));
                }
                studentElement.Add(new XElement("ExtraData", extradataelement));
                studentsElement.Add(studentElement);
            }
            xDocument.Add(studentsElement);
            xDocument.Save("student_output.xml");
        }
    }
    internal class Student
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Email { get; internal set; }
        public DateTime BirthDate { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public Dictionary<string, string> ExtraData { get; internal set; }
        public List<string> Courses { get; internal set; }
    }
}
