#Resource Group
module "resource_group" {
  source = "../../modules/resource-group"

  resource_group_name = var.resource_group_name
  location            = var.location
  tags                = var.tags

  role_assignments = {
    current_user = {
      role_definition_name = "Owner"
      principal_id         = "9aa93699-a50c-46b1-a85f-4f6c51cac385"
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