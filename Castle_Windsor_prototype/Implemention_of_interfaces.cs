using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Castle.DynamicProxy;
using Castle.Core;
namespace Castle_Windsor_prototype
{
    public class School : ISchool
    {
        IDepartment dep;
        public School(IDepartment department)
        {
            this.dep = department;
            Console.Out.WriteLine("Create School object");

        }
        public IDepartment department { get; set; }

        public void ToString()
        {
            var str = "print School";
            Console.Out.WriteLine(str);
            department.ToString();
        }
    }
    public class Department : IDepartment
    {

        public Department()
        {
            Console.Out.WriteLine("Create Department object");
        }
        public IEnumerable<ICourse> courses { get; set; }
        public void ToString()
        {
            var str = "print Department";
            Console.Out.WriteLine(str);
            foreach(ICourse c in  courses) {
                c.ToString();
            }
            //courses.First().ToString();
        }
    }
    [Interceptor("GCI")]
    public class Course : ICourse
    {
        public Course(ITeacher te, DayPeriod night)
        {
            Console.Out.Write("Create Course object: ");
            Console.Out.WriteLine(night);


        }
        public ITeacher teacher { get; set; }
        public void ToString()
        {
            var str = "print Course";
            Console.Out.WriteLine(str);
            teacher.ToString();
        }

    }

    public class Course2 : ICourse
    {
        public Course2(ITeacher te, DayPeriod morning)
        {
            Console.Out.Write("Create Course2 object: ");
            Console.Out.WriteLine(morning);


        }
        public ITeacher teacher { get; set; }
        public void ToString()
        {
            var str = "print Course2";
            Console.Out.WriteLine(str);
            teacher.ToString();
        }
    }

    public class Teacher : ITeacher
    {
        public Teacher()
        {
            Console.Out.WriteLine("Create Teacher object");
        }
        public void ToString()
        {
            var str = "print Teacher";
            Console.Out.WriteLine(str);


        }
    }
    public class GraduateCourseInterceptor : IInterceptor
    {


        public void Intercept(IInvocation invocation)
        {

            Console.Out.Write("This is a graduate course: ");

            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Intercept throw an exception: " + e.Message);
            }

        }
    }
}
