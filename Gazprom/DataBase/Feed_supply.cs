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
    
    public partial class Feed_supply
    {
        public int id { get; set; }
        public int idSupplier { get; set; }
        public int idFeed { get; set; }
        public System.DateTime date { get; set; }
        public int price { get; set; }
    
        public virtual Feed Feed { get; set; }
        public virtual The_supplier The_supplier { get; set; }
    }
}
