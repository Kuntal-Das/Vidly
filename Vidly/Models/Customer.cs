﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //[Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime? DOB { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
    }
}