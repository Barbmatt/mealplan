FROM ubuntu:24.04

WORKDIR /backend

EXPOSE 5000

RUN apt update && apt install -y dotnet-sdk-8.0

ADD . /backend/

RUN dotnet build backend.csproj

CMD dotnet run backend.csproj