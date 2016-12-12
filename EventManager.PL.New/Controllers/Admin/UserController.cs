using System.Web.Mvc;
using EventManager.AccountPolicy;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.Users;
using EventManager.BL.Facades;
using EventManager.PL.ViewModels.Users;

namespace EventManager.PL.Controllers.Admin
{
    [Authorize(Roles = Claims.Admin)]
    public class UserController : Controller
    {
        public UserFacade UserFacade { get; set; }
        
        public ActionResult Index()
        {
            var users = UserFacade.ListUsers(new UserFilter());
            return View(users);
        }

        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            var user = UserFacade.GetUser(id);
            return View(CreateUserViewModel(user));
        }
        
        [HttpPost]
        public ActionResult Edit(int id, UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return View(CreateUserViewModel(user));
            }

            try
            {
                UserFacade.UpdateUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        private UserViewModel CreateUserViewModel(UserDTO user)
        {
            return new UserViewModel
            {
                User = user,
                UserRoles = new SelectList(new[] { Claims.Member, Claims.Organizer }, user.Role)
            };
        }
    }
}