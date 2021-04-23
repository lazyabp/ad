using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.AdvertisementKit.Dtos
{
    public class GetUserAdvertisingListInput : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }

        public DateTime? CreatedAfter { get; set; }

        public DateTime? CreatedBefore { get; set; }

        public DateTime? ExpireAfter { get; set; }

        public DateTime? ExpireBefore { get; set; }

        public bool IncludeDetails { get; set; }
    }
}
