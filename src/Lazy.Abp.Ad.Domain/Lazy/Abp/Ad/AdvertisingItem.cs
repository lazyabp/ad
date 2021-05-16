using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Lazy.Abp.Ad
{
    public class AdvertisingItem : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid AdvertisingId { get; protected set; }

        [MaxLength(AdvertisingItemConsts.MaxTitleLength)]
        public virtual string Title { get; protected set; }

        [MaxLength(AdvertisingConsts.MaxUrlLength)]
        public virtual string Url { get; protected set; }

        [NotNull]
        public virtual string Content { get; protected set; }

        [MaxLength(AdvertisingItemConsts.MaxAltLength)]
        public virtual string Alt { get; protected set; }

        public virtual bool IsActive { get; protected set; }

        public virtual bool IsOnSale { get; protected set; }

        public virtual int DisplayOrder { get; protected set; }

        protected AdvertisingItem()
        {
        }

        public AdvertisingItem(
            Guid id, 
            Guid advertisingId, 
            string title, 
            string url,
            [NotNull] string content, 
            string alt, 
            bool isActive,
            bool isOnSale,
            int displayOrder
        ) : base(id)
        {
            Check.NotNullOrEmpty(content, nameof(content));

            AdvertisingId = advertisingId;
            Title = title;
            Url = url;
            Content = content;
            Alt = alt;
            IsActive = isActive;
            IsOnSale = isOnSale;
            DisplayOrder = displayOrder;
        }

        public void Update(
            string title,
            string url,
            [NotNull] string content,
            string alt)
        {
            Check.NotNullOrEmpty(content, nameof(content));

            Title = title;
            Url = url;
            Content = content;
            Alt = alt;
        }

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
        }

        public void SetOnSale(bool isOnSale)
        {
            IsOnSale = isOnSale;
        }
    }
}
