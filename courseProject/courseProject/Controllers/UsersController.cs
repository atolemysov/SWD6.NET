using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using courseProject.Data;
using courseProject.Models;
using courseProject.Services;
using Microsoft.AspNetCore.Authorization;
using courseProject.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace courseProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UsersService _usersService;
        private readonly UserManager<User> userManager;


        public UsersController(UsersService usersService, UserManager<User> userManager)
        {
            _usersService = usersService;
            this.userManager = userManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _usersService.GetUser();
            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _usersService.DetailsUsers(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }
        
        
        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[AcceptVerbs("Get", "Post")] -> Remote validation
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            //Remote validation
            //if (!_context.Find(user.Login))
            //{
            //    return Json($"Email {user.Login} is already in use.");
            //}


            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Full_Name = model.Full_Name,
                };
                var result = await userManager.CreateAsync(user, model.Password);
                //await _usersService.AddAndSave(user);
                //return RedirectToAction(nameof(Index));
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "/Users");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _usersService.DetailsUsers(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Email,Password,Full_Name,RoleId")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _usersService.Update(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _usersService.DetailsUsers(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _usersService.DetailsUsers(id);
            await _usersService.Delete(user);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _usersService.UserExis(id);
        }
        
    }
}
