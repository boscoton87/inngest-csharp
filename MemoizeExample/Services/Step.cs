using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoizeExample.Models;

namespace MemoizeExample.Services {
	public class Step {
		private readonly Dictionary<string, object> _cache = new();

		public async Task<TOut> Run<TOut>( string stepName, Func<Task<TOut>> func ) {
			if ( _cache.TryGetValue( stepName, out object value ) ) {
				return ( TOut ) value;
			}
			// TODO: Phone home to server
			try {
				_cache.Add( stepName, await func() );
			} catch ( Exception e ) {
				throw new StepCallbackException( e );
			}
			throw new StepControlException();
		}

		public async Task Run( string stepName, Func<Task> func ) {
			if ( _cache.ContainsKey( stepName ) ) {
				return;
			}
			// TODO: Phone home to server
			try {
				await func();
				_cache.Add( stepName, null );
			} catch ( Exception e ) {
				throw new StepCallbackException( e );
			}
			throw new StepControlException();
		}
	}
}
