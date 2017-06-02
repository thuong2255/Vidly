using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Validation;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customers'name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }


        [Display(Name = "Membership Type")]
        [Required]
        public MemberShipType MemberShipType { get; set; }

        public byte MemberShipTypeId { get; set; }
    }
}