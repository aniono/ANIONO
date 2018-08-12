using System;

namespace FeatureSharp.Models
{
    public class Feature
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }

        public Guid AuthorId { get; set; }
        public User Author { get; set; }
    }
}