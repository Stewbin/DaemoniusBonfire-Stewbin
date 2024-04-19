using UnityEngine;
using UnityEngine.XR;

//this is looping so you give it points it wants to start
//calculates a delta so it contues
//example assume base points is {1,1,0} {1,0,0}
//it will assume your change is {0,-1,0}
// so it will add it to your transform and that becomes the new point it goes towards
[CreateAssetMenu(menuName = "movements/Additive patrol")]
public class AdditivePatrol : PatrollType
{
    public int ApporachingIndex;
    public Vector2[] basePoints;
    public float moveSpeed;
    public Vector2 moveTowards;

    private void Awake()
    {
        moveTowards = new Vector2(0, 0);
    }

    //the point it goes towards is Delta transform calculated by the difference of your pint  base points
    public override void move(GameObject gameObjects)
    {
        if (moveTowards.x == 0)
        {
            moveTowards.x = (int)(gameObjects.transform.position.x + Random.Range(-4, 4));
        }

        gameObjects.transform.position = Vector2.MoveTowards(
            gameObjects.transform.position,
            moveTowards,
            moveSpeed * Time.deltaTime
        );
        Debug.Log("reset");
        moveTowards.y = gameObjects.transform.position.y;
        if (
            Vector2.Distance(gameObjects.transform.position, moveTowards) <= 0.5
            && gameObjects.GetComponent<EyeSensor>().NearSomething()
        )
        {
            Debug.Log("reset");
            moveTowards.x = (int)(gameObjects.transform.position.x + Random.Range(-4, 4));
        }
    }
}
