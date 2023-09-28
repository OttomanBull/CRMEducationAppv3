namespace CRM_Presendation.Models
{
    public class LoginModel:BaseEntityView
    {
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
