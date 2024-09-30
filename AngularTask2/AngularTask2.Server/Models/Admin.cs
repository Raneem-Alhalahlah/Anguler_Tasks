﻿using System;
using System.Collections.Generic;

namespace AngularTask2.Server.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? AdminName { get; set; }

    public string Email { get; set; } = null!;

    public byte[]? PasswordSalt { get; set; }

    public byte[]? PasswordHash { get; set; }

    public string? Password { get; set; }
}
