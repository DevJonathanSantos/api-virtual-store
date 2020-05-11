using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualStore.Entities;
using VirtualStore.Interfaces;

namespace VirtualStore.Services
{
    public class DigitalStoreService : IDigitalStoreService
    {
        public readonly IDigitalStoreRepository _digitalStoreRepository;
        public DigitalStoreService(IDigitalStoreRepository digitalStoreRepository)
        {
            _digitalStoreRepository = digitalStoreRepository;
        }
        public async Task<List<Product>> Search(string category)
        {
            return await _digitalStoreRepository.Search(category);
        }
    }
}
