using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoizeExample.Models;

namespace MemoizeExample.Services {
	public class Step {
		private readonly Dictionary<string, object> _cache;

		public Step() {
			_cache = new();
		}

		public async Task<TOut> Run<TOut>( string stepName, Func<Task<TOut>> func ) {
			if ( _cache.TryGetValue( stepName, out object value ) ) {
				return ( TOut ) value;
			}
			// TODO: Phone home to server
			_cache.Add( stepName, await func() );
			throw new ValueMemoizedException();
		}

		public async Task Run( string stepName, Func<Task> func ) {
			if ( _cache.ContainsKey( stepName ) ) {
				return;
			}
			// TODO: Phone home to server
			await func();
			_cache.Add( stepName, null );
			throw new ValueMemoizedException();
		}
	}
}
