namespace VirtualStore.Entities
{
    public class Product
    {
        public long ID { get; private set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Product() { }
        public Product(long iD, string name, Category category, Manufacturer manufacturer, decimal price, string description)
        {
            this.ID = iD;
            this.Name = name;
            this.Category = category;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Description = description;
        }
    }
}
