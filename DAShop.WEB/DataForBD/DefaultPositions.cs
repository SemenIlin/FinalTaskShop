using DAShop.WEB.EFCore;
using DAShop.WEB.Models.ForEmployee;
using System.Linq;

namespace DAShop.WEB.DataForBD
{
    public static class DefaultPositions
    {
        public static void Initialize(ShopContext context)
        {
            if (!context.Positions.Any())
            {
                context.Positions.AddRange(
                    new Position
                    {
                        Title = "Бухгалтер",
                        MinSalary = 500
                    },
                    new Position
                    {
                       Title = "Продавец",
                       MinSalary = 400
                    },
                    new Position
                    {
                        Title = "Закупщик",
                        MinSalary = 500
                    },
                    new Position
                    {
                        Title = "Грузчик",
                        MinSalary = 350
                    });

                context.SaveChanges();
            }

            if(!context.Departaments.Any())
            {
                context.Departaments.AddRange(
                   new Departament
                   {
                       IdName = "Бухгалтерский отдел"
                   },
                   new Departament
                   {
                       IdName = "Отдел продаж"
                   },
                   new Departament
                   {
                       IdName = "Отдел транспортировки"
                   },
                   new Departament
                   {
                       IdName = "Финнсовый отдел"
                   });
            }
        }
    }
}