FROM node:18.19.1-alpine

WORKDIR /frontend

EXPOSE 3000

ADD . /frontend/

RUN npm install
RUN npm run build

CMD [ "npm", "start" ]