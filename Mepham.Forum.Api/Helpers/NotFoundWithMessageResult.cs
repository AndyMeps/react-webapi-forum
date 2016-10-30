using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Net;

namespace Mepham.Forum.Api.Helpers
{
    /// <summary>
    /// Extend IHttpActionResult to allow us to attach a message to a NotFound error code.
    /// </summary>
    public class NotFoundWithMessageResult : IHttpActionResult
    {
        private string message;

        public NotFoundWithMessageResult(string message)
        {
            this.message = message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);
            response.Content = new StringContent(message);

            return Task.FromResult(response);
        }
    }
}