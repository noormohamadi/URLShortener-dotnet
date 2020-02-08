# Url Shortener

This project is a URL shortening service and a link management platform.

![](https://img.shields.io/github/stars/keshavarz13/url-shortener.svg) 
![](https://img.shields.io/github/forks/keshavarz13/url-shortener.svg) 
![](https://img.shields.io/github/issues/keshavarz13/url-shortener.svg)

## Build

### Build migration
Use the flowing commands to setup database migration.

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add $migration_name
dotnet ef database update
```

Use flowing command for use last migrated database.

```bash
dotnet ef database update
```

### Run project
Use the flowing command to run the project.

```bash
dotnet run 
```
Now listening on: [http://localhost:5000](http://localhost:5000)

## Usage
for create a short url use this curl command: 
```b
 curl --location --request POST 'http://localhost:5000/urls' \
--header 'Content-Type: application/json' \
--data-raw '{"Url" : "$LongUrl}'
```
for redirect to your url:
```b
curl --location --request GET "http://localhost:5000/redirect/$ShortUrl" 
```

## Authors
created by [Mohammad Noormohammadi](https://github.com/noormohamadi)