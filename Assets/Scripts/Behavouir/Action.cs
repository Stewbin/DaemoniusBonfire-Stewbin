
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public abstract void Execute(BaseStateMachine stateMachine); //execute code here so it can either run/walk/attack

}