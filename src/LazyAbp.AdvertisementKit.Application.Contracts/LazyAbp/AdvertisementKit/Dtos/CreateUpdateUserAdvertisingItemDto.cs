using System;
using System.ComponentModel;

namespace LazyAbp.AdvertisementKit.Dtos
{
    [Serializable]
    public class CreateUpdateUserAdvertisingItemDto
    {
        public Guid AdvertisingItemId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Content { get; set; }

        public string Alt { get; set; }

        public bool IsActive { get; set; }
    }
}