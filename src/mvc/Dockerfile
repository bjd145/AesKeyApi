FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "aeskeyui.dll"]