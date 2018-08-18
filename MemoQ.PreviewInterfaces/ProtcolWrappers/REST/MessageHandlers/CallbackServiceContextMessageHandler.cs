using MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Callback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.MessageHandlers
{
    internal class CallbackServiceContextMessageHandler : DelegatingHandler
    {
        private readonly ICallbackHandler callbackHandler;

        public CallbackServiceContextMessageHandler(ICallbackHandler callbackHandler)
        {
            this.callbackHandler = callbackHandler;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            using (var context = new CallbackServiceContext(request, callbackHandler))
            {
                return await base.SendAsync(request, cancellationToken);
            }
        }
    }
}
