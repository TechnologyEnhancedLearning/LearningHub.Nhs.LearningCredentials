terraform {
  required_providers {
    azurerm = {
        source  = "hashicorp/azurerm"
        version = "=3.0.0"
    }
  }
  backend "azurerm" {
    resource_group_name     = "TerraformStorageRG"
    container_name          = "tfstate"
  }
}
provider "azurerm" {
  features {}
}