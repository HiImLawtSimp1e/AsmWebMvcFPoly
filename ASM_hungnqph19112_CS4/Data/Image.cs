namespace ASM_hungnqph19112_CS4.Data
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}
