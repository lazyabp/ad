using System;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.AdvertisementKit.Dtos
{
    [Serializable]
    public class AdvertisingItemViewDto : EntityDto<Guid>
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public string Content { get; set; }

        public string Alt { get; set; }

        public bool IsActive { get; set; }

        public int DisplayOrder { get; set; }
    }
}