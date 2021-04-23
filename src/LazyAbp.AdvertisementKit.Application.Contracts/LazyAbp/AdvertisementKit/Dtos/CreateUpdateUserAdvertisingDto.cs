using System;
using System.ComponentModel;

namespace LazyAbp.AdvertisementKit.Dtos
{
    [Serializable]
    public class CreateUpdateUserAdvertisingDto
    {
        public Guid? UserId { get; set; }

        public Guid AdvertisingItemId { get; set; }

        public CreateUpdateUserAdvertisingItemDto AdvertisingItem { get; set; }
    }
}