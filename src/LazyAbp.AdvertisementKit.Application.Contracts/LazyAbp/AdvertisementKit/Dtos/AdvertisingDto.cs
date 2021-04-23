using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.AdvertisementKit.Dtos
{
    [Serializable]
    public class AdvertisingDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Label { get; set; }

        public AdvertisementType AdvertisementType { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int? ItemPrice { get; set; }

        public bool IsActive { get; set; }

        public string ExpiredContent { get; set; }

        public List<AdvertisingItemDto> Items { get; set; }
    }
}