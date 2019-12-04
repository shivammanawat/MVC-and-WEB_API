using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API
{
    public class EmployModel
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
    }
}