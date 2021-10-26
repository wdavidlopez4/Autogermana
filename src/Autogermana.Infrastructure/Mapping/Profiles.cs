﻿using Autogermana.Application.CategoryServices.CommandCategoryCreate;
using Autogermana.Application.CategoryServices.QueryAllCategories;
using Autogermana.Application.ProductServices.CommandProductCreate;
using Autogermana.Application.ProductServices.CommandProductUpdateData;
using Autogermana.Application.ProductServices.QueryProductsByCategory;
using Autogermana.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autogermana.Infrastructure.Mapping
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            this.CreateMap<List<Product>, List<ProductsByCategoryDTO>>();
            this.CreateMap<Product, ProductUpdateDataDTO>();
            this.CreateMap <Product, ProductCreateDTO> ();
            this.CreateMap <List<Category>, List<AllCategoriesDTO>> ();
            this.CreateMap <Category, CategoryCreateDTO> ();
        }
    }
}