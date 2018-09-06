#!/bin/bash

#cd deploy
#docker build -t bjd145/aeskeyapi:1.0 .
#docker push bjd145/aeskeyapi:1.0

az login 
az extension add --name webapp
az group create -n MultiContainerExample -l centralus
az appservice plan create -g MultiContainerExample -n bjdlinuxasp --is-linux --sku S1 -l centralus
az webapp create -g MultiContainerExample -n bjdweb003 -p bjdlinuxasp --multicontainer-config-file ./deployment.yml --multicontainer-config-type KUBE

az storage account create -n bjdweb001 -g MultiContainerExample --kind Storagev2 -l centralus --https-only --sku Standard_GRS
az extension add --name storage-preview 
az storage blob service-properties update --account-name bjdweb001 --static-website --404-document 404.html --index-document index.html
az storage blob upload-batch -s src/ui -d '$web' --account-name bjdweb001