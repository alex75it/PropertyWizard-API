# Property Wizard Web API

Web API to retrieve Property Wizard data.

=== SUSPENDED ===

  
    
    
      
        


## API usage

### GET /

Response: "Web API version {version}"

### GET /ping

Response: "pong"

## How to 

### Run locally

Start the server executing `npm run start`.  
Or use the `start server.bat` file in Windows.

### Deploy

Execute `npm run deploy` that call `gcloud app deploy` to deploy the application on Google App Engine.  

## Tech stuff

I'm following this tutorial:
[Shipping NodeJS with Docket and Codeship](https://blog.risingstack.com/shipping-node-js-applications-with-docker-and-codeship/)  

Docker: https://hub.docker.com/r/alessandropiccione/property-wizard-web-api/

Setup webhook for Docker Hub trigger.

Configured Codeship to access GitHub projects.
Set up a project in Codeship for this project.
