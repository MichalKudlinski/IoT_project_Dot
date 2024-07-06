using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mkproject.Models
{
    public class ChatRoom
    {
        public ChatRoom()
        {
            ChatMessages = new List<ChatMessage>();
        }


       
        [Key]
        public string ChatRoomName { get; set; }
        
        public int Id { get; set; }
        


  

        // Navigation property for chat messages in this chat room
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
    }
}