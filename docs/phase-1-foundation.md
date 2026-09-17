# Phase 1 — Foundation

## Overview

Phase 1 established the initial structure and engineering foundation of the Spitio application.

The objective was to create a clean starting point for the application while establishing the basic development workflow, project structure, source control strategy, and CI validation.

---

## Objectives

The main objectives of Phase 1 were:

- Establish the Spitio repository.
- Create the initial .NET solution structure.
- Separate application responsibilities into projects.
- Establish unit and integration test projects.
- Establish the initial Git branching strategy.
- Establish automated CI validation.
- Verify that the solution builds successfully.
- Verify that automated tests execute successfully.

---

## Solution Structure

The Spitio solution is organized into separate projects according to application responsibility.

```text
Spitio/
├── src/
│   ├── Spitio.Api/
│   ├── Spitio.Application/
│   ├── Spitio.Domain/
│   └── Spitio.Infrastructure/
│
├── tests/
│   ├── Spitio.UnitTests/
│   └── Spitio.IntegrationTests/
│
├── .github/
│   └── workflows/
│
├── Spitio.slnx
├── Directory.Build.props
├── global.json
└── .gitignore

Projects
Spitio.Api

Responsible for the application's API layer and HTTP-facing functionality.

Spitio.Application

Contains application-level logic and use cases.

Spitio.Domain

Contains the core domain entities and domain rules.

Spitio.Infrastructure

Contains infrastructure-related implementations and external system integrations.

Spitio.UnitTests

Contains unit tests for domain and application behavior.

Spitio.IntegrationTests

Contains integration-level tests validating interactions between application components.

Branching Strategy

The project uses a controlled branch promotion model.

feature/*
     │
     ▼
    dev
     │
     ▼
    uat
     │
     ▼
   prod

Bug-fix branches follow the same development entry point:

bugfix/*
     │
     ▼
    dev

The intended promotion flow is:

feature/* → dev → uat → prod
bugfix/*  → dev

The project also supports promotion from uat to dr for disaster-recovery purposes.

uat → dr
Pull Requests

Changes are expected to move between branches through pull requests rather than direct changes to protected environments.

The repository uses branch-flow validation through GitHub Actions.

The validation workflow checks whether a pull request follows an approved source-to-target branch relationship.

Examples of valid flows include:

feature/* → dev
bugfix/*  → dev
dev       → uat
uat       → prod
uat       → dr

Invalid branch promotions are rejected by the validation workflow.

Continuous Integration

The project includes GitHub Actions workflows for automated validation.

The CI process validates that the solution can:

Restore dependencies.
Build successfully.
Execute automated tests.

The CI pipeline is executed for relevant repository events and provides an automated verification layer before changes are promoted.

Testing

The project contains separate unit and integration test projects.

The test suite is used to verify both domain behavior and application integration.

Phase 1 established the testing infrastructure that later phases build upon.

Repository Protection

The repository includes branch protection/ruleset configuration for the prod branch.

The production ruleset requires pull requests before merging and prevents force pushes and branch deletion.

Additional branch-flow validation is implemented through GitHub Actions.

Note: GitHub ruleset enforcement may depend on the repository visibility and GitHub plan. The configured rules should therefore be considered together with the GitHub account/repository plan.

Definition of Done

Phase 1 was considered complete when:

 The Spitio repository was established.
 The .NET solution was created.
 Source projects were separated by responsibility.
 Unit test infrastructure was created.
 Integration test infrastructure was created.
 Git branching strategy was established.
 CI validation was established.
 Automated tests executed successfully.
 Production branch protection was configured.
 Branch-flow validation was introduced.
Result

Phase 1 established the engineering foundation required for further development of Spitio.

The project can now move into the domain-model and application-development stages while maintaining automated build and test validation.