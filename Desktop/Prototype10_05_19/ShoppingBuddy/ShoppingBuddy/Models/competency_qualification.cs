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
    
    public partial class competency_qualification
    {
        public string QualCode { get; set; }
        public string NationalCompCode { get; set; }
        public string CompTypeCode { get; set; }
    
        public virtual competency_type competency_type { get; set; }
    }
}
