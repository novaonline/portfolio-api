using System.ComponentModel.DataAnnotations.Schema;

namespace portfolio_api.Models.Phones
{
    public class PhoneNumber
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PhoneNumberId { get; set; }
        public PhoneType Type { get; set; }
        public string Value { get; set; }
    }
}
