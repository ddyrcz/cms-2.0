FROM microsoft/dotnet:2.2-sdk AS builder
WORKDIR /app

COPY . .

RUN dotnet publish -c Release -o /out

FROM microsoft/dotnet:2.2-sdk AS runtime

ENV GOOGLE_APPLICATION_CREDENTIALS="/app/cms-evo-firebase-adminsdk.json"
COPY --from=builder /out /app
WORKDIR /app

ENTRYPOINT [ "dotnet", "CMS.Notifications.Host.dll" ]
