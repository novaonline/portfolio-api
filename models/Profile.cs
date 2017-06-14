using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApi.Models
{
    public class Profile
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageUrl { get; set; }

        /// <summary>
        /// A quick little blurb about me
        /// </summary>
        public string AboutMe { get; set; }
    }

}
