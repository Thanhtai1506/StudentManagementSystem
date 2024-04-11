using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentManagerSystem.Models;
using System.Diagnostics;

namespace StudentManagerSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController>? _logger;
        QuanLiSinhVienContext db = new QuanLiSinhVienContext();
        

        public IActionResult Result()
        {
            var username = HttpContext.Session.GetString("Username");
            var fullname = HttpContext.Session.GetString("Fullname");
            var userId = HttpContext.Session.GetString("ID");
            var userRole = HttpContext.Session.GetString("Role");

            // Sử dụng ViewBag để truyền dữ liệu sang view
            ViewBag.Username = username;
            ViewBag.Fullname = fullname;
            ViewBag.UserId = userId;
            ViewBag.UserRole = userRole;

            var listrs = db.Results.ToList();

            return View(listrs);
        }

        public IActionResult Subject()
        {
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

        public IActionResult Index()
        {
            // Truy xuất thông tin từ session
            var username= HttpContext.Session.GetString("Username");
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

        public IActionResult Class()
        {
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

        public IActionResult FQA()
        {
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

        public IActionResult InformationStudent()
        {
            var username = HttpContext.Session.GetString("Username");
            var fullname = HttpContext.Session.GetString("Fullname");
            var userId = HttpContext.Session.GetString("ID");
            var userRole = HttpContext.Session.GetString("Role");
            var birthday = HttpContext.Session.GetString("Date");
            var gender = HttpContext.Session.GetString("Gender");
            var address = HttpContext.Session.GetString("Address");
            var phonenumber = HttpContext.Session.GetString("Phone");
            var subject = HttpContext.Session.GetString("SubjectName");

            // Sử dụng ViewBag để truyền dữ liệu sang view
            ViewBag.Username = username;
            ViewBag.Fullname = fullname;
            ViewBag.UserId = userId;
            ViewBag.UserRole = userRole;
            ViewBag.Birthday = birthday;
            ViewBag.Gender = gender;
            ViewBag.Address = address;
            ViewBag.Phone = phonenumber;
            ViewBag.Subject = subject;

            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult LoginPage ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPage(Account model)
        {
            var user = db.Accounts.FirstOrDefault(c => c.Username == model.Username && c.Password == model.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Username or Password.");
                return View();
            }

            // Lấy thông tin sinh viên từ cơ sở dữ liệu dựa trên AccountId của người dùng
            var student = db.Students.FirstOrDefault(s => s.StudentId == user.AccountId);
            if (student == null)
            {
                // Xử lý khi không tìm thấy sinh viên tương ứng với tài khoản người dùng
                return View("NotFoundView");
            }

            var tubject = db.Subjects.FirstOrDefault(t => t.SubjectId == student.SubjectId && student.StudentId == user.AccountId);
            if (tubject == null)
            {
                // Handle the case when the subject corresponding to the user's account is not found
                return View("NotFoundView");
            }

            HttpContext.Session.SetString("SubjectName", tubject.SubjectName ?? "");




            // Lưu ngày sinh vào session
            HttpContext.Session.SetString("Date", student.DateOfBirth?.ToString("dd/MM/yyyy") ?? "");
            HttpContext.Session.SetString("Gender", student.Gender ??"");
            HttpContext.Session.SetString("Address", student.Address ?? "");
            HttpContext.Session.SetString("Phone", student.PhoneNumber ?? "");

            // Set user information in the session.
            HttpContext.Session.SetString("User", user.Fullname);
            HttpContext.Session.SetString("Fullname", user.Fullname ?? "");
            HttpContext.Session.SetString("ID", user.AccountId ?? "");
            HttpContext.Session.SetString("Role", user.Role ?? "");

            // Redirect based on the user's role.
            if (user.Role == "Admin")
            {
                return Redirect("/Admin/StudentAdmin");
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }

        [HttpPost]
        public IActionResult SignupPage(Account model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem student code có tồn tại trong bảng Student không
                var student = db.Students.FirstOrDefault(s => s.StudentId == model.AccountId);
                if (student == null)
                {
                    ModelState.AddModelError("", "Invalid Student Code.");
                    return View(model);
                }

                // Kiểm tra xem student code đã được sử dụng để đăng ký tài khoản chưa
                var existingAccount = db.Accounts.FirstOrDefault(a => a.AccountId == model.AccountId);
                if (existingAccount != null)
                {
                    ModelState.AddModelError("AccountId", "Invalid Student Code.");
                    return View(model);
                }

                // Tạo một đối tượng Account mới
                var newAccount = new Account
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = "user", // Mặc định role là user
                    AccountId = student.StudentId,
                    Fullname = student.Fullname,
                    // Các trường khác của Account có thể thêm vào ở đây
                };

                // Lưu tài khoản mới vào cơ sở dữ liệu
               db.Accounts.Add(newAccount);
               db.SaveChanges();

                // Đăng nhập người dùng tự động sau khi đăng ký thành công (tuỳ theo yêu cầu)
                HttpContext.Session.SetString("User", newAccount.Fullname);
                HttpContext.Session.SetString("Fullname", newAccount.Fullname.ToString());
                HttpContext.Session.SetString("ID", newAccount.AccountId.ToString());
                HttpContext.Session.SetString("Role", newAccount.Role);

                // Redirect sau khi đăng ký thành công
                return RedirectToAction("Index", "Home");
            }

            // Nếu model không hợp lệ, hiển thị lại form đăng ký với các lỗi
            return View(model);
        }



        public IActionResult SignupPage()
        {
            return View();
        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginPage", "Home");
        }
    }
}
