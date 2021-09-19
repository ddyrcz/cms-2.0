FROM mcr.microsoft.com/dotnet/sdk:5.0 AS builder
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o /out
FROM mcr.microsoft.com/dotnet/runtime:5.0 AS runtime
ENV GOOGLE_APPLICATION_CREDENTIALS="/app/cms-evo-firebase-adminsdk.json"
COPY --from=builder /out /app
WORKDIR /app
ENTRYPOINT [ "dotnet", "CMS.Notifications.Host.dll" ]
