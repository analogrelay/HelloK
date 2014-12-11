using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Http {
	public static class HelloKHttpExtensions {
		public static Task WriteLineAsync(this HttpResponse self, string line) 
		{
			return self.WriteAsync(line + Environment.NewLine);
		}
	}
}