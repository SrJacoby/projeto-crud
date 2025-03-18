using System;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore;
using Crud.Models;

public static class CrudRoute
{
    public static void CrudRoutes(this WebApplication app)
    {
        var route = app.MapGroup("crud");

        route.MapPost("", async (CrudRequest req, CrudContext context) =>
        {
            var register = new CrudModel(req.name);
            await context.AddAsync(register);
            await context.SaveChangesAsync();
        });

        route.MapGet("", async (CrudContext context) =>
        {
            var register = await context.Register.ToListAsync();
            return Results.Ok(register);
        });

        route.MapPut("{id:guid}", async (Guid id, CrudRequest req, CrudContext context) =>
        {
            var register = await context.Register.FirstOrDefaultAsync(x => x.Id == id);

            if (register == null)
            {
                return Results.NotFound();
            }

            register.ChangeName(req.name);
            await context.SaveChangesAsync();

            return Results.Ok(register);
        });

        route.MapDelete("{id:guid}", async (Guid id, CrudContext context) =>
        {
            var register = await context.Register.FirstOrDefaultAsync(x => x.Id == id);

            if (register == null)
            {
                return Results.NotFound();
            }
            register.SetInactive();
            await context.SaveChangesAsync();

            return Results.Ok(register);
        });
    }
}