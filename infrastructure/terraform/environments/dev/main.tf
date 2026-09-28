#Resource Group
module "resource_group" {
  source = "../../modules/resource-group"

  name     = var.name
  location = var.location
  tags     = var.tags

  role_assignments = {
    current_user = {
      role_definition_name = "Contributor"
      principal_id         = data.azurerm_client_config.current.object_id
      principal_type       = "User"
    }
  }
}

#Log Analytics
module "log_analytics" {
  source = "../../modules/log-analytics"

  name                = var.log_analytics_name
  location            = var.location
  resource_group_name = module.resource_group.name
  sku                 = var.log_analytics_sku
  retention_in_days   = var.log_analytics_retention_days
  tags                = var.tags
}