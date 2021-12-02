﻿using System.ComponentModel.DataAnnotations;

namespace Identity.Api.Requests;

public class UpdateEmailRequest
{
    [Required, EmailAddress, MaxLength(255)]
    public string Email { get; set; }
}