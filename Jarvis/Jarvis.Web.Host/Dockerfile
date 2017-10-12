FROM microsoft/dotnet:runtime
WORKDIR /app
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000
COPY ./publish /app
CMD ["dotnet", "Jarvis.Web.Host.dll"]