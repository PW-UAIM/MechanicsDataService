#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["majumi.CarService.MechanicsDataService.Model/majumi.CarService.MechanicsDataService.Model.csproj", "majumi.CarService.MechanicsDataService.Model/"]
COPY ["majumi.CarService.MechanicsDataService.Rest/majumi.CarService.MechanicsDataService.Rest.csproj", "majumi.CarService.MechanicsDataService.Rest/"]
COPY ["majumi.CarService.MechanicsDataService.Rest.Model/majumi.CarService.MechanicsDataService.Rest.Model.csproj", "majumi.CarService.MechanicsDataService.Rest.Model/"]
COPY ["majumi.CarService.MechanicsDataService.Rest.Tests/majumi.CarService.MechanicsDataService.Rest.Tests.csproj", "majumi.CarService.MechanicsDataService.Rest.Tests/"]
RUN dotnet restore "majumi.CarService.MechanicsDataService.Rest/majumi.CarService.MechanicsDataService.Rest.csproj"
COPY . .
WORKDIR "/src/majumi.CarService.MechanicsDataService.Rest"
RUN dotnet build "majumi.CarService.MechanicsDataService.Rest.csproj" -c Production -o /app/build

FROM build AS publish
RUN dotnet publish "majumi.CarService.MechanicsDataService.Rest.csproj" -c Production -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "majumi.CarService.MechanicsDataService.Rest.dll"]