// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyBlog.Areas.Identity.Models.RoleViewModels
{
    public class RoleWithClaimsModel : IdentityRole
    {
        public string[] Claims { get; set; }

    }
}
