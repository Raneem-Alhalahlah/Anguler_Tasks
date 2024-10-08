﻿using System;
using System.Collections.Generic;

namespace AngularTask2.Server.Models;

public partial class ContactU
{
    public int MessageId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public DateTime? SubmittedAt { get; set; }
}
