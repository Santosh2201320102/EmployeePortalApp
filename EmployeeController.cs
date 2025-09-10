using AspCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCrud.Controllers
{
    public class EmployeeController : Controller
    {
        //create instance of database
        private readonly EmployeeDbContext _Db;
        //create constructor 
        public EmployeeController(EmployeeDbContext context)
        {
            this._Db = context;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _Db.Employees.ToListAsync();      ///employee list ko db se get kiya aur employees var main store kiya
            return View(employees);
        }
        public async Task<IActionResult> Create() //get request
        {
            return View();
        }
        [HttpPost]
        //now we can also do the post request
        public async Task<IActionResult> Create(Employee Obj)
        {
            if(ModelState.IsValid)
            {
                _Db.Add(Obj);
                await _Db.SaveChangesAsync();         //The data will be save in the database (from add employee)
                TempData["Success Message"] = "Employee added Successfully !";
                return RedirectToAction("Index");     //redirect to employee list
            }
            return View(Obj);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _Db.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id  , Employee obj)
        {
            if(id != obj.Emp_Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _Db.Update(obj);
                await _Db.SaveChangesAsync();
                TempData["Success Message"] = "Employee updated Successfully !";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _Db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _Db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee); // Show confirmation page
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _Db.Employees.FindAsync(id);
            if (employee != null)
            {
                _Db.Employees.Remove(employee);
                await _Db.SaveChangesAsync();
                TempData["Success Message"] = "Employee deleted Successfully !";
                
            }
            else
            {
                TempData["Error Message"] = "Employee Not Found !";
               
            }
                return RedirectToAction("Index");
        }
        


    }
}
