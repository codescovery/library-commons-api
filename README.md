# library-commons-api
A package for common api problems



# Roles Permissions Authorization Handler

You can use our extension method that will help you to authorize your users based on their roles and permissions.
## How to use it
You can use either the default Roles Permissions Authorization Handler or you can create your own Roles Permissions Authorization Handler.
### Using the default Roles Permissions Authorization Handler
```csharp
services.AddDefaultRolesPermissionsAuthorizationHandler();
```

### Using your own Roles Permissions Authorization Handler
```csharp
services.AddRolesPermissionsAuthorizationHandler<YourRolesPermissionsAuthorizationHandler>();
```
YourRolesPermissionsAuthorizationHandler must implement IAuthorizationHandler interface.


# Response Builder Services
You can use our extension method that will help you to build your responses.
## How to use it
```csharp
services.AddResultBuilderService();
```

# Response Result Handlers
It will automatically add all **IResponseResultHandler** implementations to the DI container.
## How to use it
```csharp
services.AddResponseResultHandlers();
services.AddDefaultResponseResultsHandler();
```

# Configure Using Api Configuration 
Enables the use of the configuration file to configure the api.
## How to use it
```csharp
// Configure services
services.ConfigureUsingApiConfiguration(builder.Configuration);

//Configure app 

appBuilder.ConfigureSwaggerUsingApiConfigurations(apiConfigurations.Value);
```

## AppSettings Section 
```json
 "ApiConfiguration": {
    "UseCors": true,
    "UseSwagger": true,
    "UseHealthCheck": true,
    "UseHttpContextAccessor": true,
    "UseControllers": true,
    "UseDefaultJsonSerializerOptions": true,
    "UseHttpsRedirection": true,
    "Cors": [
      {
        "AllowAll": true,
        "PolicyName": "AllowAll",
        "AllowedOrigins": null,
        "AllowedHeaders": null,
        "AllowedMethods": null,
        "AllowedCredentials": null
      }
    ],
    "Swagger": {
      "Title": "Your Api Title",
      "Version": "v1",
      "Description": "Your api description"
    }
  }
```