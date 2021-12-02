using KUFM8A_HFT_2021221.Models;
using KUFM8A_HFT_2021221.Repository;
using System;
using System.Collections.Generic;

namespace KUFM8A_HFT_2021221.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IBrandRepository brandRepository;
        public BrandLogic(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public void Create(Brand brand)
        {
            if (brand.Name.Length < 3)
            {
                throw new Exception("Name must be over 2 ");
            }
            else if (brand.Name == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                brandRepository.Create(brand);
            }
        }

        public Brand Read(int id)
        {
            return brandRepository.Read(id);
        }

        public IEnumerable<Brand> ReadAll()
        {
            return brandRepository.ReadAll();
        }

        public void Delete(int id)
        {
            brandRepository.Delete(id);
        }

        public void Update(Brand brand)
        {
            brandRepository.Update(brand);

        }
    }
}
