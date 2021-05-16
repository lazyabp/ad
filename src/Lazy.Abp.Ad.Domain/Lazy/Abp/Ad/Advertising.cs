using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Lazy.Abp.Ad
{
    public class Advertising : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        [MaxLength(AdvertisingConsts.MaxNameLength)]
        public virtual string Name { get; protected set; }

        public virtual string Label { get; protected set; }

        public virtual AdvertisementType AdvertisementType { get; protected set; }

        public virtual int Width { get; protected set; }

        public virtual int Height { get; protected set; }

        /// <summary>
        /// 购买广告位所需要花费
        /// </summary>
        public virtual int? ItemPrice { get; protected set; }

        public virtual bool IsActive { get; protected set; }

        /// <summary>
        /// 广告过期后显示的内容
        /// </summary>
        public virtual string ExpiredContent { get; protected set; }

        public virtual List<AdvertisingItem> Items { get; set; }

        protected Advertising()
        {
        }

        public Advertising(
            Guid id,
            [NotNull] string name,
            string label,
            AdvertisementType advertisementType, 
            int width, 
            int height, 
            int? itemPrice, 
            bool isActive, 
            string expiredContent
        ) : base(id)
        {
            Check.NotNullOrEmpty(name, nameof(name));

            Name = name;
            Label = label;
            AdvertisementType = advertisementType;
            Width = width;
            Height = height;
            ItemPrice = itemPrice;
            IsActive = isActive;
            ExpiredContent = expiredContent;
        }

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
