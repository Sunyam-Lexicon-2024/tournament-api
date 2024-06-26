﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace IdentityService.WebServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
    [
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResource() {
            Name = "verification",
            UserClaims =
            [
                JwtClaimTypes.Email,
                JwtClaimTypes.EmailVerified,
            ]
        }
    ];

    public static IEnumerable<ApiScope> ApiScopes =>
    [
        new ApiScope(name: "tournamentAPI", displayName: "Tournaments API")
    ];

    public static IEnumerable<ApiResource> ApiResources =>
    [
        new ApiResource("tournamentAPI", "Tournaments API")
        {
            Scopes = { "tournamentAPI" }
        }
    ];

    public static IEnumerable<Client> Clients =>
    [
        new Client
        {
            ClientId = "dev-console",

            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ClientCredentials,

            // secret for authentication
            ClientSecrets =
            {
                new Secret("dev-console-secret".Sha256())
            },

            // scopes that client has access to
            AllowedScopes = { "tournamentAPI" }
        },
        new Client
        {
            ClientId = "dev-web-client",

            AllowedGrantTypes = GrantTypes.Code,

            ClientSecrets =
            {
                new Secret("dev-web-client-secret".Sha256())
            },

            RedirectUris = { "https://localhost:5002/login-oidc" },

            PostLogoutRedirectUris = { "https://localhost:5002/logout-callback-oidc" },

            AllowedScopes = {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "verification"
            }
        }
    ];
}