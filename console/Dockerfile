FROM microsoft/dotnet
WORKDIR /app
COPY . /app
CMD ["dotnet","run"]



# 生产版
# FROM microsoft/dotnet:sdk as dev
# WORKDIR /code
# COPY . /code
# RUN dotnet restore
# RUN dotnet publish -c Release -o out

# FROM microsoft/dotnet:runtime
# WORKDIR /app
# COPY --from=dev /code/out /app
# ENTRYPOINT [ "dotnet","console.dll" ]
