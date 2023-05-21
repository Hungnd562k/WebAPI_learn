using System.ComponentModel.DataAnnotations.Schema;

namespace API_learn.Data
{
    [Table("Users")]
    public class User
    {
        public  int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
