#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_DIR="$SCRIPT_DIR/../src/pract6"
cd "$PROJECT_DIR"

# Строка подключения хранится только в appsettings.json.
# EF Core получает её по имени ConnectionStrings:WebApiDatabase.
dotnet ef dbcontext scaffold \
  "Name=ConnectionStrings:WebApiDatabase" \
  Microsoft.EntityFrameworkCore.SqlServer \
  --context WebApiDatabaseContext \
  --context-dir Data \
  --output-dir Models \
  --table Movies \
  --namespace pract6.Models \
  --context-namespace pract6.Data \
  --no-onconfiguring \
  --force
