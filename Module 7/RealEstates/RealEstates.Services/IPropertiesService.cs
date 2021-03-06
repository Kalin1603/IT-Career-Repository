﻿using RealEstates.Services.Models;
using RealEstates.ViewModels;

namespace RealEstates.Services
{
    public interface IPropertiesService
    {
        void Create(PropertyInputViewModel input);
        PropertiesViewModel GetProperties(int pageNumber = 1);
    }
}