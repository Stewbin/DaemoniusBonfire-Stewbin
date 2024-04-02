using UnityEngine;

public class IState : ScriptableObject
{
    public virtual void Execute(BaseStateMachine machine) { } //base object of this BaaeSTate is your mono behavour


}