using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
namespace mkproject.Models
{
    public class ChatMessage
    {
        public ChatMessage()
        {
            CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public string ChatRoomName { get; set; } // Foreign key

        [ForeignKey(nameof(ChatRoomName))]
        public virtual ChatRoom ChatRoom { get; set; } // Navigation property

        public string UserName { get; set; }

        public string Message { get; set; }

        public DateTime CreatedOn { get; private set; }

        public string FormattedCreatedOn => CreatedOn.ToString("yyyy-MM-dd, HH:mm:ss");
    }
}