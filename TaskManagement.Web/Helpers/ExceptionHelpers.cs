using Microsoft.OData.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace TaskManagement.Web.Helpers
{
    public static class ExceptionHelpers
    {
        public static HttpResponseException ResourceNotFoundError(HttpRequestMessage request)
        {
            HttpResponseException httpException;
            HttpResponseMessage response;
            ODataError error;

            error = new ODataError { Message = "Resource Not Found - 404", ErrorCode = "NotFound" };

            response = request.CreateResponse(System.Net.HttpStatusCode.NotFound, error);

            httpException = new HttpResponseException(response);

            return httpException;
        }
    }
}