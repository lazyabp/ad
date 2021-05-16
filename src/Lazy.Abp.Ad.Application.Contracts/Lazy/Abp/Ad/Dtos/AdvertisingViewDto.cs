using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Ad.Dtos
{
    [Serializable]
    public class AdvertisingViewDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Label { get; set; }

        public AdvertisementType AdvertisementType { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public bool IsActive { get; set; }

        public string ExpiredContent { get; set; }

        public List<AdvertisingItemViewDto> Items { get; set; }
    }
}