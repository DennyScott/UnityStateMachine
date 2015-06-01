using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine {
	public partial class StateMachine<TState, TTrigger> {
		internal class StateReference {
			public TState State { get; set; }
		}
	}
}
