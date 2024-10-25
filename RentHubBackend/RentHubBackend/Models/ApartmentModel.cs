using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentHubBackend.Models
{
    public class ApartmentModel
    {
        [Key]
        public virtual int Id { get; set; }

        public string UserId { get; set; }

        public string Email { get; set; }

        public string ApartName { get; set; }

        public bool IsShared { get; set; }

        public string ApartLocation { get; set; }

        public string ApartDetails { get; set; }

        public string StayType { get; set; }

        public string ExpectedRent { get; set; }

        public bool IsNegotiable { get; set; }

        public bool IsFurnished { get; set; }

        public string DescpTitle { get; set; }

        public string Descp { get; set; }

        public string CreatedBy { get; set; }

        public string Contact { get; set; }

        public int IsFavourited { get; set; }

        public string? ApartmentImagePath { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAt { get; set; }
    }
}
