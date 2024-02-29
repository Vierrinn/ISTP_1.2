using System;
using System.Collections.Generic;

namespace ConferencesDomain.Model;

public partial class User : Entity
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<SignUp> SignUps { get; set; } = new List<SignUp>();
}
