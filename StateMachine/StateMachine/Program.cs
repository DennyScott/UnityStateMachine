using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine {
	class Program {

		public enum States {
			Idle,
			Walking,
			Running
		};

		public enum Triggers {
			Stop,
			MoveFaster
		}

		static void Main(string[] args) {
			Debug.WriteLine("hello");
			var sm = new StateMachine<States, Triggers>(States.Idle);

			sm.Configure(States.Idle)
				.Permit(Triggers.MoveFaster, States.Walking)
				.OnEntry(NiceAndEasy)
				.OnExit(TakeABreath);

			sm.Configure(States.Walking)
				.Permit(Triggers.MoveFaster, States.Running)
				.Permit(Triggers.Stop, States.Idle)
				.OnEntry(StepForward)
				.OnExit(TakeABreath);

			sm.Configure(States.Running)
				.Permit(Triggers.Stop, States.Idle)
				.OnEntry(StepForward)
				.OnExit(QuickStop);

			sm.Fire(Triggers.MoveFaster);
			sm.Fire(Triggers.MoveFaster);
			sm.Fire(Triggers.Stop);
		}

		static void TakeABreath() {
			Debug.WriteLine("Take a Breath");
		}

		static void StepForward() {
			Debug.WriteLine("Gotta take another step!");
		}

		static void NiceAndEasy() {
			Debug.WriteLine("Nice and Easy!");
		}

		static void QuickStop() {
			Debug.WriteLine("For the Love of God Stop!");
		}
	}
}
