variable "location" {
  description = "Azure region for the environment."
  type        = string
}

variable "resource_group_name" {
  description = "Name of the Azure resource group."
  type        = string
}

variable "tags" {
  description = "Tags applied to Azure resources."
  type        = map(string)
}