FROM microsoft/dotnet:2.1-sdk AS builder
WORKDIR /app

COPY ./*.sln ./

COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done

RUN dotnet restore

COPY . .

RUN dotnet publish -c Release -o /out

FROM microsoft/dotnet:2.1-sdk AS runtime

COPY --from=builder /out /app

WORKDIR /app

ENTRYPOINT [ "dotnet", "CMS.Api.dll" ]

