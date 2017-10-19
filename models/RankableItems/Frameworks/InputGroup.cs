using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioApi.Models.RankableItems.Frameworks
{
    public class InputGroup
    {
        public int RankId { get; set; }
        public string Title { get; set; }
        public Info FrameworkInfo { get; set; }
    }
}
