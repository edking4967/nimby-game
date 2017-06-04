//////////////////////////////////////////////////////////////////////////////
// InputManager.cs
//////////////////////////////////////////////////////////////////////////////
// This object polls Unity for input and posts relevant GameEvents.
//////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using GameEvents;

public class InputManager : MonoBehaviour
{
    Touch t;
    ///////////////////////////////////////////////////////////////////////////
    // CLASS DATA
    ///////////////////////////////////////////////////////////////////////////

    //Keycodes for controls
    public static KeyCode left = KeyCode.LeftArrow;
    public static KeyCode right = KeyCode.RightArrow;
    private KeyCode up = KeyCode.UpArrow;
    private KeyCode jump = KeyCode.Space;
    private KeyCode fire = KeyCode.F;
    private KeyCode charge = KeyCode.G;
    private KeyCode esc = KeyCode.Escape;

    public static bool wantToRun = false; // whether the player is inputting the command to run

    ///////////////////////////////////////////////////////////////////////////
    // FIXED UPDATE
    ///////////////////////////////////////////////////////////////////////////

    // Update is called once per frame
    void Update () 
    {

        if(Input.touchCount > 0)
        {
            t = Input.GetTouch(0);

            Debug.Log("POSITION = " + t.position.x);
            Debug.Log("SCREENWIDTH = " + Screen.width);
            if(t.position.x > Screen.width / 2)
            {
                moveRight();
            }
            else
            {
                moveLeft();
            }
        }

        if(Input.GetKeyUp(left) || Input.GetKeyUp(right))
            wantToRun = false;

        if(Input.GetKey(left) || Input.touchCount > 0 )
            moveLeft();

        if(Input.GetKey(right))
            moveRight();

        if(Input.GetKeyDown(up))
            GameEventManager.post(new PlayerUpEvent());

        if (Input.GetKeyDown (jump))
            GameEventManager.post (new PlayerJumpEvent ());

        if (Input.GetKeyDown (fire)) {
            GameEventManager.post (new PlayerFireEvent ());
        }

        if (Input.GetKeyDown (charge)) {
            GameEventManager.post (new PlayerStartCharge ());
        }

        if (Input.GetKeyUp (charge)) {
            GameEventManager.post (new PlayerStopCharge ());
        }

        if (Input.GetKeyUp (esc)) {
            GameEventManager.post (new BackToMenuEvent ());
        }
    }
    public void moveRight()
    {
        GameEventManager.post(new PlayerMoveEvent(Vector3.right));
        wantToRun = true;
    }

    public void moveLeft()
    {
        GameEventManager.post(new PlayerMoveEvent(Vector3.left));
        wantToRun = true;
    }
}
