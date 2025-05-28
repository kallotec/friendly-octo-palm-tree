# api setup
dotnet restore
dotnet build

# db setup (dependent on api setup)
& ./TrackMyJob.Data/setup.ps1

# web setup
Set-Location TrackmyJob.Web
npm i
npm run build
Pop-Location
