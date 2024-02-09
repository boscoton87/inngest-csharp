using System;
using System.Threading.Tasks;
using MemoizeExample.Models;

namespace MemoizeExample.Services {
	public class Function {
		public required string Id { get; init; }

		public required string Event { get; init; }

		public required Func<Step, Task> Func { private get; init; }

		public async Task RunFunction() {
			var step = new Step();
			while ( true ) {
				try {
					await Func( step );
				} catch ( ValueMemoizedException ) {
					continue;
				}
				break;
			}
		}
	}
}
