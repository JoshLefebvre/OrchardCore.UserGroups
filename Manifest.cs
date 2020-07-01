using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "UserGroups",
    Author = "LefeWare Solutions",
    Website = "https://LefeWareSolutions.com",
    Version = "1.0.0",
    Description = "The UserGroups module provides user group management features.",
    Dependencies = new[]
    {
        "OrchardCore.Contents",
        "OrchardCore.Title",
    },
    Category = "Security"
)]
