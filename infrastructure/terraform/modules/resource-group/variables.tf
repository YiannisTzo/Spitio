variable "resource_group_name" {
  description = "Name of the resource group."
  type        = string
}

variable "location" {
  description = "Azure region for the resource group."
  type        = string
}

variable "tags" {
  description = "Tags applied to the resource group."
  type        = map(string)
}

variable "role_assignments" {
  type = map(object({
    role_definition_name = string
    principal_id         = string
    principal_type       = string
  }))
  default = {}
}