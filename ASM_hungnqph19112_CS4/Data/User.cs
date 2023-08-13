namespace ASM_hungnqph19112_CS4.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }    
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
