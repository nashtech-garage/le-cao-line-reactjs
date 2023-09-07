# Account

Account management and integrative with Keycloak

## Account Service Architecture

![image](https://user-images.githubusercontent.com/43058555/201387025-617fb0a3-fd16-47e1-8e98-cbd86a4c46e1.png)
- The service that provides authentication and authorization for web application include 4 main services/controller:
  + Account Controller: provides API for authentication and authorization of the application.
  + Keycloak service: provides API for users to login the system.
  + Admin Keycloak service: provides API for users information, password changing.
  + Kafka Producer service: sends event to Kafka message broker.
  + Consul service: integrates with Consul Service Registry
  
