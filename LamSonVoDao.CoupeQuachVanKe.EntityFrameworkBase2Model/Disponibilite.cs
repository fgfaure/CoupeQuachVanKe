//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LamSonVoDao.CoupeQuachVanKe.EntityFrameworkBase2Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Disponibilite
    {
        public int Id { get; set; }
        public int Role { get; set; }
        public System.DateTime Date { get; set; }
        public bool Matin { get; set; }
    
        public virtual Encadrant Encadrant { get; set; }
    }
}
