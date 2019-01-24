FROM microsoft/dotnet:2.2-sdk AS build

RUN mkdir -p /usr/app

# Sets the /usr/app as the active directory
WORKDIR /usr/app

COPY . .

RUN dotnet build -c Release

RUN dotnet publish -c Release -o /usr/app/publish

FROM microsoft/dotnet:2.2-aspnetcore-runtime
EXPOSE 80

WORKDIR /usr/app/dist
COPY --from=build /usr/app/publish .

ENTRYPOINT ["dotnet", "Ritter.Samples.Web.dll"]
