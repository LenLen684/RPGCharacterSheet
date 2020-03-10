using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.DatabaseModels
{
    public class Feature
    {
        [Key]
        public int Id{get;set;}
        public string featureName {get;set;}
        public string featureDescription {get; set; }
    }
}