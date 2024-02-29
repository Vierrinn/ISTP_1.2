using System;
using System.Collections.Generic;

namespace ConferencesDomain.Model;

public partial class SignUp : Entity
{
    public int UserId { get; set; }

    public int ConferenseId { get; set; }

    public virtual Conference Conferense { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
