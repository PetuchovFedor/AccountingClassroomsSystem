# frontend/Dockerfile

# Stage 1: Сборка приложения
FROM node:20-alpine AS build
WORKDIR /app

COPY ["src/frontend/package.json", "src/frontend/package-lock.json", "./"]
COPY ["src/frontend/kendo-ui-license.txt", "./"]
COPY ["src/frontend/angular.json", "./"]

RUN npm install -g @angular/cli@17
RUN npm install

COPY ["src/frontend/", "./"]
RUN npx kendo-ui-license activate

EXPOSE 4200

CMD ["ng", "serve", "--host", "0.0.0.0"]
