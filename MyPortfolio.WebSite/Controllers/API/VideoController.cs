using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace MyPortfolio.WebSite.Controllers.API
{
    public class VideoController : ApiController
    {
		public HttpResponseMessage Get () {
			var video =new  VideoStream ();
			var response = Request.CreateResponse ();
			response.Content = new PushStreamContent((Action<Stream,HttpContent,TransportContext>) video.WritoToStream, new MediaTypeHeaderValue ( "video/mp4" ) );
			return response;
		}
    }
}