﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models
{
    [Table("Medicaments")]
    public class Medicament
    {
        public Medicament()
        {
            this.Prescriptions = new HashSet<PatientMedicament>();
        }

        public int MedicamentId{get;set;}
        
        public string Name { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
