using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;
using System.Data;
namespace BAL
{
    public class BussinessLogic
    {

        public EmployEntity db = new EmployEntity();

        public List<EmployeeInfo> GetAllEmployees()
        {
            try
            {
                return db.EmployeeInfoes.ToList();
            }
            catch
            {
                throw;
            }
        }


        public void saveEmploy(EmployeeInfo employ)
        {
            try
            {
                db.EmployeeInfoes.Add(employ);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }


        public EmployeeInfo getUpdateData(int id)
        {
            try
            {
                return db.EmployeeInfoes.SingleOrDefault(i => i.EmpNo == id);
            }
            catch
            {
                throw;
            }
        }

        public void updateData(EmployeeInfo info)
        {
            try
            {
               EmployeeInfo info1 = db.EmployeeInfoes.Find(info.EmpNo);
                info1.EmpName = info.EmpName;
                info1.Designation = info.Designation;
                info1.DeptName = info.DeptName;
                info1.Salary = info.Salary;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Entry(info1).State = System.Data.Entity.EntityState.Modified;
                db.Configuration.ValidateOnSaveEnabled = true;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void delete(int EmpNo)
        { 
            try
            { 
                db.EmployeeInfoes.Remove(db.EmployeeInfoes.Find(EmpNo));
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

    }
}
