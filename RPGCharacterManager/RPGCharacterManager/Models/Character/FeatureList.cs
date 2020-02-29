using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public class FeatureList
    {
        public List<Feature> Features { get; set; } = new List<Feature>();

        public void AddFeature(string featureName, string featureDescription)
        {
            Feature feature = new Feature();
            feature.featureName = featureName;
            feature.featureDescription = featureDescription;
            Features.Add(feature);
        }
    }
}
