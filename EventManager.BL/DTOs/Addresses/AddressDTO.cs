using System.ComponentModel.DataAnnotations;

namespace EventManager.BL.DTOs.Addresses
{
    public class AddressDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(512)]
        public string Building { get; set; }
        [Required]
        [MaxLength(256)]
        public string Street { get; set; }
        [Required]
        [MaxLength(16)]
        public string StreetNumber { get; set; }
        [Required]
        [MaxLength(128)]
        public string City { get; set; }

        public override string ToString()
        {
            return $"Building: {Building}, Street: {Street}, StreetNumber: {StreetNumber}, City: {City}";
        }
    }
}
