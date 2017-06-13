namespace portfolio_api.Models
{
    public class Language : RankableItem
    {
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
