namespace PortfolioApi.Models.Contents
{
    public class Info : InfoItem, IPortfolioInfo<Info>
    {
        public string Header { get; set; }
        public string BackgroundUrl { get; set; }

        public void Update(Info model)
        {
            Header = model.Header;
            BackgroundUrl = model.BackgroundUrl;
        }
    }
}
