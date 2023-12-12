# PhotoShop

Welcome to PhotoShop, a website where you can view and purchase different photographs!



## About

- ASP.NET Core MVC application
- Uses Entity Framework Core (Code First Approach)
- SQL Server (Azure)
- Stripe payment integration (Test API)
- Published through Azure

### Features

- View all photographs
- View single photograph
- Add photograph to basket
- Increase/Decrease photograph amount in cart menu
- Remove cart item row in cart menu
- Purchase photographs

NOTE: Since the application uses Stripe's test API to simulate a real checkout, it can not actually accept real payments. Therefore, when testing the application, please use the following card number. 

```
4242 4242 4242 4242
```
Properties such as Email, CVC and Cardholder name do not matter, so feel free to enter whatever information you want as long as it is formatted correctly. Make sure however that you are using a valid expiration date, otherwise it will not work.

![App Screenshot](https://i.imgur.com/zYRHWWt.png)