using System;
using System.ComponentModel;
namespace Heals.CSX.Mall.Orders.Dtos
{
    [Serializable]
    public class CreateUpdateProductItemOrderedDto
    {
        public Guid ProductId { get; set; }

        public string ProductNo { get; set; }

        public string ProductName { get; set; }

        //public string PictureUri { get; set; }
    }
}