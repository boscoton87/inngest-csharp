﻿using System;
using System.Threading.Tasks;
using Inngest.CSharp.Models;

namespace Inngest.CSharp.Services {
	public class StepFunction {
		public required string Id { get; init; }

		public required string Event { get; init; }

		public required Func<Step, Task> Func { private get; init; }

		public async Task Run() {
			var step = new Step();
			while ( true ) {
				try {
					await Func( step );
				} catch ( StepControlException ) {
					continue;
				}
				break;
			}
		}
	}
}
