FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/MyLearningProject.Web.Host/MyLearningProject.Web.Host.csproj", "src/MyLearningProject.Web.Host/"]
COPY ["src/MyLearningProject.Web.Core/MyLearningProject.Web.Core.csproj", "src/MyLearningProject.Web.Core/"]
COPY ["src/MyLearningProject.Application/MyLearningProject.Application.csproj", "src/MyLearningProject.Application/"]
COPY ["src/MyLearningProject.Core/MyLearningProject.Core.csproj", "src/MyLearningProject.Core/"]
COPY ["src/MyLearningProject.EntityFrameworkCore/MyLearningProject.EntityFrameworkCore.csproj", "src/MyLearningProject.EntityFrameworkCore/"]
WORKDIR "/src/src/MyLearningProject.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/MyLearningProject.Web.Host", "src/MyLearningProject.Web.Host"]
COPY ["src/MyLearningProject.Web.Core", "src/MyLearningProject.Web.Core"]
COPY ["src/MyLearningProject.Application", "src/MyLearningProject.Application"]
COPY ["src/MyLearningProject.Core", "src/MyLearningProject.Core"]
COPY ["src/MyLearningProject.EntityFrameworkCore", "src/MyLearningProject.EntityFrameworkCore"]
WORKDIR "/src/src/MyLearningProject.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MyLearningProject.Web.Host.dll"]
