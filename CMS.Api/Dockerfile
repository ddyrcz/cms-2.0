FROM microsoft/dotnet:sdk as builder
WORKDIR /cms
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

# FROM microsoft/dotnet:aspnetcore-runtime
# WORKDIR /cms
# COPY --from=builder /cms/out .
# ENTRYPOINT [ "dotnet", "CMS.Api.dll" ]