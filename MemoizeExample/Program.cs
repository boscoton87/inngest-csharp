using System;
using System.Threading.Tasks;
using MemoizeExample.Models;
using MemoizeExample.Services;

namespace MemoizeExample {
	internal class Program {
		static async Task Main( string[] args ) {
			await SimpleExample();
			await CaughtExceptionExample();
		}

		private static async Task SimpleExample() {
			var function = new StepFunction {
				Id = "my-func",
				Event = "foo",
				Func = async step => {
					var name = await step.Run(
						"get-name",
						async () => "Alex" );
					await step.Run(
						"print-name",
						async () => Console.WriteLine( $"Hello, {name}" ) );
				}
			};
			await function.Run();
		}

		private static async Task CaughtExceptionExample() {
			var function = new StepFunction {
				Id = "my-func",
				Event = "foo",
				Func = async step => {
					try {
						await step.Run(
							"a",
							() => {
								Console.WriteLine( "inside a" );
								throw new Exception( "oh no" );
							} );
					} catch (StepCallbackException e ) {
						Console.WriteLine( $"Caught error: {e.InnerException.Message}" );
					}

					await step.Run(
						"b",
						async () => Console.WriteLine( "inside b" ) );
				}
			};
			await function.Run();
		}
	}
}
