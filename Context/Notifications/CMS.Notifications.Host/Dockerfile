FROM microsoft/dotnet:2.2-sdk AS builder
WORKDIR /app

COPY . .

RUN dotnet publish -c Release -o /out

FROM microsoft/dotnet:2.2-sdk AS runtime

COPY --from=builder /out /app
COPY --from=builder /app/cms-evo-firebase-adminsdk.json /app/cms-evo-firebase-adminsdk.jsols
WORKDIR /app

ENTRYPOINT [ "dotnet", "CMS.Notifications.Host.dll" ]
