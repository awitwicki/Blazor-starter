# Blazor-starter

.NET 7.0 Blazor based serverside web app with configured **Microsoft.AspNetCore.Identity** (login, register, roles)

![License](https://img.shields.io/badge/License-Apache%20License%202.0-blue)
![Tests](https://img.shields.io/badge/dotnet%20version-6.0-blue)
![Tests](https://img.shields.io/github/stars/awitwicki/Blazor-starter)
![Tests](https://img.shields.io/github/forks/awitwicki/Blazor-starter)
![Tests](https://img.shields.io/github/issues-pr/awitwicki/Blazor-starter)
![Tests](https://img.shields.io/github/last-commit/awitwicki/Blazor-starter)

This project is based on this articles: [ASP.NET core identity setup in blazor application](https://www.pragimtech.com/blog/blazor/asp.net-core-identity-setup-in-blazor-application/).

### First start
After first user registration, user gets all roles.

### Other info

Scaffolded pages are stored in `Areas/Identity/Pages/Account`. There is not all pages are scaffoled, only `Login` and `Register`, if you want more, then use [this steps](https://www.pragimtech.com/blog/blazor/asp.net-core-identity-setup-in-blazor-application/).

Avaliable roles are stored in file `Consts.cs`. This roles automatically added to database ([here](https://github.com/awitwicki/Blazor-starter/blob/4bfef9c49ddb6a736b17b2eb0225a66e3e463414/Blazor-starter/Program.cs#L38)) when application is starting (in file `Program.cs` near database migration code).
