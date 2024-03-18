using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        RolebasedContext _db;

        public UserController(RolebasedContext db)
        {
            _db = db; 
        }
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Index()
        {
            var employee = await _db.EmployeeLists.ToListAsync();
            return View(employee);
        }
        [HttpGet]
        public IActionResult Reg()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Reg(TblUser user)
        {
            var useralreadyexsist = await _db.TblUsers.Where(a => a.Email == user.Email).FirstOrDefaultAsync();
            try
            {
                if (useralreadyexsist == null)
                {

                    await _db.TblUsers.AddAsync(user);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    ViewBag.message = "User Already Exsist  try with another email";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(TblUser user)
        {
            var validEmail = await _db.TblUsers.Where(a => a.Email == user.Email).FirstOrDefaultAsync();
            var validPassword = await _db.TblUsers.Where(a => a.Password == user.Password).FirstOrDefaultAsync();

            //fetching

            var userdetail = await _db.TblUsers.Where(a => a.Email == user.Email).FirstOrDefaultAsync();
          

            ///
            if (validEmail != null)
            {
                if (validPassword != null)
                {
                    HttpContext.Session.SetInt32("id", userdetail.Id);
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.message = "Wrong Password";

                }
            }
            else
            {
                ViewBag.message = "Invalid Emailaddress";
            }
            return View();
        }

        public async Task<IActionResult> Details()
        {
            var userid = HttpContext.Session.GetInt32("id");
            var userdetail = await _db.TblUsers.Where(a => a.Id == userid).FirstOrDefaultAsync();
            var assignedRole = await _db.TblUserRoles.Where(a => a.UserId == userdetail.Id).FirstOrDefaultAsync();

            var userrole = await _db.TblRoles.Where(a => a.Id == assignedRole.RoleId).FirstOrDefaultAsync();
            userdetail.Role = userrole.Name;

            ViewBag.id = userdetail.Id;
            ViewBag.name = userdetail.Fname;
            ViewBag.role = userdetail.Role;
            return View();
        }


    }

}
