using OnlineChatApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineChatApp.Models{
    public class FriendRequest{
        [Key]
        public int FriendRequestId {get; set;}
        
        
        public int FriendRequestFromId {get; set;}
        public virtual User FriendRequestFrom {get; set;}

       
        public int FriendRequestToId {get; set;}
        public virtual User FriendRequestTo {get; set;}


        public FriendRequestStatus FriendRequestStatus {get; set;} = FriendRequestStatus.None;

        [DataType(DataType.Date)]
        [Column(TypeName ="TIMESTAMP")]
        public DateTime CreatedOn {get; set;} = DateTime.Now;

        
    }
}