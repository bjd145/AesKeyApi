# Overview
This Repo contains code for a silly little REST API so I can continue to learn Go and Vue.js
This REST API will generate 256-bit keys that could be use for AES encryption.
This is a sample API only. Do not use in Production 

# Todo
- [x] Create basic API 
- [x] Create UI to get 1 KEY
- [x] POST to API to get more than one key
- [x] Parameterize API to listen on port defined in an ENV variable
- [X] Parameterize UI for REST API endpoint
- [X] Update Kubernetes Deployment manifest for API. Destination - Azure App Services for Containers
- [X] Create deployment for the UI. Destination - Static Website Hosting on Azure Blob Storage (https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-static-website)
- [X] Update azure_deploy.sh to create resources in Azure for application and deploy code.
