global using System.Diagnostics.CodeAnalysis;
global using System.Net.Http.Headers;
global using System.Reflection;
global using System.Text;
global using System.Text.Json;

global using EFSoft.BFF.Api.Exceptions;
global using EFSoft.BFF.Api.Helpers;
global using EFSoft.BFF.Api.MicroServices.Customers;
global using EFSoft.BFF.Api.MicroServices.Customers.Commands;
global using EFSoft.BFF.Api.MicroServices.Customers.Models;
global using EFSoft.BFF.Api.MicroServices.Customers.Queries.GetCustomer;
global using EFSoft.BFF.Api.MicroServices.Customers.Queries.GetCustomers;
global using EFSoft.BFF.Api.MicroServices.Orders.Commands;
global using EFSoft.BFF.Api.MicroServices.Orders.Models;
global using EFSoft.BFF.Api.MicroServices.Orders.Queries.GetCustomerOrders;
global using EFSoft.BFF.Api.MicroServices.Orders.Queries.GetOrder;
global using EFSoft.BFF.Api.Setup;

global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
