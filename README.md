# 🛒 E-Commerce API

A modular, layered ASP.NET Core Web API project for a complete e-commerce backend, implementing clean architecture principles.

---

## 📦 Features

✅ RESTful API for products, brands, and types  
✅ Filtering, sorting, searching, and pagination  
✅ Basket management using Redis  
✅ Order creation and delivery methods  
✅ JWT Authentication & Authorization with Identity  
✅ Unit of Work and Generic Repository pattern  
✅ Specification pattern for complex queries  
✅ Service Manager abstraction  
✅ Global exception handling  
✅ Response caching

---

## 🧱 Project Structure


---

## 🚀 Endpoints Overview

### 🛍️ Products (Session 1 & 3)
- `GET /GetAllProducts`
- `GET /GetBrands`
- `GET /GetAllTypes`
- `GET /GetProductById`
- `GET /filterationbrandtypetoall`
- `GET /sorting`
- `GET /searchbyname`
- `GET /pagination`

### ❌ Error Handling (Session 4)
- `GET /not-found`
- `GET /internal-server-error`
- `GET /validation-error`

### 🧺 Basket (Session 5)
- `GET /CreateBasket`
- `GET /GetBasket`
- `GET /DeleteBasket`

### 🔐 Authentication (Session 6)
- `GET /login`
- `GET /register`
- `GET /checkemail`
- `GET /GetCurrentUser`
- `GET /getcurrentaddress`
- `PUT /UpdateAddress`

### 🧾 Orders (Session 7)
- `POST /CreateOrder`
- `GET /AllDeliveryMethods`
- `GET /GetAllOrders`
- `GET /GetOrderById`

---

## 🛠️ Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server + Redis
- Identity + JWT
- AutoMapper
- Swagger (OpenAPI)

---

## 📚 Design Patterns Used

- ✅ Unit of Work
- ✅ Generic Repository
- ✅ Specification Pattern
- ✅ Service Manager Pattern

---

## ▶️ How to Run

```bash
git clone https://github.com/yourusername/ecommerce-api.git
cd ecommerce-api
update appsettings.json (connection strings, JWT, Redis)
dotnet run
![capture_250621_214538](https://github.com/user-attachments/assets/70fc1e92-5f09-4881-a61d-ed9ad4641f73)
