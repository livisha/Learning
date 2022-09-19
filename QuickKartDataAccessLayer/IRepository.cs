using QuickKartDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickKartDataAccessLayer
{
    public interface IRepository
    {
        //comment
        public List<Categories> GetAllCategories();
        public bool AddCategory(Categories category);
        public bool UpdateCategory(Categories category);
        public bool DeleteCategory(byte categID);
        public bool AddCategory(string categoryName);

    }
}
