FROM microsoft/dotnet:sdk

WORKDIR /cms

COPY *.csproj ./

RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out