namespace VirtualStore.Entities
{
    public class Category
    {
        public string Name { get; set; }
        public Category(string name)
        {
            this.Name = name;
        }
    }
}
