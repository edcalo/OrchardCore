﻿using System.Collections.Generic;
using Orchard.Security.Permissions;

namespace Orchard.ContentPreview
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ContentPreview = new Permission("ContentPreview", "Display content preview");

        public IEnumerable<Permission> GetPermissions()
        {
            return new[] { ContentPreview };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ContentPreview }
                }
            };
        }
    }
}