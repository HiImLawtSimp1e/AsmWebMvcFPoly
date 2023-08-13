namespace ASM_hungnqph19112_CS4.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public virtual ICollection<Product> Products { get; set; }  
    }
}
