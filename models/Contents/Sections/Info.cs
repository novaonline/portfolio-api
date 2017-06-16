namespace PortfolioApi.Models.Contents.Sections
{
    public class Info: InfoItem, IPortfolioInfo<Info>
    {
        public string Meta { get; set; }
        public string Body { get; set; }

        public void Update(Info model)
        {
            Meta = model.Meta;
            Body = model.Body;
        }
    }
}
