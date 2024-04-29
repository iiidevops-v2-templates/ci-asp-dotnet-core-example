#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# 使用官方的ASP.NET運行時作為基本映像
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# 使用官方的.NET SDK作為構建映像
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# 只複製項目文件以利用層緩存
COPY app/ASP-MVC-example/ASP-MVC-example.csproj .
RUN dotnet restore "ASP-MVC-example.csproj"

# 複製整個應用程序並構建它
COPY app/ASP-MVC-example .
RUN dotnet build "ASP-MVC-example.csproj" -c Release -o /app/build

# 創建發佈的目標
FROM build AS publish
RUN dotnet publish "ASP-MVC-example.csproj" -c Release -o /app/publish

# 創建最終運行時映像
FROM base AS final
WORKDIR /app
ENV TZ="Asia/Taipei"

# 從'publish'階段複製已發佈的輸出
COPY --from=publish /app/publish .

# 設置應用程序的入口點
ENTRYPOINT ["dotnet", "ASP-MVC-example.dll"]
