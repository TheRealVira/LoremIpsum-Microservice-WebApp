# LoremIpsum-Microservice-WebApp
This high responsible, dynamically scalable, near to zero down-time approachable web-application is based on microservices, docker, ASP.Net, Angular, and much more!

## Publish
A published version can be found [here](https://lipsumwebapp.azurewebsites.net/lorem-ipsum)

## Dependencies
To build or edit this project you would  need the following software packages installed:
- [Node.js: v10.13.0](https://nodejs.org/en/download)
- [npm:     6.4.1](https://www.npmjs.com/get-npm)
- [dotnet:  2.2.100-preview3-009430](https://www.microsoft.com/net/download/dotnet-core/2.2)
- [Docker:  18.06.1-ce, build e68fc7a](https://docs.docker.com/docker-for-windows/install/)

## How to build this project on Windows 10
1. Start Docker
2. Switch to Linux containers
3. Share a drive
4. Go to the root directory of this repo and start powershell
5. Run `.\buildProjectFromScratch.ps1`
6. Run `docker-compose up -d`
7. Have fun!

## How to take down this project ones it has been run
Run `docker-compose down` inside the projects' root directory.

## What are Microservices?
> *"Microservices - also known as the microservice architecture - is an architectural style that structures an application as a collection of loosely coupled services, which implement business capabilities. The microservice architecture enables the continuous delivery/deployment of large, complex applications. It also enables an organization to evolve its technology stack."*
~ Source: https://microservices.io/, 01.11.2018

## Why is using microservices so essantially better than a monolithic project architecture?
- Scalability
  - Each and every microservice is able to either gain/loos on population, they also can be called on command and killed on will. **You** decide when or why a service (a part of ones system) should or should not be active and reduce your systems power/memory/bandwidth.
- Money
  - Of course with scalability comes money safings! Reducing the need for power/memory/bandwith will also reduce your costs.
- Zero-Downtime
  - The more modular a project, the less the propability of one SPF! (Single Point of Failure)
- And much much more
  - As you can see microservices enable developers, clients, and owner way more modularity and options for a better and less pricey experience!
