resource "azurerm_resource_group" "LearningCredentialsResourceGroup" {
    name        = var.ResourceGroupName
    location    = var.ResourceGroupLocation
}

resource "azurerm_service_plan" "LearningCredentialsServicePlan" {
  name                = "learninghub-learningcredentials-app-service-plan"
  location            = azurerm_resource_group.LearningCredentialsResourceGroup.location
  resource_group_name = azurerm_resource_group.LearningCredentialsResourceGroup.name
  sku_name			  = "B3"
  os_type			  = "Linux"
}

resource "azurerm_linux_web_app" "LearningCredentialsLinuxWebApp" {
  name                = var.LearningCredentialsAppName
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

resource "azurerm_app_service_virtual_network_swift_connection" "LearningCredentialsVnetIntegration" {
  app_service_id = azurerm_linux_web_app.LearningCredentialsLinuxWebApp.id
  subnet_id = var.LearningCredentialsSubnetId
}

resource "azurerm_mssql_database" "LearningCredentialsMssqlDatabase" {
  name      = var.DatabaseName
  collation = "SQL_Latin1_General_CP1_CI_AS"
  server_id = var.DatabaseServerId
}