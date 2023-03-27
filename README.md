# WebApi NET Core 7 + Apache Kafka + ElasticSearch (preliminar version)

## Overview
This Web API simulates the request for permissions, using the `HttpStatusCode` as the permission granted or permission denied.

All requests made to the API are stored in a file in the `logs` folder thanks to Serilog, requests made at the permission level are indexed in `ElasticSearch` and all permission requests are sent to `Apache Kafka` for queuing and processing later.

Integrated with Apache Kafka and ElasticSearch.

## Stacks
* C#
* NET 7.
* Serilog.
* Apache Kafka.
* ElasticSearch.
* Docker Container.

## Installation
### Apache Kafka
If you don't have an instance of ***Apache Kafka*** in the cloud to test the API, you can install in a docker container on your local machine.
#### Local Installation
* in the `Kafka_Setup` folder we have the `docker-compose.yml` file to instantiate Apache Kafka in a Docker container.
* Go to the `Kafka_Setup` folder via terminal
* Run the command `docker-compose up -d`
* Wait for Apache Kafka to successfully launch in docker.

### ElasticSearch
If you don't have an instance of ***ElasticSearch*** in the cloud to test the API, you can install in a docker container on your local machine.
#### Local Installation
* in the `ElasticSearch_Setup` folder we have the `docker-compose.yml` file to instantiate ElasticSearch in the Docker container.
* Navigate to the `ElasticSearch_Setup` folder via terminal
* Run the command `docker-compose up -d`
* Wait for ***ElasticSearch*** to successfully launch in Docker.
