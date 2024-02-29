using System;
using System.Collections.Generic;

namespace ConferencesDomain.Model;

public partial class Organizer : Entity
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Conference> Conferences { get; set; } = new List<Conference>();
}
