using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StackOverflowClone.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace StackOverflowClone.Controllers
{
        [Authorize]
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostsController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Posts);
        }
        public IActionResult Details(int id)
        {
            var thisPost = _db.Posts.Include(post => post.Answers).FirstOrDefault(Posts => Posts.PostId == id);
            return View(thisPost);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            post.User = currentUser;
            DateTime timestamp = DateTime.Now;
            post.Date = timestamp;
            post.PostVote = 0;
            _db.Posts.Add(post);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
