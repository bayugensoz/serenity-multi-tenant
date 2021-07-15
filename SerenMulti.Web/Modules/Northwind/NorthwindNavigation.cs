using Serenity.Navigation;
using MyPages = SerenMulti.Northwind.Pages;
using Northwind = SerenMulti.Northwind.Pages;

[assembly: NavigationMenu(7000, "Northwind", icon: "fa-anchor")]
[assembly: NavigationLink(7001, "Northwind/Customers", typeof(Northwind.CustomerController), icon: "fa-credit-card")]
[assembly: NavigationLink(7002, "Northwind/Orders", typeof(Northwind.OrderController), icon: "fa-shopping-cart")]
[assembly: NavigationLink(7003, "Northwind/Products", typeof(Northwind.ProductController), icon: "fa-cube")]
[assembly: NavigationLink(7004, "Northwind/Suppliers", typeof(Northwind.SupplierController), icon: "fa-truck")]
[assembly: NavigationLink(7005, "Northwind/Shippers", typeof(Northwind.ShipperController), icon: "fa-ship")]
[assembly: NavigationLink(7006, "Northwind/Categories", typeof(Northwind.CategoryController), icon: "fa-folder-o")]
[assembly: NavigationLink(7007, "Northwind/Regions", typeof(Northwind.RegionController), icon: "fa-map-o")]
[assembly: NavigationLink(7008, "Northwind/Territories", typeof(Northwind.TerritoryController), icon: "fa-puzzle-piece")]
[assembly: NavigationLink(7009, "Northwind/Reports", typeof(Northwind.ReportsController), icon: "fa-files-o")]
[assembly: NavigationLink(7010, "Northwind/Tags", typeof(MyPages.TagsController), icon: "fa-tags")]