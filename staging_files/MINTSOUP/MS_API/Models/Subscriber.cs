using System;
using System.Collections.Generic;

namespace MS_API.Models;

public partial class Subscriber
{
    public Guid Id { get; set; }

    public Guid? FkVieweridSubscriber { get; set; }

    public Guid? FkShowidSubscribie { get; set; }

    public string Membershipstatus { get; set; } = null!;

    public DateTime Subscribedate { get; set; }

    public DateTime Subscriptionupdatedate { get; set; }

    public virtual Show? FkShowidSubscribieNavigation { get; set; }

    public virtual Viewer? FkVieweridSubscriberNavigation { get; set; }
}
