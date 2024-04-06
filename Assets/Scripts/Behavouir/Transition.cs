using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Transition")]
public class Transition : ScriptableObject
{
	public Decision Decision;
	public IState TrueState;
	public IState FalseState;
	public void Execute(BaseStateMachine stateMachine)
	{
		if (Decision.Decide(stateMachine) && !(TrueState is RemainInState))
		{
			stateMachine.CurrentState = TrueState;
			Debug.Log("can trans");
		}
		else if (!(FalseState is RemainInState))
		{
			stateMachine.CurrentState = FalseState;

		}
	}
}