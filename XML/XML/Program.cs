using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    class Program
    {
        public class Student
        {
            private string name { get; set; }
            private string surname { get; set; }
            private int age { get; set; }
            public Student() { }
            public Student(string name, string surname, int age)
            {
                this.name = name;
                this.surname = surname;
                this.age = age;
            }
        }
        public class Group
        {
            private int numberOfGroup { get; set; }
            private List<Student> students { get; set; }
            public Group() { }
            public Group(int numberOfGroup, List<Student> students)
            {
                this.numberOfGroup = numberOfGroup;
                this.students = students;
            }
        }
        static void Main(string[] args)
        {
            Student student = new Student("Andrew", "Pasternak", 19);
            Student student1 = new Student("Katherine", "Soloiko", 24);

            List<Student> students = new List<Student>() { student, student1 };

            Group group = new Group(25, students);


        }
    }
}
