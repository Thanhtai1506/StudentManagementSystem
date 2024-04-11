using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagerSystem.Models;

namespace StudentManagerSystem.Controllers
{
    public class AdminController : Controller
    {
        QuanLiSinhVienContext db = new QuanLiSinhVienContext(); // khong dung cach nay

        public AdminController(QuanLiSinhVienContext _dbContext)
        {
            db = _dbContext; // cach nay moi dung
        }

        public IActionResult StudentAdmin()
        {
             var role = HttpContext.Session.GetString("Role");
            if (role == null || role != "Admin")
            {
                return Redirect("/Home/LoginPage");
            }
            var stds = db.Students.ToList();
            // Truy xuất thông tin từ session
            var username = HttpContext.Session.GetString("Username");
            var fullname = HttpContext.Session.GetString("Fullname");
            var userId = HttpContext.Session.GetString("ID");
            var userRole = HttpContext.Session.GetString("Role");

            // Sử dụng ViewBag để truyền dữ liệu sang view
            ViewBag.Username = username;
            ViewBag.Fullname = fullname;
            ViewBag.UserId = userId;
            ViewBag.UserRole = userRole;

            return View(stds);

        }

        public IActionResult Create()
        {
            // Truy xuất thông tin từ session
            var username = HttpContext.Session.GetString("Username");
            var fullname = HttpContext.Session.GetString("Fullname");
            var userId = HttpContext.Session.GetString("ID");
            var userRole = HttpContext.Session.GetString("Role");

            // Sử dụng ViewBag để truyền dữ liệu sang view
            ViewBag.Username = username;
            ViewBag.Fullname = fullname;
            ViewBag.UserId = userId;
            ViewBag.UserRole = userRole;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student sv)
        {
            // Kiểm tra xem StudentId đã tồn tại trong danh sách AccountId chưa
            if (db.Students.Any(a => a.StudentId == sv.StudentId))
            {
                ModelState.AddModelError("", "StudentId đã tồn tại trong danh sách AccountId.");
                return View(); // Trả về view với model và hiển thị lỗi
            }

            // Gán AccountId = StudentId
            sv.AccountId = sv.StudentId;

            // Tiếp tục thêm sinh viên vào danh sách nếu không có lỗi
            db.Students.Add(sv);
            db.SaveChanges();
            return RedirectToAction("StudentAdmin");
        }


        public IActionResult Edit(string id)
        {
            var sv = db.Students.Find(id);
            return View(sv);
        }
        [HttpPost]

        public IActionResult Edit(Student sv)
        {
            /*  Student usv = db.Students.FirstOrDefault(x => x.StudentId == sv.StudentId);
              usv.StudentId = sv.StudentId;
              usv.Fullname = sv.Fullname;
              usv.Gender = sv.Gender;
              usv.DateOfBirth = sv.DateOfBirth;
              usv.PhoneNumber = sv.PhoneNumber;
              usv.ClassId = sv.ClassId;
              usv.SubjectId = sv.SubjectId;
              usv.AccountId = sv.AccountId;
              usv.Address = sv.Address;*/
            db.Students.Update(sv);
            db.SaveChanges();

            return RedirectToAction("StudentAdmin");
        }
        //////////////
        public IActionResult EditResult(string id)
        {
            var sv = db.Results.Find(id);
            return View(sv);
        }

        [HttpPost]
        public IActionResult EditResult(Result rs)
        {
            /*  Student usv = db.Students.FirstOrDefault(x => x.StudentId == sv.StudentId);
              usv.StudentId = sv.StudentId;
              usv.Fullname = sv.Fullname;
              usv.Gender = sv.Gender;
              usv.DateOfBirth = sv.DateOfBirth;
              usv.PhoneNumber = sv.PhoneNumber;
              usv.ClassId = sv.ClassId;
              usv.SubjectId = sv.SubjectId;
              usv.AccountId = sv.AccountId;
              usv.Address = sv.Address;*/
            db.Results.Update(rs);
            db.SaveChanges();

            return RedirectToAction("StudentAdmin");
        }
        /////////
        public IActionResult EditSubject(string id)
        {
            var sb = db.Subjects.Find(id);
            return View(sb);
        }

        [HttpPost]
        public IActionResult EditSubject(Subject sb)
        {
            /*  Student usv = db.Students.FirstOrDefault(x => x.StudentId == sv.StudentId);
              usv.StudentId = sv.StudentId;
              usv.Fullname = sv.Fullname;
              usv.Gender = sv.Gender;
              usv.DateOfBirth = sv.DateOfBirth;
              usv.PhoneNumber = sv.PhoneNumber;
              usv.ClassId = sv.ClassId;
              usv.SubjectId = sv.SubjectId;
              usv.AccountId = sv.AccountId;
              usv.Address = sv.Address;*/
            db.Subjects.Update(sb);
            db.SaveChanges();

            return RedirectToAction("StudentAdmin");
        }
        //////////////

        public IActionResult EditClass(string id)
        {
            var cl = db.Classes.Find(id);
            return View(cl);
        }

        [HttpPost]
        public IActionResult EditClass(Class cl)
        {
            /*  Student usv = db.Students.FirstOrDefault(x => x.StudentId == sv.StudentId);
              usv.StudentId = sv.StudentId;
              usv.Fullname = sv.Fullname;
              usv.Gender = sv.Gender;
              usv.DateOfBirth = sv.DateOfBirth;
              usv.PhoneNumber = sv.PhoneNumber;
              usv.ClassId = sv.ClassId;
              usv.SubjectId = sv.SubjectId;
              usv.AccountId = sv.AccountId;
              usv.Address = sv.Address;*/
            db.Classes.Update(cl);
            db.SaveChanges();

            return RedirectToAction("StudentAdmin");
        }

        //////////////////
        public IActionResult EditTest(string id)
        {
            var tt = db.Tests.Find(id);
            return View(tt);
        }

        [HttpPost]
        public IActionResult EditTest(Test tt)
        {
            /*  Student usv = db.Students.FirstOrDefault(x => x.StudentId == sv.StudentId);
              usv.StudentId = sv.StudentId;
              usv.Fullname = sv.Fullname;
              usv.Gender = sv.Gender;
              usv.DateOfBirth = sv.DateOfBirth;
              usv.PhoneNumber = sv.PhoneNumber;
              usv.ClassId = sv.ClassId;
              usv.SubjectId = sv.SubjectId;
              usv.AccountId = sv.AccountId;
              usv.Address = sv.Address;*/
            db.Tests.Update(tt);
            db.SaveChanges();

            return RedirectToAction("StudentAdmin");
        }

        ///////
        public IActionResult EditInstructor(string id)
        {
            var ir = db.Instructors.Find(id);
            return View(ir);
        }

        [HttpPost]
        public IActionResult EditInstructor(Instructor ir)
        {
            /*  Student usv = db.Students.FirstOrDefault(x => x.StudentId == sv.StudentId);
              usv.StudentId = sv.StudentId;
              usv.Fullname = sv.Fullname;
              usv.Gender = sv.Gender;
              usv.DateOfBirth = sv.DateOfBirth;
              usv.PhoneNumber = sv.PhoneNumber;
              usv.ClassId = sv.ClassId;
              usv.SubjectId = sv.SubjectId;
              usv.AccountId = sv.AccountId;
              usv.Address = sv.Address;*/
            db.Instructors.Update(ir);
            db.SaveChanges();

            return RedirectToAction("StudentAdmin");
        }
        /////////////////
   
        [HttpPost]

        [HttpPost]
        public ActionResult Delete(string id, string type)
        {
            if (id == null || type == null)
            {
                return Json(new { success = false });
            }

            switch (type.ToLower())
            {
                case "student":
                    return DeleteStudent(id);
                case "subject":
                    return DeleteSubject(id);
                case "class":
                    return DeleteClass(id);
                case "result":
                    return DeleteResult(id);
                default:
                    return Json(new { success = false });
            }
        }

        private ActionResult DeleteStudent(string id)
        {
            var student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        private ActionResult DeleteSubject(string id)
        {
            var subject = db.Subjects.Find(id);
            if (subject != null)
            {
                db.Subjects.Remove(subject);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        private ActionResult DeleteClass(string id)
        {
            var classObj = db.Classes.Find(id);
            if (classObj != null)
            {
                db.Classes.Remove(classObj);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        private ActionResult DeleteResult(string id)
        {
            var result = db.Results.Find(id);
            if (result != null)
            {
                db.Results.Remove(result);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public IActionResult Account()
        {
            // Truy xuất thông tin từ session
            var username = HttpContext.Session.GetString("Username");
            var fullname = HttpContext.Session.GetString("Fullname");
            var userId = HttpContext.Session.GetString("ID");
            var userRole = HttpContext.Session.GetString("Role");

            // Sử dụng ViewBag để truyền dữ liệu sang view
            ViewBag.Username = username;
            ViewBag.Fullname = fullname;
            ViewBag.UserId = userId;
            ViewBag.UserRole = userRole;
            var accounts = db.Accounts.ToList(); 
            return View(accounts); 
        }

        public IActionResult Test()
        {
            // Truy xuất thông tin từ session
            var username = HttpContext.Session.GetString("Username");
            var fullname = HttpContext.Session.GetString("Fullname");
            var userId = HttpContext.Session.GetString("ID");
            var userRole = HttpContext.Session.GetString("Role");

            // Sử dụng ViewBag để truyền dữ liệu sang view
            ViewBag.Username = username;
            ViewBag.Fullname = fullname;
            ViewBag.UserId = userId;
            ViewBag.UserRole = userRole;
            var tests = db.Tests.ToList(); 
            return View(tests); }
        public IActionResult Instructor()
        {
            // Truy xuất thông tin từ session
            var username = HttpContext.Session.GetString("Username");
            var fullname = HttpContext.Session.GetString("Fullname");
            var userId = HttpContext.Session.GetString("ID");
            var userRole = HttpContext.Session.GetString("Role");

            // Sử dụng ViewBag để truyền dữ liệu sang view
            ViewBag.Username = username;
            ViewBag.Fullname = fullname;
            ViewBag.UserId = userId;
            ViewBag.UserRole = userRole;
            var instructors = db.Instructors.ToList(); 
            return View(instructors);
        }
        public IActionResult Class()
        {
            // Truy xuất thông tin từ session
            var username = HttpContext.Session.GetString("Username");
            var fullname = HttpContext.Session.GetString("Fullname");
            var userId = HttpContext.Session.GetString("ID");
            var userRole = HttpContext.Session.GetString("Role");

            // Sử dụng ViewBag để truyền dữ liệu sang view
            ViewBag.Username = username;
            ViewBag.Fullname = fullname;
            ViewBag.UserId = userId;
            ViewBag.UserRole = userRole;
            var classes = db.Classes.ToList(); 
            return View(classes);
        }
        public IActionResult Subject()
        {
            // Truy xuất thông tin từ session
            var username = HttpContext.Session.GetString("Username");
            var fullname = HttpContext.Session.GetString("Fullname");
            var userId = HttpContext.Session.GetString("ID");
            var userRole = HttpContext.Session.GetString("Role");

            // Sử dụng ViewBag để truyền dữ liệu sang view
            ViewBag.Username = username;
            ViewBag.Fullname = fullname;
            ViewBag.UserId = userId;
            ViewBag.UserRole = userRole;
            var subjects = db.Subjects.ToList();
            return View(subjects);
        }
        public IActionResult Result()
        {
            // Truy xuất thông tin từ session
            var username = HttpContext.Session.GetString("Username");
            var fullname = HttpContext.Session.GetString("Fullname");
            var userId = HttpContext.Session.GetString("ID");
            var userRole = HttpContext.Session.GetString("Role");

            // Sử dụng ViewBag để truyền dữ liệu sang view
            ViewBag.Username = username;
            ViewBag.Fullname = fullname;
            ViewBag.UserId = userId;
            ViewBag.UserRole = userRole;
            var results = db.Results.ToList();
            return View(results);
        }
    }
}
