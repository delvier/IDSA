﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IDSA.Models.DataStruct;

namespace IDSA.Models
{
    public interface ICompany
    {
        int Id { get; set; }
        string Name { get; set; }
        string Shortcut { get; set; }
        float SharePrice { get; set; }
        DateTime Date { get; set; }
        string Description { get; set; }
        string Href { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        string FullName { get; set; }
        string HeadAccount { get; set; }
        string Profile { get; set; }
        string Address { get; set; }
        string HrefStatus { get; set; }
        long ShareNumbers { get; set; }
        int Volumen20 { get; set; } 
    }

    public class Company : ICompany
    {
        public Company()
        {
            this.Reports = new ObservableListSource<FinancialData>();
            //Date = DateTime.Now;
        }

        [Key][DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [MaxLength(3)]
        public string Shortcut { get; set; }
        //public string ColumnB { get; set; }
        //public string ColumnE { get; set; }
        public float SharePrice { get; set; }
        
        [System.ComponentModel.DefaultValue(typeof(DateTime), "")]
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Href { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string HeadAccount { get; set; }
        public string Profile { get; set; }
        public string Address { get; set; }
        public string HrefStatus { get; set; }
        public long ShareNumbers { get; set; }
        public int Volumen20 { get; set; }  //20SesyjnyObrot
        //public string ColumnI { get; set; }
        //public string ColumnJ { get; set; }
        //public string ColumnK { get; set; }
        //public string ColumnL { get; set; }
        //public DateTime Date2 { get; set; }
        //public string ColumnW { get; set; }
        //public string ColumnX { get; set; }

        public virtual ObservableListSource<FinancialData> Reports { get; set; }

    }
}
