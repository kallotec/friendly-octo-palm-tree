# TrackMyJob.Data

## First time run

Creates and migrates the db

`dotnet ef database update`

## Creating new migrations

Ensure the tools are installed

`dotnet tool install --global dotnet-ef`
`dotnet tool update --global dotnet-ef`

Add a migration when you modify the model

`dotnet ef migrations add 20250326_InitialSchema`

Apply the migration to update the database:

`dotnet ef database update`

## Assumptions

- No business logic in requirements yet, so have omitted any `Services`
