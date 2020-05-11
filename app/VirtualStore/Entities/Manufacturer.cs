using System;

namespace VirtualStore.Entities
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public DateTime ManufacturingDate { get; set; }

        public Manufacturer(string name, DateTime manufacturingDate)
        {
            this.Name = name;
            this.ManufacturingDate = manufacturingDate;
        }
    }
}
