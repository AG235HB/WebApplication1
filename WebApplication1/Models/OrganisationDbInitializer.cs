using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class OrganisationDbInitializer : DropCreateDatabaseAlways<ASP_DB_Context>
    {
        protected override void Seed(ASP_DB_Context context)
        {
            context.Organisations.Add(new Organisation { ID = 1, Name = "ORG_uno", INN = "0000000000" });
            context.Organisations.Add(new Organisation { ID = 2, Name = "ORG_dos", INN = "1111111111" });
            context.Organisations.Add(new Organisation { ID = 3, Name = "ORG_tres", INN = "2222222222" });

            context.Founders.Add(new Founder { ID = 1, Surname = "Иванов", Name = "Иван", Patronymic = "Иванович" });
            context.Founders.Add(new Founder { ID = 2, Surname = "Петров", Name = "Пётр", Patronymic = "Петрович" });
            context.Founders.Add(new Founder { ID = 3, Surname = "Сидоров", Name = "Сидор", Patronymic = "Сидорович" });

            context.Relations.Add(new Relation { ID = 1, org_ID = 1, fdr_ID = 1 });
            context.Relations.Add(new Relation { ID = 2, org_ID = 2, fdr_ID = 1 });
            context.Relations.Add(new Relation { ID = 3, org_ID = 3, fdr_ID = 1 });
            context.Relations.Add(new Relation { ID = 4, org_ID = 1, fdr_ID = 2 });
            context.Relations.Add(new Relation { ID = 5, org_ID = 1, fdr_ID = 3 });
            context.Relations.Add(new Relation { ID = 6, org_ID = 3, fdr_ID = 3 });

            base.Seed(context);
        }
    }
}