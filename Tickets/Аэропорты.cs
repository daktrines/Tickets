//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tickets
{
    using System;
    using System.Collections.Generic;
    
    public partial class Аэропорты
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Аэропорты()
        {
            this.Рейсы = new HashSet<Рейсы>();
            this.Рейсы1 = new HashSet<Рейсы>();
        }
    
        public int КодАэропорта { get; set; }
        public string Наименование { get; set; }
        public string Город { get; set; }
        public string Телефон { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Рейсы> Рейсы { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Рейсы> Рейсы1 { get; set; }
    }
}
