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
    
    public partial class Самолеты
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Самолеты()
        {
            this.Рейсы = new HashSet<Рейсы>();
        }
    
        public int КодСамолета { get; set; }
        public int КодАвиакомпании { get; set; }
        public string МодельСамолета { get; set; }
        public Nullable<int> КоличествоМест { get; set; }
    
        public virtual Авиакомпании Авиакомпании { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Рейсы> Рейсы { get; set; }
    }
}
