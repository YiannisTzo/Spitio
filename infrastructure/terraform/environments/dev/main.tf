resource "azurerm_resource_group" "spitio_dev" {
  name     = var.resource_group_name
  location = var.location

  tags = var.tags
}