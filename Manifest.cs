using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "UserGroup",
    Author = "LefeWare Learning",
    Website = "https://orchardproject.net",
    Version = "1.0.0",
    Description = "The UserGroup module provides user group management features.",
    Dependencies = new[]
    {
        "OrchardCore.Contents",
        "OrchardCore.Title",
    },
    Category = "Security"
)]
