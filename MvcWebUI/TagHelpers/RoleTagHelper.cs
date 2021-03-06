using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MvcWebUI.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWebUI.TagHelpers
{
    [HtmlTargetElement("RolGoster")]
    public class RoleTagHelper:TagHelper
    {
       private readonly UserManager<ApplicationUser> _userManager;
        public RoleTagHelper(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public int userId { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
           var user = _userManager.Users.FirstOrDefault(I => I.Id == userId);
           var roles=  await _userManager.GetRolesAsync(user);

            var builder = new StringBuilder();
            foreach(var item in roles)
            {

                builder.Append($"<strong>{item} </strong");

            }
            output.Content.SetHtmlContent(builder.ToString());
        }

    }
}
