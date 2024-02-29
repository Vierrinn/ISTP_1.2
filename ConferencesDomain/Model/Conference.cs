using System;
using System.Collections.Generic;

namespace ConferencesDomain.Model;

public partial class Conference : Entity
{
    public string Name { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public decimal? Cost { get; set; }

    public TimeOnly Duration { get; set; }

    public int TopicId { get; set; }

    public int OrgaizerId { get; set; }

    public virtual Organizer Orgaizer { get; set; } = null!;

    public virtual ICollection<SignUp> SignUps { get; set; } = new List<SignUp>();

    public virtual Topic Topic { get; set; } = null!;
}
