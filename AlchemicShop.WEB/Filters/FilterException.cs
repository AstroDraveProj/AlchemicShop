using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlchemicShop.WEB.Filters
{
    public class FilterException : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {

            if (!exceptionContext.ExceptionHandled &&
                    exceptionContext.Exception is NotImplementedException)
            {
                string val = (string)(((NotImplementedException)exceptionContext.Exception).Message);
                exceptionContext.Result = new ViewResult
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary<string>(val)
                };
                exceptionContext.ExceptionHandled = true;
            } 
            

        }
    }
}