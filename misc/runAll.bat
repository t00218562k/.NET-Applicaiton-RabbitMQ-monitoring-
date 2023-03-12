@echo off
setlocal enabledelayedexpansion

set projects[0]=%CD%\Consumers\Airlines\Consumer.csproj
set projects[1]=%CD%\Consumers\AUS\Consumer.csproj
set projects[2]=%CD%\Consumers\EU\Consumer.csproj
::set projects[3]=%CD%\Consumers\Payments\Consumer.csproj
::set projects[4]=%CD%\Consumers\Refunds\Consumer.csproj
::set projects[5]=%CD%\Consumers\Trains\Consumer.csproj
::set projects[6]=%CD%\Consumers\US\Consumer.csproj
::set projects[7]=%CD%\Consumers\User\Consumer.csproj

for /L %%i in (0, 1, 2) do (
  start cmd /c dotnet run --project !projects[%%i]!
)

start cmd /c dotnet run --project %CD%\Producer\Producer.csproj