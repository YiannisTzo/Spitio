output "name" {
  description = "Name of the resource group."
  value       = azurerm_resource_group.rg.name
}

output "id" {
  description = "Resource ID of the resource group."
  value       = azurerm_resource_group.rg.id
}