using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.Ad
{
    public class UserAdvertising : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid UserId { get; protected set; }

        public virtual Guid AdvertisingItemId { get; protected set; }

        public virtual DateTime ExpireTime { get; protected set; }

        /// <summary>
        /// 是否有修改广告内容的权限
        /// </summary>
        public virtual bool CanEdit { get; protected set; }

        //public virtual AdvertisingItem AdvertisingItem { get; set; }

        protected UserAdvertising()
        {
        }

        public UserAdvertising(
            Guid id,
            Guid? tenantId,
            Guid userId, 
            Guid advertisingItemId, 
            DateTime expireTime
        ) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            AdvertisingItemId = advertisingItemId;
            ExpireTime = expireTime;
            CanEdit = false;
        }

        public void SetExpireTime(DateTime expireTime)
        {
            ExpireTime = expireTime;
        }

        public void SetCanEdit(bool canEdit = false)
        {
            CanEdit = canEdit;
        }
    }
}
