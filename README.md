# Service Lifecycle

To implement dependency injection, we need to configure a DI container with classes that is participating in DI. DI Container has to decide whether to return a new instance of the service or provide an existing instance. In Program.cs class, we perform this activity on builder.Services method.
 
The lifetime of the service depends on when the dependency is instantiated and how long it lives. And lifetime depends on how we have registered those services.
 
The below three methods define the lifetime of the services,
1.	AddTransient
Transient lifetime services are created each time they are requested. This lifetime works best for lightweight, stateless services.

2.	AddScoped
Scoped lifetime services are created once per request.

3.	AddSingleton
Singleton lifetime services are created the first time they are requested (or when ConfigureServices is run if you specify an instance there) and then every subsequent request will use the same instance.

Once we execute the application, we will see two different Guids are displayed for their respective service types. Now run two instance of UI in two different tabs of the browser like request 1 and request 2.


Request 1
![image](https://user-images.githubusercontent.com/40893318/208575022-de9f845f-4201-4fc3-b661-cb94af8c309d.png)

Request 2
![image](https://user-images.githubusercontent.com/40893318/208575082-0147d9f5-7177-419b-86f9-3f9bc6fdf276.png)

**Observation from Request 1 and Request 2**
 
**Transient service** always returns a new instance even though it’s the same request, that is why operation Ids are
different for first instance and second instance for both the requests (Request 1 and Request 2).
 
In the case of **Scoped service**, a single instance is created per request and the same instance is shared across the request.
That is why operation Ids are the same for first instance as well as second instance of Request 
1. But if we click on refresh button or load the UI on different tab of a browser (which is nothing but Request 
2. new ids are generated.
 
In the case of **Singleton service**, only one instance is created and shared across applications. 
If we click on refresh button or load the UI on the different tab of a browser (which is nothing but Request 2), those ids will remain the same.

# Custom Middleware

**1. Creating a Custom Middleware** 
 Middleware is generally encapsulated in a class and exposed with an extension method. The custom middleware can be built with a class with InvokeAsync() method and RequestDelegate type parameter in the constructor. RequestDelegate type is required in order to execute the next middleware in a sequence.
 Let’s consider an example where we need to create custom middleware to log a request URL in a web application.
 
 ![image](https://user-images.githubusercontent.com/40893318/208640629-c7449b93-b92d-4440-8bd3-c1d071ff7115.png)

 ![image](https://user-images.githubusercontent.com/40893318/208640537-467a4b61-dd6e-4278-bcb9-bcbb4ae3c0f2.png)


In program.cs class:
**app.UseLogUrl();**


**2. ** 
