using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualStore.Entities;

namespace VirtualStore.Interfaces.Services
{
    public interface IDigitalStoreService
    {
        Task<List<Product>> Search(string parameter);
        Task<List<Product>> Insert(string name, string category, string manufacturer, DateTime manufacturingDate, decimal price, string description);
    }
}
