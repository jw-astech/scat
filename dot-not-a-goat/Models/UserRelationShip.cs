//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dot_not_a_goat.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserRelationShip
    {
        public int connectionId { get; set; }
        public string followerId { get; set; }
        public string followingId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual AspNetUser AspNetUser1 { get; set; }
    }
}
