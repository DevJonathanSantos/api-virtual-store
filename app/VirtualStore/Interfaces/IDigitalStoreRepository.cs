using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualStore.Entities;

namespace VirtualStore.Interfaces
{
    public interface IDigitalStoreRepository
    {
        Task<List<Product>> Search(string category);
    }
}
