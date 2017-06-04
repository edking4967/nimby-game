//////////////////////////////////////////////////////////////////////////////
// PlayerMovement.cs
//////////////////////////////////////////////////////////////////////////////
// This script listens for PlayerMoveEvents and moves the attached object
// accordingly.
//////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using GameEvents;
//using Application;

public class PlayerMovement : MonoBehaviour, GameEventListener 
{

    ///////////////////////////////////////////////////////////////////////////
    // CONSTANTS
    ///////////////////////////////////////////////////////////////////////////

    const float moveAmount = 0.05f;
    GravitySprite gs;

    ///////////////////////////////////////////////////////////////////////////
    // START FUNCTION
    ///////////////////////////////////////////////////////////////////////////

    // Use this for initialization
    void Start () 
    {
        GameEventManager.registerListener(this);	
        gs = GetComponent<GravitySprite>();
    }

    ///////////////////////////////////////////////////////////////////////////
    // EVENT LISTENING
    ///////////////////////////////////////////////////////////////////////////

    public void eventReceived(GameEvent e)
    {
        if (e is PlayerMoveEvent)
        {
            Vector3 d = (e as PlayerMoveEvent).direction;

            gs.run(d);

            handlePlayerFlip(d);
        }

        if (e is PlayerJumpEvent) {
            gs.jump();
        }
    }

    private void handlePlayerFlip(Vector3 d)
    {
        bool isFacingRight = gs.isFacingRight;

        if(isFacingRight && d == Vector3.left)
        {
            Debug.Log("change direction");
            gs.isFacingRight=false;

            GameEventManager.post(new PlayerFlipEvent());
        }
        if(!isFacingRight && d == Vector3.right)
        {
            Debug.Log("change direction");
            gs.isFacingRight=true;

            GameEventManager.post(new PlayerFlipEvent());
        }

    }

}
