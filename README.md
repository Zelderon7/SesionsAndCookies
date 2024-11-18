# ASP.NET Core MVC Application with Cookies and Sessions

## Overview

This is a simple ASP.NET Core MVC application demonstrating the use of cookies and session state. The application shows how to store and retrieve information using cookies and sessions, providing examples of how these can be used to maintain user-specific data.

Made for Web Development @ Vocational School of Electrical Engineering and Electronics.

## Features
- **Cookies**: Store user preferences like theme settings or username.
- **Sessions**: Store temporary data like shopping cart information or logged-in user details.

## Prerequisites
- .NET SDK 6.0 or later
- Visual Studio 2022 or Visual Studio Code
- Basic understanding of ASP.NET Core MVC

## Getting Started

### Cloning the Repository
Clone this repository using the following command:
```bash
https://github.com/batfiowoof/SessionAndCookies.git
```

### Setting Up
1. Open the project in Visual Studio or Visual Studio Code.
2. Restore the required packages by running:
   ```bash
   dotnet restore
   ```
3. Run the application using:
   ```bash
   dotnet run
   ```

The application should be running at `https://localhost:5001` or `http://localhost:5000`.

## Usage

### Cookies Example
- The application uses cookies to store user preferences, such as the username.
- You can access the "Set Cookie" and "Get Cookie" functionality by navigating to `/Cookie/Set` and `/Cookie/Get`.
- **Set Cookie**: Stores a username in a cookie that expires in 7 days.
- **Get Cookie**: Reads and displays the stored username.

### Sessions Example
- The application uses sessions to store a counter that increments each time the page is refreshed.
- You can access this by navigating to `/Session/Index`.
- This example demonstrates how to use session state to keep track of user-specific data during their visit.

## Code Structure
- **Controllers**:
  - `CookieController`: Handles setting and getting cookies.
  - `SessionController`: Demonstrates session management with a simple counter.
- **Startup Configuration**:
  - Session and cookie configuration is done in the `Startup.cs` file to add the necessary middleware.

### Startup.cs Configuration
To enable cookies and sessions, make sure the following services are added to `Startup.cs`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
    services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(30);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseSession();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });
}
```

## Important Notes
- **Cookies** are used for storing small amounts of data on the client-side, which can be useful for user preferences and tracking.
- **Sessions** provide server-side storage for user data, making them ideal for sensitive information that you do not want to expose in cookies.
- Sessions rely on cookies to maintain state between requests, so they must be enabled in the browser for sessions to work properly.
