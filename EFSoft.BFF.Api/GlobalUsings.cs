﻿global using System.Diagnostics.CodeAnalysis;
global using System.Net.Http.Headers;
global using System.Reflection;
global using System.Text;
global using System.Text.Json;
global using Asp.Versioning;
global using Asp.Versioning.ApiExplorer;
global using Carter;
global using EFSoft.Bff.Application.Products.CreateProduct;
global using EFSoft.Bff.Application.Products.DeleteProduct;
global using EFSoft.Bff.Application.Products.GetProduct;
global using EFSoft.Bff.Application.Products.GetProducts;
global using EFSoft.Bff.Application.Products.UpdateProduct;
global using EFSoft.BFF.Api.Customers.CreateCustomer;
global using EFSoft.BFF.Api.Customers.DeleteCustomer;
global using EFSoft.BFF.Api.Customers.GetAllCustomers;
global using EFSoft.BFF.Api.Customers.GetCustomer;
global using EFSoft.BFF.Api.Customers.GetCustomers;
global using EFSoft.BFF.Api.Customers.UpdateCustomer;
global using EFSoft.BFF.Api.Exceptions;
global using EFSoft.BFF.Api.Inventory.CreateInventory;
global using EFSoft.BFF.Api.Inventory.GetInventory;
global using EFSoft.BFF.Api.Inventory.UpdateInventory;
global using EFSoft.BFF.Api.Orders.CreateOrder;
global using EFSoft.BFF.Api.Orders.GetCustomerOrders;
global using EFSoft.BFF.Api.Orders.GetOrder;
global using EFSoft.BFF.Api.Orders.UpdateOrder;
global using EFSoft.BFF.Api.Orders.UpdateOrderStatus;
global using EFSoft.BFF.Api.Setup;
global using EFSoft.BFF.Application.Customers.CreateCustomer;
global using EFSoft.BFF.Application.Customers.DeleteCustomer;
global using EFSoft.BFF.Application.Customers.GetAllCustomers;
global using EFSoft.BFF.Application.Customers.GetCustomer;
global using EFSoft.BFF.Application.Customers.GetCustomers;
global using EFSoft.BFF.Application.Customers.UpdateCustomer;
global using EFSoft.BFF.Application.Inventory.CreateInventory;
global using EFSoft.BFF.Application.Inventory.GetInventory;
global using EFSoft.BFF.Application.Inventory.UpdateInventory;
global using EFSoft.BFF.Application.Orders.CreateOrder;
global using EFSoft.BFF.Application.Orders.GetCustomerOrders;
global using EFSoft.BFF.Application.Orders.GetOrder;
global using EFSoft.BFF.Application.Orders.UpdateOrder;
global using EFSoft.BFF.Application.Orders.UpdateOrderStatus;
global using EFSoft.BFF.Domain;
global using EFSoft.BFF.Domain.Orders.Enums;
global using EFSoft.Products.Api.CreateProduct;
global using EFSoft.Products.Api.DeleteProduct;
global using EFSoft.Products.Api.GetProduct;
global using EFSoft.Products.Api.GetProducts;
global using EFSoft.Products.Api.UpdateProduct;
global using EFSoft.Shared.Cqrs.Configuration;
global using FluentValidation;
global using MediatR;
global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Http.Features;
global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Http.Resilience;
global using Microsoft.Extensions.Options;
global using Microsoft.FeatureManagement;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using Polly;
global using Swashbuckle.AspNetCore.SwaggerGen;
