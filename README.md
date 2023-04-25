# Steam
run:
    docker-compose up -d --build


install .net ef:
    dotnet tool install --global dotnet-ef

Create Migration:
    dotnet ef migrations add <MigrationName>
