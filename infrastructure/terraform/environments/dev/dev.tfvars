location            = "West Europe"
resource_group_name = "rg-spitio-dev"

tags = {
  Application = "Spitio"
  Environment = "dev"
  ManagedBy   = "Terraform"
}

role_assignments = {
  user_contributor = {
    role_definition_name = "Contributor"
    principal_id         = "9aa93699-a50c-46b1-a85f-4f6c51cac385"
    principal_type       = "User"
  }
}

#Log Analytics

log_analytics_name           = "law-spitio-dev"
log_analytics_sku            = "PerGB2018"
log_analytics_retention_days = 7