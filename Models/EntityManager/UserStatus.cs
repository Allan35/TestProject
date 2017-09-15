using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApplication.Models.EntityManager
{
    public enum UserStatus
    {
        AuthenticatedStudent,
        AuthenticatedAdmin,
        AuthenticatedSuperUser,
        NowAuthenticated
    }
}