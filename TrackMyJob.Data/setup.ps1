dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

# create and update db
dotnet ef database update --project TrackMyJob.Data
