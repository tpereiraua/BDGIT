﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class PremioNobelMetaData
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public PremioNobelMetaData()
        //{
        //    this.Laureado = new HashSet<Laureado>();
        //}

        public int PremioNobelId { get; set; }
        [Display(Name = "Year")]
        public int Ano { get; set; }
        [Display(Name = "Category")]
        public int CategoriaId { get; set; }
       [Display(Name ="Title")]
       
        public string Titulo { get; set; }
        [Display(Name ="Motivation")]
        [DataType(DataType.MultilineText)]
        public string Motivacao { get; set; }

      
    }


    public partial class CategoriaMetaData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public CategoriaMetaData()
        //{
        //    this.PremioNobel = new HashSet<PremioNobel>();
        //}

        public int CategoriaId { get; set; }
        [Display(Name = "Category")]
        [StringLength(100, MinimumLength = 5)]
        [Required (ErrorMessage ="The category must have")]
        public string Nome { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PremioNobel> PremioNobel { get; set; }
    }
}