//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gazprom.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Possible_offspring
    {
        public int id { get; set; }
        public int idAnimal { get; set; }
        public int idAnimal2 { get; set; }
        public Nullable<System.DateTime> approximateDate { get; set; }
    
        public virtual Animal Animal { get; set; }
        public virtual Animal Animal1 { get; set; }
    }
}
