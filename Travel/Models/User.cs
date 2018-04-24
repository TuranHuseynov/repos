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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Galleries = new HashSet<Gallery>();
            this.Tras = new HashSet<Tra>();
            this.Joins = new HashSet<Join>();
            this.Joins1 = new HashSet<Join>();
        }
    
        public int user_id { get; set; }
        public string user_full_name { get; set; }
        public string user_img { get; set; }
        public string user_email { get; set; }
        public string user_password { get; set; }
        public Nullable<int> user_age { get; set; }
        public Nullable<int> user_gender_id { get; set; }
        public string user_phone { get; set; }
        public string user_city { get; set; }
        public string user_fb_link { get; set; }
        public string user_instagram_link { get; set; }
        public string user_twitter_link { get; set; }
        public string user_car_marka { get; set; }
        public string user_car_model { get; set; }
        public Nullable<int> user_car_place { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gallery> Galleries { get; set; }
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tra> Tras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Join> Joins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Join> Joins1 { get; set; }
    }
}