using System;

namespace VirtualStore.WebApi.ViewModels
{
    public class InsertViewModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public DateTime DanufacturingDate { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
