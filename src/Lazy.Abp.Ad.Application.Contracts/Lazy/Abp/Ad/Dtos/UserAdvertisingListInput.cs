using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Ad.Dtos
{
    public class UserAdvertisingListInput : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }

        public DateTime? CreatedAfter { get; set; }

        public DateTime? CreatedBefore { get; set; }

        public DateTime? ExpireAfter { get; set; }

        public DateTime? ExpireBefore { get; set; }

        public bool IncludeDetails { get; set; }
    }
}
