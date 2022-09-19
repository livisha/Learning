using QuickKartDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickKartDataAccessLayer
{
    public interface IRepository
    {
        public List<Categories> GetAllCategories();
<<<<<<< Updated upstream
        public bool AddCategory(Categories category);
        public bool UpdateCategory(Categories category);
        public bool DeleteCategory(byte categID);
        public bool AddCategory(string categoryName);
        public byte GenerateNewCategoryId();
=======
        bool AddCategory(string categoryName);
        void UpdateCategory(Categories category);
        void DeleteCategory(byte categoryId);
>>>>>>> Stashed changes
    }
}
