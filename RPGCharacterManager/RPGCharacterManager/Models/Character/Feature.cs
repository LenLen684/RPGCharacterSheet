using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RPGCharacterManager.Models.Character
{
    public class Feature
    {
        public Feature()
        {
            Id = totalId++;
        }
        private static int totalId = 0;
        [Key]
        public int Id { get; set; }

        public string featureName { get; set; }
        public string featureDescription { get; set; }
    }
}
