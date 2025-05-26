# Migrations

Ensure the tools are installed

`dotnet tool install --global dotnet-ef`
`dotnet tool update --global dotnet-ef`

Add a migration when you modify the model

`dotnet ef migrations add 20250326_InitialSchema`

Apply the migration to update the database:

`dotnet ef database update`
