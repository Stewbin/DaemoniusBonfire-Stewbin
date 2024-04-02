using UnityEngine;

//this is looping so you give it points it wants to start 
//calculates a delta so it contues
//example assume base points is {1,1,0} {1,0,0}
//it will assume your change is {0,-1,0}
// so it will add it to your transform and that becomes the new point it goes towards
[CreateAssetMenu(menuName = "movements/Additive patrol")]

public class AdditivePatrol : PatrollType
{
    public Transform[] basePoints;
    private Transform DeltaTransform;
    //the point it goes towards is Delta transform calculated by the difference of your pint  base points
    public override void move(GameObject gameObjects) { }

}

