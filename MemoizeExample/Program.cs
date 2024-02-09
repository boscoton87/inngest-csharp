using System;
using System.Threading.Tasks;
using MemoizeExample.Services;

namespace MemoizeExample {
	internal class Program {
		static async Task Main( string[] args ) {
			var function = new Function {
				Id = "my-func",
				Event = "foo",
				Func = async step => {
					var name = await step.Run( "get-name", async () => "Alex" );
					await step.Run( "print-name", async () => Console.WriteLine($"Hello, {name}") );
				}
			};
			await function.RunFunction();
		}
	}
}
