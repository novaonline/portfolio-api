using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApi.Models
{
    public class FrameworksAndLibs : RankableItem
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int FrameworksAndLibsId { get; set; }

        /// <summary>
        /// The name of the Framework or Library 
        /// </summary>
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
