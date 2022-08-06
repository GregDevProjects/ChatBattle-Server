FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /app

COPY . .

EXPOSE 5194

RUN dotnet restore

CMD dotnet run

# docker build . -t 'chatbattle_server' && docker run -p 5194:5194 'chatbattle_server' 