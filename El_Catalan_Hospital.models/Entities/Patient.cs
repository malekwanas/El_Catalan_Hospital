﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.models.Entities
{
    public class Patient : UserClass
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Patient_ID { get; set; }
        public int? ReceptionistID { get; set; }  //FK from Receptionist class
        public Receptionist Receptionist { get; set; }

    }
}
