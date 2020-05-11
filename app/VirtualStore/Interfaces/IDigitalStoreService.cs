using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualStore.Entities;

namespace VirtualStore.Interfaces
{
    public interface IDigitalStoreService
    {
        Task<List<Product>> Search(string category);
    }
}
