//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZenGym.Domain.Entities
{
    using System;
    using System.Collections.Generic;
        using ZenGym.Domain.Common;

    public partial class SubscriptionType : BaseEntity
    {
        public SubscriptionType()
        {
            this.Subscriptions = new HashSet<Subscription>();
        }
    
        public string Libelle { get; set; }
        public decimal Amount { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; }

    
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
