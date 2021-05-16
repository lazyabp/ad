using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Ad.Dtos
{
    [Serializable]
    public class AdvertisingItemDto : FullAuditedEntityDto<Guid>
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