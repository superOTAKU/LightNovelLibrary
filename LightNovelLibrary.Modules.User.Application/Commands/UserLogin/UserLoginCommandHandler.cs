using LightNovelLibrary.BuildingBlocks.Infrastructure.Security;
using LightNovelLibrary.Modules.User.Application.Dtos;
using LightNovelLibrary.Modules.User.Application.Exceptions;
using LightNovelLibrary.Modules.User.Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LightNovelLibrary.Modules.User.Application.Commands.UserLogin;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, AuthenticationTokenDto>
{
    private readonly IUserRepository _repository;
    private readonly ISecurityKeyProvider _securityKeyProvider;
    private readonly IConfiguration _configuration;

    public UserLoginCommandHandler(IUserRepository repository, ISecurityKeyProvider securityKeyProvider,
        IConfiguration configuration)
    {
        _repository = repository;
        _securityKeyProvider = securityKeyProvider;
        _configuration = configuration;
    }

    public Task<AuthenticationTokenDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var user = _repository.GetUserByUserName(request.UserName)
            ?? throw new UserNameNotExistsException(request.UserName);
        if (user.Password != request.Password)
        {
            throw new PasswordNotMatchException();
        }
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.Sid, user.UserId.ToString()),
            new Claim(SecurityClaimTypes.PrincipleType, PrincipalType.User),
            new Claim(ClaimTypes.Role, UserRoles.User.FullName)
        };
        var signingCredentials = new SigningCredentials(_securityKeyProvider.GetSecretKey(),
            SecurityAlgorithms.RsaSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddMinutes(10)
            );
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return Task.FromResult(new AuthenticationTokenDto
        {
            Token = token
        });
    }
}

