using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineChatApp.Models{

    public class User{
        public int UserId {get; set;}

        [StringLength(50)]
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string? Firstname {get; set;} 

        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string? Lastname {get; set;}

        [StringLength(50)]
        public string? Username {get; set;}

        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string? Email {get; set;}

        [Column("password")]
        public string? PasswordHash {get; set;}

        [DataType(DataType.Date)]
        [Column(TypeName ="TIMESTAMP")]
        public DateTime CreatedOn {get; set;} = DateTime.Now;

        public UserRole UserRole {get; set;} = UserRole.User;

        public Gender Gender {get; set;}

        [ForeignKey("FriendRequestId")]
        public  ICollection<FriendRequest> FriendRequest {get; set;}

        public User ()
        {
            this.FriendRequest = new HashSet<FriendRequest>();
        }
    }

    public class LoginDTO
    {
        public string? Username {get; set;}
        public string? Password {get; set;}

        public LoginDTO(string? username, string? password)
        {
            this.Username = username;
            this.Password = password;
        }
    }

    public class RegisterDTO
    {
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string? Firstname {get; set;} 

        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string? Lastname {get; set;}

        [StringLength(50)]
        public string? Username {get; set;}

        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string? Email {get; set;}


        public string? Password {get; set;}

        public Gender Gender {get; set;}
    }
}