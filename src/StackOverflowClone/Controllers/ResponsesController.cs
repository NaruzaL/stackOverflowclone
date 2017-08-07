using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StackOverflowClone.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace StackOverflowClone.Controllers
{
    [Authorize]
    public class ResponsesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public ResponsesController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Response response, int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            response.User = currentUser;
            DateTime timestamp = DateTime.Now;
            response.ResponseDate = timestamp;
            response.Vote = 0;
            response.BestAnswer = false;
            response.Post = _db.Posts.FirstOrDefault(Posts => Posts.PostId == id);
            _db.Responses.Add(response);
            _db.SaveChanges();
            return RedirectToAction("Details", "Posts", new { id = id });
        }
    }
}
