//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Travel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tra
    {
        public int travel_id { get; set; }
        public Nullable<int> travel_type_id { get; set; }
        public Nullable<int> travel_user_id { get; set; }
        public string travel_from { get; set; }
        public string travel_to { get; set; }
        public string travel_access_point { get; set; }
        public string travel_price { get; set; }
        public string travel_notice { get; set; }
        public Nullable<System.DateTime> travel_date { get; set; }
    
        public virtual User User { get; set; }
    }
}