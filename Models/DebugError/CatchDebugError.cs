using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApplication.Models.DebugError
{
    public class CatchDebugError
    {

    }
    public class DebugErrorMessage
    {
        public static void CatchError(Exception ex)
        {
            HttpContext.Current.Response.Write(ex.InnerException.ToString());
        }

    }
}