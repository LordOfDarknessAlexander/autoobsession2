using UnityEngine;
using System.Collections;

public class SeekAttackPlayer : State 
{
    public ShipData mShipData;
    public ShipController mShipController;
    public float mAttackRange;
    public GameObject mTarget;
    public float mSpeed;

    public bool mSlowDownOnArrival = false;
    public float mSlowDownRadius = 5.0f;

    public override void OnStateEntered()
    {
        if (mTarget == null)
        {
            mTarget = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public override void OnStateExit()
    {
    }

    //should be using delta time since not in fixed update.
    public override void StateUpdate()
    {
        /*Vector2 toPlayer = mTarget.transform.position - transform.position;
        Vector2 desiredVelocity = toPlayer.normalized;
        mSpeed = mShipData.GetTotalThrustAccel();


        if (toPlayer.magnitude < mSlowDownRadius)
        {
            desiredVelocity *= mSpeed * (toPlayer.magnitude / mSlowDownRadius) ;
        }
        else
        {
            desiredVelocity *= mSpeed;
        }

        if(toPlayer.magnitude < mAttackRange)
        {
            mShipController.FireWeapons("Enemy Projectile");
        }

        Vector3 steering = desiredVelocity - rigidbody2D.velocity;

        rigidbody2D.AddForce(steering);

        float angle = Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, (angle * 180.0f / Mathf.PI));*/

        //to move player around scene
        rigidbody2D.AddForce(-transform.up * mSpeed);
    }

    public override void StateGUI()
    {

    }
}
