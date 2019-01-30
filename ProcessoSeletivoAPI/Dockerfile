#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/aspnetcore:2.0-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1803 AS build
WORKDIR /src
COPY ["ProcessoSeletivoAPI/ProcessoSeletivoAPI.csproj", "ProcessoSeletivoAPI/"]
RUN dotnet restore "ProcessoSeletivoAPI/ProcessoSeletivoAPI.csproj"
COPY . .
WORKDIR "/src/ProcessoSeletivoAPI"
RUN dotnet build "ProcessoSeletivoAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProcessoSeletivoAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProcessoSeletivoAPI.dll"]