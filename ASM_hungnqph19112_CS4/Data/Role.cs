namespace ASM_hungnqph19112_CS4.Data
{
    public class Role
    {
        public int Id { get; set; } 
        public string RoleName { get; set; } = string.Empty;
        public virtual ICollection<User> Users { get; set; }
    }
}
