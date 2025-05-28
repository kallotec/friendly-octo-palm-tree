# Migrations

## First time setup

Run: `setup.ps1`

## Creating new migrations

Add a migration when you modify the model

`dotnet ef migrations add 20250326_InitialSchema`

Apply the migration to update the database:

`dotnet ef database update`
