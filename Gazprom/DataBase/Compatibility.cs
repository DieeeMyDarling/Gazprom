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
    
    public partial class Compatibility
    {
        public int id { get; set; }
        public int idKind { get; set; }
        public int idKind2 { get; set; }
        public string Compability { get; set; }
    
        public virtual Kind Kind { get; set; }
        public virtual Kind Kind1 { get; set; }
    }
}