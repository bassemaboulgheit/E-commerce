using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MyEcommerce.DTOs.CategoriesDTOs;
using MyEcommerce.Models;

namespace MyEcommerce.Application.Mapper
{
    public class MapsterConfig
    {
        public static void RegisterMapsterConfiguration()
        {
            TypeAdapterConfig<Category, CategoryDTO>.NewConfig()
                .Map(dest => dest.CategoryID, src => src.Id)
                .Map(dest => dest.CategoryName, src => src.Name)
                .Map(dest => dest.Cat_Description, src => src.Description);

            TypeAdapterConfig<CreateCategoryDTO, Category>.NewConfig()
                .Map(dest => dest.Name, src => src.CategoryName)
                .Map(dest => dest.Description, src => src.CatDescription);

            TypeAdapterConfig<CategoryDTO, Category>.NewConfig()
                .Map(dest => dest.Name, src => src.CategoryName)
                .Map(dest => dest.Description, src => src.Cat_Description);
        }
    }
}
