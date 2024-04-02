using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Transition")]
public class Transition : ScriptableObject
{
    public Decision Decision;
    [SerializeField] public IState TrueState;
    [SerializeField] public IState FalseState;

    public void Execute(BaseStateMachine stateMachine)
    {
        if (Decision.Decide(stateMachine) && !(TrueState is RemainInState))
            stateMachine.CurrentState = TrueState;
        else if (!(FalseState is RemainInState))
            stateMachine.CurrentState = FalseState;
    }
}