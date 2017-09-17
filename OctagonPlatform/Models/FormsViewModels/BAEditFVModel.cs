﻿using OctagonPlatform.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OctagonPlatform.Models.FormsViewModels
{
    public class BAEditFVModel
    {
        public BAEditFVModel()
        {
            Users = new Collection<User>();
            Terminals = new Collection<Terminal>();

        }
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nick Name")]
        [StringLength(50)]
        public string NickName { get; set; }

        [Required]
        [StringLength(50)]
        public string RoutingNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }

        [Required]
        public StatusType.Status Status { get; set; }

        [Required]
        [Display(Name = "Name on Check")]
        public string NameOnCheck { get; set; }

        [Required]
        public string FedTax { get; set; }

        [Display(Name = "Social Security Number")]
        public string Ssn { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public IEnumerable<Country> Countries { get; set; }

        [Required]
        [Display(Name = "State")]
        public int StateId { get; set; }
        public State State { get; set; }
        public IEnumerable<State> States { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }
        public City City { get; set; }
        public IEnumerable<City> Cities { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public int Zip { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Partner is required")]
        [Display(Name = "Partner")]
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
        public IEnumerable<Partner> Partners { get; set; }

        public ICollection<User> Users { get; set; }

        [Required]
        public AccountType.TypeName AccountType { get; set; }

        public ICollection<Terminal> Terminals { get; set; }
    }
}