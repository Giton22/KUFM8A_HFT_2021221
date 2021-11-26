﻿using KUFM8A_HFT_2021221.Models;
using KUFM8A_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            brandRepository.Create(brand);
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