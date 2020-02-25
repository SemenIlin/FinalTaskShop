using BLShop.WEB.Interfaces;
using DAShop.WEB.EFCore;
using DAShop.WEB.Models.ForEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLShop.WEB.Departaments
{
    public class AccountingDepartment
    {        
        private readonly ShopContext shopContext;

        public delegate decimal CalculateSalary();

        public AccountingDepartment(ShopContext shopContext)
        {
            this.shopContext = shopContext;            
        }


        private decimal DefaultSalary()
        {
            return 500;
        }
    }
}
