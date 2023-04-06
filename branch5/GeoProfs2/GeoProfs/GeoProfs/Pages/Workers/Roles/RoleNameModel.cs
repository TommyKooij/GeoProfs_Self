using GeoProfs.Data;
using GeoProfs.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GeoProfs.Pages.Workers
{
    public class RoleNameModel : PageModel
    {
        public SelectList RolesNameSL { get; set; }

        public void PopulateRolesDropDownList(GeoProfsContext _context,
            object selectedRole = null)
        {
            var rolesQuery = from d in _context.Roles
                                   orderby d.RoleName // Sort by name.
                                   select d;

            RolesNameSL = new SelectList(rolesQuery.AsNoTracking(),
                nameof(Role.RoleID),
                nameof(Role.RoleName),
                selectedRole);
        }
    }
}