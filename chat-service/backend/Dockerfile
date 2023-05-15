FROM node:lts-alpine
ENV NODE_ENV=development
WORKDIR /usr/src/
COPY ["chat-service/backend/package.json", "chat-service/backend/package-lock.json*", "chat-service/backend/npm-shrinkwrap.json*","./"] 

RUN npm install --development --silent 
EXPOSE 6969
COPY chat-service/backend .
RUN chown -R node /usr/src/
USER node
CMD ["npm", "start"]
