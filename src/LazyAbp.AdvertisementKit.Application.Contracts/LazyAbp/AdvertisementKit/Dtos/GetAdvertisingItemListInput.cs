﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.AdvertisementKit.Dtos
{
    public class GetAdvertisingItemListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public Guid? AdvertisingId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsOnSale { get; set; }

        //public DateTime? StartAfter { get; set; }

        //public DateTime? StartBefore { get; set; }

        //public DateTime? ExpireAfter { get; set; }

        //public DateTime? ExpireBefore { get; set; }
    }
}
