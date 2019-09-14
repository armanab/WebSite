# ASP.NET Core WebSite
sample web site with n-layer architecture on ASP.NET core and Code First EF Core and 2 area public and admin

# how to run this project?


1.you first download Package.UI and run project on visual studio 
2.now you must set connection string parameter into appsettings.json in root project
3. run "add-migration -init" in package manage console when  default project is "Package.EntityFrameworkCore" and "update-database"
4.run project !

web site has 2 area mode , one mode Public site with special theme and one another mode dashboard with pashboard theme bootstrap 



## attention:
Please look at the DBinitializer.cs in the "Package.EntityFrameworkCore" layer carefully,You will find admin's username and password
