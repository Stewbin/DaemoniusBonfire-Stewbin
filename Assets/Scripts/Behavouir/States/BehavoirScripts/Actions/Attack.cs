using System;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/attack")]

public class Attack : Action
{
	public override void Execute(BaseStateMachine stateMachine)
	{
		Debug.Log("attacking");
		stateMachine.GetComponent<SpriteRenderer>().color = Color.red;

	}
    public override string ToString()
    {
        return "attacking state";
    }

}