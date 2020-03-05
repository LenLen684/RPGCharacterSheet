using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RPGCharacterManager.Models.Character
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }

        public string featureName { get; set; }
        public string featureDescription { get; set; }
    }
}
