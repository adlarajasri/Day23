using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQuery
{
    public class Program
    {
        public static void Main()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "Pavan", Age = 22, StandardID= 1 } ,
                new Student() { StudentID = 2, StudentName = "Raji",  Age = 21, StandardID = 3 } ,
                new Student() { StudentID = 3, StudentName = "Mokesh", Age = 0, StandardID = 4 } ,
                new Student() { StudentID = 4, StudentName = "Chubby" , Age = 21, StandardID = 2 } ,
                new Student() { StudentID = 5, StudentName = "HC" , Age = 22, StandardID=3 } ,
            };

            var studentsGroupByStandard = from s in studentList
                                          group s by s.StandardID into sg
                                          orderby sg.Key
                                          select new { sg.Key, sg };


            foreach (var group in studentsGroupByStandard)
            {
                Console.WriteLine("StandardID {0}:", group.Key);

                group.sg.ToList().ForEach(st => Console.WriteLine(st.StudentName));
            }
        }
    }
}
public class Student
{

    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }
    public int StandardID { get; set; }
}


