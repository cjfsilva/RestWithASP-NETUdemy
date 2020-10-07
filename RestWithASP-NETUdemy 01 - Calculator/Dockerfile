#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mysql:8.0.18
EXPOSE 3306

COPY DBBackup/backup.sql /docker-entrypoint-initdb.d/backup.sql