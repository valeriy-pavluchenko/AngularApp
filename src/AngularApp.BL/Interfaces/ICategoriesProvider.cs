using AngularApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.BL.Interfaces
{
    public interface ICategoriesProvider
    {
        List<Category> GetAllCategories();
        Category GetCategory(int id);
    }
}
