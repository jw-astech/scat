using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dot_not_a_goat.Models
{
    // Models returned by MeController actions.
    public class GetViewModel
    {
        public string Hometown { get; set; }
    }
}