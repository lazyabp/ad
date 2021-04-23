using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.AdvertisementKit.Dtos
{
    public class GetAdvertisingListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public bool? IsActive { get; set; }

        public AdvertisementType? AdvertisementType { get; set; }

        public bool includeDetails { get; set; }
    }
}
