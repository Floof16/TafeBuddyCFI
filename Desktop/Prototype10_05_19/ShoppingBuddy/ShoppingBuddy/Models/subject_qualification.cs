//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingBuddy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class subject_qualification
    {
        public string QualCode { get; set; }
        public string SubjectCode { get; set; }
        public string UsageType { get; set; }
    
        public virtual qualification qualification { get; set; }
        public virtual subject subject { get; set; }
    }
}
