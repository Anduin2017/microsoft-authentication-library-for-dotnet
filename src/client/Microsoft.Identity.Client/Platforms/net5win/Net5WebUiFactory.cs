﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client.Internal;
using Microsoft.Identity.Client.Platforms.Features.WebView2WebUi;
using Microsoft.Identity.Client.Platforms.net45;
using Microsoft.Identity.Client.Platforms.Shared.Desktop.OsBrowser;
using Microsoft.Identity.Client.UI;

namespace Microsoft.Identity.Client.Platforms.net5win
{
    internal class Net5WebUiFactory : IWebUIFactory
    {
        public IWebUI CreateAuthenticationDialog(CoreUIParent parent, RequestContext requestContext)
        {
            // no support for hidden ui browser 

            if (!parent.UseEmbeddedWebview)
            {
                return new DefaultOsBrowserWebUi(
                    requestContext.ServiceBundle.PlatformProxy,
                    requestContext.Logger,
                    parent.SystemWebViewOptions);
            }

            // TODO: factory logic
            var legacy =  new 
                InteractiveWebUI(parent, requestContext);
            var wv2 = new WebView2WebUi(parent, requestContext);

            IWebUI used = wv2;

            return used;
        }
    }
}
