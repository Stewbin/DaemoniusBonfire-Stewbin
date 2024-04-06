using UnityEngine;

/// <summary>
/// how this works
/// Every state has a transition, and action 
/// if a state has no transition just use the Default Remain in state 
/// 
/// how it works
/// attach this to the game object you want to  bring to life >:3
/// 
/// 1.  decide what state you want the base state to be
/// (i recomend patrol)
/// if you dont have one of the states to attach to create a new state in the "assets/Create/FSM" tab
/// if yes -> step 2
/// if no -> step 5
///
/// 2.  assuming you didnt have the state create a Transition, Action and Decision (do that by creating 2 new C# scripts
/// that extend off of  Action.cs and Decision.cs (pls look at these files for documentation on how these work)
/// for the sake of ogranization pls i beg of you add this to the top of each file
/// [CreateAssetMenu(menuName = "FSM/{ACTIONS or DECISION}/{$DECISION}")]
/// 
/// 3. once you do that create .Asset for each of the classes you created 
/// 4. fill it in the action and transition List 
/// 5. create a new transition.Asset file
/// 6. fill in the TrueState (tha being the state you would like to transition to if true) FalseState (that being either "RemainState" or a new state)
/// and Decison. which is the .Asset file of the script you created that extends off of Decison.cs
/// 7. you should be good. to add more functionality repeat but dont put your new state as the initialState in this file
/// instead put it as a Transition
/// the way you end is by doing a basic RemianState RemianState for both
/// </summary>


public class BaseStateMachine : MonoBehaviour
{
	[SerializeField] private IState _initialState;
	private void Awake()
	{
		CurrentState = _initialState;
	}
	public IState CurrentState { get; set; }

	private void Update()
	{
		CurrentState.Execute(this);
		Debug.Log(CurrentState.ToString());
	}

}