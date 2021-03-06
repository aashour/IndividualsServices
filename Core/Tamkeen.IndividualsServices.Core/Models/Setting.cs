﻿using Tamkeen.IndividualsServices.Core.Data;

namespace Tamkeen.IndividualsServices.Core.Models
{
    /// <summary>
    /// Represents a setting
    /// </summary>
    public partial class Setting : BaseEntity<int>
    {
        public Setting() { }

        public Setting(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Value { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
