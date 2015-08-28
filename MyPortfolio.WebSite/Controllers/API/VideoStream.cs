using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace MyPortfolio.WebSite.Controllers.API {
	public class VideoStream {
		private string fileName;
		public VideoStream () {
			fileName = @"C:\Users\alexe_000\Desktop\video\Можете ли вы ходить по воде.mp4";
		}
		public async void WritoToStream ( Stream stream , HttpContent httpContent , TransportContext context ) {
			try {
				var buffer = new byte[65536];
				using ( var video = File.Open ( fileName , FileMode.Open , FileAccess.Read ) ) {
					int length = (int) video.Length;
					int bytesRead = 1;
					while ( length > 0 && bytesRead > 0 ) {
						bytesRead = video.Read ( buffer , 0 , Math.Min ( length , buffer.Length ) );
						await stream.WriteAsync ( buffer , 0 , bytesRead );
						length -= bytesRead;
					}
				}
			}
			catch ( HttpException ex ) {
				return;
			}
			finally {
				stream.Close ();
			}
		}
	}
}