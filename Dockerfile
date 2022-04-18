FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder
WORKDIR /app

COPY . .

WORKDIR /app/CMS.Api

RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

COPY --from=builder /out /app

WORKDIR /app

ENTRYPOINT [ "dotnet", "CMS.Api.dll" ]

