using System;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.AdvertisementKit.Dtos
{
    [Serializable]
    public class UserAdvertisingDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public Guid AdvertisingItemId { get; set; }

        public DateTime ExpireTime { get; set; }

        public AdvertisingItemDto AdvertisingItem { get; set; }
    }
}