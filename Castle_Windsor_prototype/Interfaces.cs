using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castle_Windsor_prototype
{
    public  interface ISchool
    {
        IDepartment department{get;set;}
       
        void ToString();
    }
    public interface IDepartment
    {
       IEnumerable<ICourse> courses { get; set; }
        void ToString();
    }
    public interface ICourse
    {
        ITeacher teacher { get; set; }
        void ToString();
    }
    public interface ITeacher
    {
        void ToString();

    }
}
