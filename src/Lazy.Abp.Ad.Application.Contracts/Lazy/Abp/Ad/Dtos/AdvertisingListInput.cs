using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Ad.Dtos
{
    public class AdvertisingListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public bool? IsActive { get; set; }

        public AdvertisementType? AdvertisementType { get; set; }

        public bool IncludeDetails { get; set; }
    }
}
