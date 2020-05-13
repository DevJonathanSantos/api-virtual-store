using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualStore.Entities;
using VirtualStore.Interfaces.Repositories;
using VirtualStore.Interfaces.Services;

namespace VirtualStore.Services
{
    public class DigitalStoreService : IDigitalStoreService
    {
        public readonly IDigitalStoreRepository _digitalStoreRepository;
        public DigitalStoreService(IDigitalStoreRepository digitalStoreRepository)
        {
            _digitalStoreRepository = digitalStoreRepository;
        }
        public async Task<List<Product>> Search(string parameter)
        {
            List<Product> product = null;

            product = await _digitalStoreRepository.Search(parameter);
            return product;
        }
        public async Task<List<Product>> Insert(string name, string category, string manufacturer, DateTime manufacturingDate, decimal price, string description)
        {
            List<Product> product = null;

            var validarInsert = await _digitalStoreRepository.Insert(name, category, manufacturer, manufacturingDate, price, description);
            if (validarInsert.Equals(true))
                product = await _digitalStoreRepository.Search(category);
            return product;
        }
    }
}
