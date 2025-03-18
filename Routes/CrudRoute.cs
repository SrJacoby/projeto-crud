using System;
using Crud.Models;

public static class CrudRoute
{
    public static void CrudRoutes(this WebApplication app)
    {
        app.MapGet("person", () => new CrudModel("Luiz"));
    }
}