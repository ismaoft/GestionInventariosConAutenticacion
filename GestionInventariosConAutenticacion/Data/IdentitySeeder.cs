using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GestionInventariosConAutenticacion.Data
{
    public static class IdentitySeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roleNames = { "Admin", "Empleado" };

            Console.WriteLine("Verificando existencia de roles...");

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    Console.WriteLine($"Creando rol: {roleName}");
                    var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                    if (!result.Succeeded)
                    {
                        Console.WriteLine($"Error al crear rol {roleName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }
                else
                {
                    Console.WriteLine($"Rol {roleName} ya existe.");
                }
            }

            string adminEmail = "ismaoft@gmail.com";
            string adminPassword = "Admin123!"; // Cambia esto si quieres más seguridad

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                Console.WriteLine($"Usuario admin no encontrado. Creando usuario: {adminEmail}");

                var newAdmin = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true // Opcional: evita validación de correo
                };

                var result = await userManager.CreateAsync(newAdmin, adminPassword);

                if (result.Succeeded)
                {
                    Console.WriteLine($"Usuario {adminEmail} creado exitosamente.");
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                    Console.WriteLine($"Usuario {adminEmail} asignado al rol Admin.");
                }
                else
                {
                    Console.WriteLine($"Error al crear usuario admin: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
            else
            {
                Console.WriteLine($"Usuario admin ya existe: {adminEmail}");

                if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    Console.WriteLine($"Rol Admin asignado al usuario existente.");
                }
            }
        }
    }
}
