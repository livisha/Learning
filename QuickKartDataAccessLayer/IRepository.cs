using QuickKartDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickKartDataAccessLayer
{
    public interface IRepository
    {
        public List<Categories> GetAllCategories();
    }
}
