resource "azurerm_resource_group" "rg" {
  name     = var.name
  location = var.location
  tags     = var.tags
}

resource "azurerm_role_assignment" "rg_role" {
  for_each = var.role_assignments

  scope                = azurerm_resource_group.rg.id
  role_definition_name = each.value.role_definition_name
  principal_id         = each.value.principal_id
  principal_type       = each.value.principal_type
}