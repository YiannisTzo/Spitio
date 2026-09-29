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

variable "role_assignments" {
  description = "Role assignments for the resource group."

  type = map(object({
    role_definition_name = string
    principal_id         = string
    principal_type       = string
  }))

  default = {}
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