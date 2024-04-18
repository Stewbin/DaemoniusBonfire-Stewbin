using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/If enemy is near Decision")]
public class PlayerNearTransition : Decision
{
    // Start is called before the first frame update
    public override bool Decide(BaseStateMachine state)
    {
        return state.GetComponent<EyeSensor>().NearTarget();
    }
}
