using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Heals.CSX.Mall.Orders
{
    /// <summary>
    /// Represents a snapshot of the item that was ordered.
    /// </summary>
    public class ProductItemOrdered : FullAuditedAggregateRoot<Guid>
    {
        public ProductItemOrdered(Guid productId, string productSeqId, string productName, string pictureUri)
        {
            Guard.Against.Null(productId, nameof(productId));
            Guard.Against.NullOrEmpty(productSeqId, nameof(productSeqId));
            Guard.Against.NullOrEmpty(productName, nameof(productName));
            Guard.Against.NullOrEmpty(pictureUri, nameof(pictureUri));

            ProductId = productId;
            ProductSeqId = productSeqId;
            ProductName = productName;
            PictureUri = pictureUri;
        }

        
        /// <summary>
        /// product primary key
        /// </summary>
        public Guid ProductId { get; private set; }
        /// <summary>
        /// Server auto generated
        /// </summary>
        [Column("ProductSeqId")]
        public string ProductSeqId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }

        protected ProductItemOrdered()
        {
        }

        public ProductItemOrdered(
            Guid id,
            Guid productId,
            string productSeqId,
            string productName,
            string pictureUri
        ) : base(id)
        {
            Guard.Against.Null(productId, nameof(productId));
            Guard.Against.NullOrEmpty(productSeqId, nameof(productSeqId));
            Guard.Against.NullOrEmpty(productName, nameof(productName));
            Guard.Against.NullOrEmpty(pictureUri, nameof(pictureUri));

            ProductId = productId;
            ProductSeqId = productSeqId;
            ProductName = productName;
            PictureUri = pictureUri;
        }
    }
}
