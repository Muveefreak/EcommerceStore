# (Demo) Auctria Source Code COntainging the following Solutions
# EcommerceStore

this management system that will help the government to manage and process requests for PCR tests

## Architecture Used

Clean Architecture (.Net 8.0).

```python
Code Structure

#Web
  - #API
     - Auctria.EcommerceStore.Web.API (API Endpoint)
#Infrastructure
  - #Infrastructure
     - Auctria.EcommerceStore.Infrastructure (Includes Caching implementation, Entity configurations) 
  - #Infrastructure.Persistence
     - Auctria.EcommerceStore.Infrastructure.Persistence (Persistence implementation)
#Core
  - #Application
     - Auctria.EcommerceStore.Core.Application (EcommerceStore Application Feature implementation) 
  - #Domain
     - Auctria.EcommerceStore.Core.Domain (Entities)
#Tests
     - Auctria.EcommerceStore.Tests.Unit

```

## Technologies Used

```python
# Auctria.EcommerceStore.Web.API
- Swagger for API documentation
- Mediatr - sends a request to the application logic via Irequest Handler

# Auctria.EcommerceStore.Core.Application
- FluentValidation - Api requests validations
- Mediatr - Receives requests from the API and carries out appropriate implementation

# Auctria.EcommerceStore.Core.Domain
- Ef core

# Auctria.EcommerceStore.Infrastructure
- MemCache

# Auctria.EcommerceStore.Infrastructure.Persistence
- Ef Core

# Auctria.EcommerceStore.Tests.Unit
- Xunit
- Moq
- Shouldly
``` 

## Assumptions Made
```python
# Product inventory is not deducted from when a user adds an item to cart, this happens only after order is complete
# A user cannot add more items to cart than is available in the product inventory

```

## Database Structure
![image]()

```

