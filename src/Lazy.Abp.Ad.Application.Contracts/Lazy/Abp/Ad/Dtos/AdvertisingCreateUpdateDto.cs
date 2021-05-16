using System;
using System.ComponentModel;

namespace Lazy.Abp.Ad.Dtos
{
    [Serializable]
    public class AdvertisingCreateUpdateDto
    {
        public string Name { get; set; }

        public AdvertisementType AdvertisementType { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int? ItemPrice { get; set; }

        public bool IsActive { get; set; }

        public string ExpiredContent { get; set; }
    }
}