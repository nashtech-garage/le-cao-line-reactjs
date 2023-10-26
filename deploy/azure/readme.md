# # Deploying AKS On Azure

## Pre-requisites
1. [Azure CLI Installed](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli)
2. Azure subscription created
3. Install az aks cli
4. Install kustomize

Login into your azure subscription by typing `az login` (note that you maybe need to use `az account set` to set the subscription to use). Refer to [this article](https://docs.microsoft.com/en-us/cli/azure/authenticate-azure-cli) for more details

## Deploying using CLI
kubectl apply -k PATH_TO_KUSTOMIZE