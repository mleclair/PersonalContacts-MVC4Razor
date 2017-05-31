using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Device.Location;

namespace MvcApplication2.Models
{
    [Table("PersonalContact")]
    public class PersonalContactModel
    {
        [Required]
        [Key]
        [Display(Name = "Contact ID")]
        public int Id { get; set; }

        //[Required]
        [MinLength(3)]
        [MaxLength(256)]
        public string UserName { get; set; }

        //[Required]
        //[Display(Name = "Contact type")]
        //public Enums.EntityTypes.Contact ContactType { get; set; }

        //[Required]
        //[Display(Name = "Contact type")]
        //public int? ContactType { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //[Required]
        //[Display(Name = "Address")]
        //public CivicAddress CivicAddress { get; set; }

        public int? AddressId { get; set; }

        //[Display(Name = "Email")]
        //public EmailAddressAttribute PersonalEmail { get; set; }

        [Display(Name = "Email")]
        public string PersonalEmail { get; set; }

        //[Display(Name = "Alternate Email")]
        //public string AlternateEmail { get; set; }

        //public virtual ICollection<CivicAddress> Addresses { get; set; }

        //[Required]
        //[Display(Name = "Home Phone")]
        //public PhoneAttribute HomePhone { get; set; }

        //[Display(Name = "Mobile Phone")]
        //public PhoneAttribute MobilePhone { get; set; }

        [Display(Name = "Phone Number")]
        public string HomePhone { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }
    }
}