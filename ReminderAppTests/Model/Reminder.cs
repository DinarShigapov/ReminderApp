//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReminderAppTests.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reminder
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    
        public virtual User User { get; set; }
    }
}
