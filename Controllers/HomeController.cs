using Microsoft.AspNetCore.Mvc;
using mkproject.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using mkproject.DB;
using System.Linq;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string UserKey = "USER_KEY";
        private const string ChatRoomKey = "CHAT_ROOM_KEY";
        private readonly MessageDb _dbContext;

        public HomeController(ILogger<HomeController> logger, MessageDb dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString(UserKey);
            var ChatRoomName = HttpContext.Session.GetString(ChatRoomKey);

            if (string.IsNullOrEmpty(userName) || (string.IsNullOrEmpty(ChatRoomName)) )
            {
                return RedirectToAction("SignIn");
            }

            var vm = new IndexVm
            {
                UserName = userName,
                ChatRoomName = ChatRoomName
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult SignIn(SignInVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            // Check if the chat room exists
            var chatRoom = _dbContext.ChatRooms.FirstOrDefault(cr => cr.ChatRoomName == vm.ChatRoomName);
            
            if (chatRoom == null)
            {
                // Chat room doesn't exist, create a new one
                chatRoom = new ChatRoom { ChatRoomName = vm.ChatRoomName };
                _dbContext.ChatRooms.Add(chatRoom);
                _dbContext.SaveChanges();
            }

            // Sign in user
            SignInUser(vm.UserName, vm.ChatRoomName);
            return RedirectToAction("Index");
        }

        private void SignInUser(string userName, string chatRoomName)
        {
            HttpContext.Session.SetString(UserKey, userName);
            HttpContext.Session.SetString(ChatRoomKey, chatRoomName);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }
}
