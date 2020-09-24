using Castle.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEmp
{
    public static class Extention
    {
        public static IConfiguration configuration;

        internal static IActionResult OKResponse(this ControllerBase controller, string msg)
        {
            return controller.Ok(new APIResponse()
            {
                IsOK = true,
                Message = msg
            });
        }
        internal static IActionResult OKFailed(this ControllerBase controller, string msg)
        {
            return controller.Ok(new APIResponse()
            {
                IsOK = false,
                Message = msg
            });
        }
        internal static IActionResult OK<T>(this ControllerBase controller, T content)
        {
            return controller.Ok(new APIContentResponse<T>()
            {
                IsOK = true,
                Content = content
            });
        }
        internal static IActionResult OK<T>(this ControllerBase controller, List<T> content)
        {
            return controller.Ok(new APIContentResponse<T>()
            {
                IsOK = true,
                ContentList = content
            });
        }



        
    }
}
