FROM microsoft/dotnet:2.2-sdk AS builder
WORKDIR /app

COPY . .

RUN dotnet publish -c Release -o /out

FROM microsoft/dotnet:2.2-sdk AS runtime

COPY --from=builder /out /app

WORKDIR /app

ENTRYPOINT [ "dotnet", "CMS.Api.dll" ]

