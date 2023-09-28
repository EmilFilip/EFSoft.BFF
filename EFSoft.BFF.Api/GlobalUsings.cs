global using System.Diagnostics.CodeAnalysis;
global using System.Net.Http.Headers;
global using System.Reflection;
global using System.Text;

global using EFSoft.BFF.Api.CustomerEndpoints;
global using EFSoft.BFF.Api.Customers.Commands;
global using EFSoft.BFF.Api.Customers.GetCustomer;
global using EFSoft.BFF.Api.Customers.GetCustomers;
global using EFSoft.BFF.Api.Customers.Models;
global using EFSoft.BFF.Api.Exceptions;
global using EFSoft.BFF.Api.Helpers;
global using EFSoft.BFF.Api.Setup;

global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
