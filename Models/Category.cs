namespace WebAppli.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Products>();

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Products> Product { get; set; }
    }
}
