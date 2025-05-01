using Employee_Management_System.Data;
using Employee_Management_System.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.Controllers
{
    public class RolesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;
      public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task <ActionResult> Index()
        {
            var roles = await _context.Roles.ToListAsync();
            return View(roles);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            IdentityRole role = new IdentityRole();
            role.Name = model.RoleName;
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Edit(string id ,RoleViewModel model)
        {
            var IfRoleExist = await _roleManager.RoleExistsAsync(model.RoleName);
            if (!IfRoleExist)
            {
                var _contextRole = await _roleManager.FindByIdAsync(id);
                _contextRole.Name = model.RoleName;
                var EditedRole = await _roleManager.UpdateAsync(_contextRole);



                if (EditedRole.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var role = new RoleViewModel();

            var result = await _roleManager.FindByIdAsync(id);
            role.RoleName = result.Name;
            role.Id = result.Id;
           return View(role);
        }

    }
}
