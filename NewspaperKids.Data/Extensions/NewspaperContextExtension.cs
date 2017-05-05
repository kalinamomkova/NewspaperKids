namespace NewspaperKids.Data.Extensions
{
    using System;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using NewspaperKids.Models.Roles;

    public static class NewspaperContextExtension
    {
        public static void AddRole(this NewspaperKidsContext context, Role userRole)
        {
            var roleName = Enum.GetName(typeof(Role), userRole);
            if (!context.Roles.Any(role => role.Name == roleName))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole(roleName);
                manager.Create(role);
            }
        }
    }
}