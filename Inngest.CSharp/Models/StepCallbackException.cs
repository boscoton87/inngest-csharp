using System;

namespace Inngest.CSharp.Models {
	public class StepCallbackException( Exception inner )
		: Exception( "An error occured calling the step callback, see inner exception.", inner ) { }
}
