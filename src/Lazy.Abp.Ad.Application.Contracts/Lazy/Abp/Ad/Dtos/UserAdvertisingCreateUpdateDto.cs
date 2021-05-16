using System;
using System.ComponentModel;

namespace Lazy.Abp.Ad.Dtos
{
    [Serializable]
    public class UserAdvertisingCreateUpdateDto
    {
        public Guid? UserId { get; set; }

        public Guid AdvertisingItemId { get; set; }

        public UserAdvertisingItemCreateUpdateDto AdvertisingItem { get; set; }
    }
}