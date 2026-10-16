$ErrorActionPreference = "Stop"

$projectPath = Join-Path $PSScriptRoot "..\src\pract6"
Set-Location $projectPath

# Строка подключения хранится только в appsettings.json.
# EF Core получает её по имени ConnectionStrings:WebApiDatabase.
dotnet ef dbcontext scaffold `
    "Name=ConnectionStrings:WebApiDatabase" `
    Microsoft.EntityFrameworkCore.SqlServer `
    --context WebApiDatabaseContext `
    --context-dir Data `
    --output-dir Models `
    --table Movies `
    --namespace pract6.Models `
    --context-namespace pract6.Data `
    --no-onconfiguring `
    --force
