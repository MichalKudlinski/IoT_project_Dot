using System.ComponentModel.DataAnnotations;
namespace mkproject.Models;

  public class SignInVm
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Chat Room Name is required")]
        public string ChatRoomName{ get; set; }
    }