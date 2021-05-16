using System;
using System.ComponentModel;

namespace Lazy.Abp.Ad.Dtos
{
    [Serializable]
    public class UserAdvertisingItemCreateUpdateDto
    {
        public Guid AdvertisingItemId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Content { get; set; }

        public string Alt { get; set; }

        public bool IsActive { get; set; }
    }
}