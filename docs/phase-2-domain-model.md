# Phase 2 — Domain Model

## Overview

Phase 2 established the initial domain model for Spitio.

The objective was to introduce the core business entities and enforce important business rules inside the domain layer rather than relying on the API or infrastructure layers.

The phase focused on modeling customers, properties, cleaning requests, service types, cleaning request status, and property photos.

---

## Objectives

The main objectives of Phase 2 were:

- Establish the initial Spitio domain entities.
- Introduce customer ownership of properties.
- Introduce cleaning requests associated with customers and properties.
- Introduce service types.
- Introduce cleaning request lifecycle status.
- Introduce property photos.
- Enforce domain validation rules.
- Protect entity collections from uncontrolled modification.
- Add domain behavior for managing cleaning requests and property photos.
- Establish unit tests for domain behavior.
- Verify that all unit and integration tests pass.

---

## Domain Project

The domain model is located in:

```text
src/
└── Spitio.Domain/
    └── Entities/

The domain layer contains the core business entities and rules used by the application.

The goal is to keep business rules close to the objects they govern.

Domain Entities

Phase 2 introduced and/or established the following domain entities:

Customer
Property
PropertyPhoto
CleaningRequest
ServiceType
CleaningRequestStatus

Customer

The Customer entity represents a customer using the Spitio service.

Customers are associated with properties that they own or manage.

The customer entity establishes the customer side of the relationship used by the property and cleaning-request domain model.

Property

The Property entity represents a property associated with a customer.

A property contains:

Id
CustomerId
Name
Address

The property validates that:

The property ID is not empty.
The customer ID is not empty.
The property name is not empty.
The property address is not empty.

Example relationship:

Customer
   │
   └── Property
         │
         ├── CleaningRequest
         └── PropertyPhoto

Cleaning Requests

The CleaningRequest entity represents a request for a cleaning service.

A cleaning request contains:

Id
CustomerId
PropertyId
ServiceTypeId
Description
Status

A newly created cleaning request starts with:

Pending

The request then follows a controlled lifecycle.

Pending
   │
   ▼
Confirmed
   │
   ▼
InProgress
   │
   ▼
Completed

Cancellation is also supported where the current status permits it.

Cleaning Request State Rules

The domain model prevents invalid state transitions.

The implemented lifecycle includes:

Pending → Confirmed
Confirmed → InProgress
InProgress → Completed

Invalid operations are rejected by the domain model.

Examples include:

Starting a pending request.
Completing a pending request.
Cancelling a completed request.

These rules are enforced through domain exceptions rather than being left entirely to the API layer.

Cleaning Request Validation

The CleaningRequest entity validates required identifiers and data.

The following conditions are rejected:

Empty request ID.
Empty customer ID.
Empty property ID.
Empty service type ID.
Empty description.

Invalid input results in an ArgumentException.

Property Photos

The PropertyPhoto entity represents a photograph associated with a property.

A property photo contains:

Id
PropertyId
Url

The entity validates that:

The photo ID is not empty.
The property ID is not empty.
The photo URL is not empty.

Property Photo Rules

A property can contain a maximum of three photos.

The Property entity controls the addition of photos through domain behavior.

The following rules are enforced:

A photo must belong to the property.
A photo cannot be added twice.
A property cannot contain more than three photos.

The fourth photo attempt results in an InvalidOperationException.

A photo belonging to another property is also rejected.

Domain Collection Protection

Entity collections are maintained internally and exposed as read-only collections.

For example:

private readonly List<PropertyPhoto> _photos = new();

public IReadOnlyCollection<PropertyPhoto> Photos =>
    _photos.AsReadOnly();


This prevents external callers from directly modifying the internal collection.

Domain changes are instead performed through explicit methods such as:
AddPhoto(...)

The same approach is used for cleaning requests associated with a property.

Property Cleaning Requests

A property can contain cleaning requests associated with that property.

The Property entity controls additions through:

AddCleaningRequest(...)

The method validates that:

The cleaning request is not null.
The cleaning request belongs to the property.
The same cleaning request has not already been added.

Invalid operations result in domain exceptions.

Service Types

The ServiceType entity represents a type of cleaning service available through Spitio.

Cleaning requests reference a service type through:

ServiceTypeId

This keeps the cleaning request independent from a hard-coded list of cleaning services.

Domain Exceptions

The domain model uses standard .NET exceptions to reject invalid operations.

ArgumentException is used for invalid entity construction data.

ArgumentNullException is used when required domain objects are missing.

InvalidOperationException is used when an operation violates the current state or relationship rules of an entity.

Unit Testing

Phase 2 expanded the unit test suite to validate domain behavior.

Tests cover:

Cleaning Requests
Creation with valid data.
Initial pending status.
Confirmation.
Starting a confirmed request.
Completing an in-progress request.
Rejecting invalid state transitions.
Rejecting empty customer IDs.
Rejecting empty property IDs.
Rejecting empty service type IDs.
Rejecting empty descriptions.
Properties
Valid property creation.
Property validation.
Adding cleaning requests.
Rejecting cleaning requests belonging to another property.
Rejecting duplicate cleaning requests.
Property Photos
Valid photo creation.
Rejecting empty property IDs.
Rejecting empty URLs.
Allowing a maximum of three photos.
Rejecting a fourth photo.
Rejecting photos belonging to another property.
Test Result

At the completion of Phase 2, the complete solution test suite passed successfully.

Final result:
Test summary: total: 27, failed: 0, succeeded: 27, skipped: 0

Both unit and integration test projects completed successfully.

Definition of Done

Phase 2 was considered complete when:

 Core domain entities were established.
 Customer relationships were established.
 Property validation rules were implemented.
 Cleaning request lifecycle was implemented.
 Cleaning request validation was implemented.
 Service types were established.
 Property photos were implemented.
 Property photo limits were enforced.
 Domain relationships were validated.
 Domain collections were protected from direct modification.
 Unit tests were added for domain behavior.
 Integration tests continued to pass.
 The complete test suite passed successfully.
Result

Phase 2 established the initial business domain for Spitio.

The application now has a domain model capable of representing customers, properties, cleaning requests, service types, and property photos while enforcing important business rules within the domain layer.

The successful test suite provides a baseline for continuing development into the infrastructure and Terraform phases.