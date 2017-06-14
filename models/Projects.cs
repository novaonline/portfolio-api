using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApi.Models
{
    public class Project
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
    }
}
