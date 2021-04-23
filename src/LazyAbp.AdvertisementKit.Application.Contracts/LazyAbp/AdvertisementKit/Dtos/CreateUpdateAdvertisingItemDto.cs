using System;
using System.ComponentModel;

namespace LazyAbp.AdvertisementKit.Dtos
{
    [Serializable]
    public class CreateUpdateAdvertisingItemDto
    {
        public Guid AdvertisingId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Content { get; set; }

        public string Alt { get; set; }

        public bool IsActive { get; set; }

        public bool IsOnSale { get; set; }

        public int DisplayOrder { get; set; }

        //public DateTime? StartTime { get; set; }

        //public DateTime? ExpireTime { get; set; }
    }
}