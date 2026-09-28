variable "name" {
  description = "Name of the resource group."
  type        = string
}

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

#Log Analytics
variable "log_analytics_name" {
  description = "Name of the Log Analytics workspace."
  type        = string
}

variable "log_analytics_sku" {
  description = "SKU for the Log Analytics workspace."
  type        = string
}

variable "log_analytics_retention_days" {
  description = "Number of days to retain Log Analytics data."
  type        = number
}