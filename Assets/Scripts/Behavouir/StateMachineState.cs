using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "FSM/State")]
public class StateMachineState : IState
{
	public List<Action> Action;
	public List<Transition> Transitions;

	public override void Execute(BaseStateMachine machine)
	{
		foreach (var action in Action)
			action.Execute(machine);

		foreach (var transition in Transitions)
			transition.Execute(machine);
	}
}