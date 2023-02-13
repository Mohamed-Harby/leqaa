FROM node:lts-alpine
ENV NODE_ENV=production
WORKDIR /usr/src/app
COPY ["front-end/package.json", "front-end/package-lock.json*", "front-end/npm-shrinkwrap.json*", "./"]
RUN npm install --production --silent && mv ./node_modules ../
COPY . .
EXPOSE 3000
RUN chown -R node /usr/src/app
USER node
WORKDIR /usr/src/app/front-end
CMD ["npm", "start"]
