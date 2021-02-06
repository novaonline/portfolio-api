namespace PortfolioApi.Models
{
	public class OwnedEntity : Entity
	{
		[Newtonsoft.Json.JsonIgnore]
		[System.Text.Json.Serialization.JsonIgnore]
		public string? OwnerUserId { get; set; }

		public bool IsOwnedBy(string? userId) => userId?.Equals(OwnerUserId) ?? false;
	}
}
