using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualStore.Entities;

namespace VirtualStore.Interfaces.Repositories
{
    public interface IDigitalStoreRepository
    {
        Task<List<Product>> Search(string parameter);
        Task<bool> Insert(string name, string category, string manufacturer, DateTime manufacturingDate, decimal price, string description);
    }
}
