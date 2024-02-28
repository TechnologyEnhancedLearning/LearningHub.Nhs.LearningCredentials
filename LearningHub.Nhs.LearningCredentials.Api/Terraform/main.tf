resource "azurerm_resource_group" "LearningCredentialsResourceGroup" {
    name        = "LearningCredentialsRG"
    location    = "uksouth"
}

resource "azurerm_service_plan" "LearningCredentialsServicePlan" {
  name                = "learninghub-learningcredentials-app-service-plan"
  location            = azurerm_resource_group.LearningCredentialsResourceGroup.location
  resource_group_name = azurerm_resource_group.LearningCredentialsResourceGroup.name
  sku_name			  = "B1"
  os_type			  = "Linux"
}

resource "azurerm_linux_web_app" "LearningCredentialsLinuxWebApp" {
  name                = "learninghub-learningcredentials-app"
  location            = azurerm_resource_group.LearningCredentialsResourceGroup.location
  resource_group_name = azurerm_resource_group.LearningCredentialsResourceGroup.name
  service_plan_id     = azurerm_service_plan.LearningCredentialsServicePlan.id
  site_config {
	app_command_line  = "dotnet Learninghub.Nhs.LearningCredentialsApi.dll"
	application_stack {
	  dotnet_version = "6.0"
	}
  }
}

resource "azurerm_mssql_database" "LearningCredentialsMssqlDatabase" {
  name                = "LearningCredentials"
  collation           = "SQL_Latin1_General_CP1_CI_AS"
  server_id           = "/subscriptions/66516f71-f3d4-4911-b900-c6e4690a5b15/resourceGroups/UKS-ELFH-DEVLEARNINGHUBNHSUK-RG/providers/Microsoft.Sql/servers/uks-learninghubnhsuk-dev-dbs"
}