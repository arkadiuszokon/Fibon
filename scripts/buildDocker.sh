dotnet publish ./src/Fibon.Api -c Release -o ./bin/Docker
dotnet publish ./src/Fibon.Service -c Release -o ./bin/Docker


docker build -t fibon-api ./src/Fibon.Api
docker build -t fibon-service ./src/Fibon.Service