﻿using MediatR;

namespace EasyShoping.Application.Features.Auth.Commands.Register;

public class RegisterCommandRequest:IRequest<Unit>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
