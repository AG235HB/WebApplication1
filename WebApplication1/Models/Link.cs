using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    //ИМЯ МОДЕЛИ НЕ ДОЛЖНО БЫТЬ Link
    public class Relation
    {
        //ЭТО ПОЛЕ ОБЯЗАТЕЛЬНО!!!
        public int ID { get; set; }
        public int org_ID { get; set; }
        public int fdr_ID { get; set; }
    }
}