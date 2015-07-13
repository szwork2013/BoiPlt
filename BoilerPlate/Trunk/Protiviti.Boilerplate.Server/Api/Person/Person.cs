﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api
{
    public class Person
    {
        public Person()
        {
            Gender = " "; // make no assumption
            ImageSource = string.Empty;
        }
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Url]
        public string Blog { get; set; }
        public string Twitter { get; set; }

        [StringLength(1, MinimumLength = 1)]
        public string Gender { get; set; }
        public string ImageSource { get; set; }
        public string Bio { get; set; }
    }
}