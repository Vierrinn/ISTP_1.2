using System;
using System.Collections.Generic;

namespace ConferencesDomain.Model;

public partial class Topic: Entity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Conference> Conferences { get; set; } = new List<Conference>();
}
