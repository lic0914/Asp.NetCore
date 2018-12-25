FROM microsoft/dotnet as env
WORKDIR /code
COPY *.csproj ./
RUN dotnet restore 
COPY . ./
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet
WORKDIR /app
COPY --from=env /code/out ./

EXPOSE 80
ENTRYPOINT ["dotnet","User.API.dll"]