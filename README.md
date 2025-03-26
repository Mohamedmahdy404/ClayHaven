# ClayHaven 🏺🎨 - Handmade Clay E-commerce Platform


<img src="https://raw.githubusercontent.com/Mohamedmahdy404/ClayHaven/refs/heads/master/PresentationLayer/wwwroot/images/Readme1.png" 
     alt="ClayHaven Banner"><br>
🚀 **ClayHaven** is an e-commerce platform built using **ASP.NET MVC (.NET 7)** that enables users to explore and purchase handmade clay designs. This project demonstrates a well-structured backend architecture, secure authentication, and seamless payment integration.

## 🌟 Features

- **🛒 E-commerce Functionality** – Browse, search, and purchase handmade clay products
- **🔒 Authentication & Authorization** – Identity with roles: Admin, Customer, and Buyer (pre-seeded users)
- **💳 Secure Payment Processing** – Integrated with **Stripe** for seamless checkout
- **📦 Order Management** – Track and manage placed orders efficiently
- **🔍 Product Search & Filtering** – Find products quickly with advanced search and filters
- **📱 Responsive UI** – Designed with **Bootstrap, HTML5, and CSS3** for smooth user experience
- **🛠 Scalable Architecture** – Implements **3-Tier Architecture** for clean separation of concerns
- **📌 Repository Pattern** – Uses **Generic Repository Pattern** for maintainable data access
- **⚡ Optimized Performance** – Efficient database interactions using **EF Core Code-First Approach**

## 🚀 Tech Stack

| Technology      | Description |
|---------------|------------|
| **ASP.NET MVC (.NET 6)** | Backend framework for web application |
| **SQL Server** | Database for storing product, user, and order data |
| **Entity Framework Core** | ORM for database interactions |
| **Stripe API** | Payment gateway integration |
| **Bootstrap & jQuery** | Frontend styling and interactivity |
| **Identity Framework** | User authentication and role management |
| **Dependency Injection** | Ensures modular and maintainable code |

## 🏗 Project Architecture

The project follows the **3-Tier Architecture** for clean separation of concerns:

- **Presentation Layer (UI)** – Handles user interactions (Views, Controllers)
- **Business Logic Layer (BLL)** – Implements business rules and logic
- **Data Access Layer (DAL)** – Manages database interactions with **EF Core**

## 📌 Installation & Setup

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/Mohamedmahdy404/ClayHaven.git
cd ClayHaven
```

### 2️⃣ Configure Database & Stripe
- Update `appsettings.json` with your SQL Server connection string and Stripe API keys:
```json
"ConnectionStrings": {
  "DefaultConnection": "."
},
"Stripe": {
  "SecretKey": ".",
  "PublishableKey": "."
}
```
- Apply migrations and seed data:
```bash
dotnet ef database update
```

### 3️⃣ Run the Project
```bash
dotnet run
```

## 👤 Pre-Seeded Admin Credentials
| Role     | Email            | Password   |
|----------|----------------|------------|
| Admin    | admin@clayhaven.com | Admin@123  |
| Customer | customer@clayhaven.com | Customer@123 |
| Buyer    | buyer@clayhaven.com | Buyer@123  |

## 💳 Stripe Payment Testing
Use the following test card details to simulate transactions:
- **Card Number:** `4242 4242 4242 4242`
- **Expiration Date:** Any future date
- **CVV:** Any 3-digit number

## 🌍 Live Demo
🎉 Try out **ClayHaven** live!  
🔗 **[Live Demo](http://clayhaven.runasp.net/)**  

📌 *Note:* The demo might take a few seconds to load initially, as the hosting service may put the app in sleep mode when inactive.


## 📜 License
This project is licensed under the [MIT License](LICENSE).

## 🤝 Contributing
Feel free to fork the repo, create a branch, and submit a pull request with improvements!

## 📢 Feedback & Contact
For feedback, suggestions, or collaboration, connect with me:
- **LinkedIn:** [linkedin.com/in/mohamedmahdy9](https://linkedin.com/in/mohamedmahdy9)
- **GitHub:** [github.com/Mohamedmahdy404](https://github.com/Mohamedmahdy404)

**⭐ If you find this project helpful, give it a star on GitHub!** 🚀
