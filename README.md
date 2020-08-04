## Deployment steps for CMS.Api:
- Go to *__/cms-evo-backend__* folder.
- Build docker image: ```docker build -t ddyrcz/cms-evo:api-latest . ```
- Log in to the DockerHub if not logged in yet.
- Push docker image to the DockerHub: ```docker push ddyrcz/cms-evo:api-latest```
- Log in to the server using SSH.
- Go to *__/apps/cms-evo/api/devops__* folder.
- Pull the latest docker image: ```docker-compose -f docker-compose.yml -f docker-compose.prod.yml pull```
- Update CMS.Api container: ```docker-compose -f docker-compose.yml -f docker-compose.prod.yml up -d```

## Deployment steps for CMS.Notifications.Host:
- Go to *__/cms-evo-backend/Context/Notifications/CMS.Notifications.Host__* folder.
- Build docker image: ```docker build -t ddyrcz/cms-evo:notifications-latest . ```
- Log in to the DockerHub if not logged in yet.
- Push docker image to the DockerHub: ```docker push ddyrcz/cms-evo:notifications-latest```
- Log in to the server using SSH.
- Go to *__/apps/cms-evo/notifications/devops__* folder.
- Pull the latest docker image: ```docker-compose -f docker-compose.yml -f docker-compose.prod.yml pull```
- Update CMS.Notifications.Host container: ```docker-compose -f docker-compose.yml -f docker-compose.prod.yml up -d```
