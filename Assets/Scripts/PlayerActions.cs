using UnityEngine;
using System.Collections;
using GameEvents;


public class PlayerActions : MonoBehaviour, GameEventListener {

    PlayerController mc;	
	// Use this for initialization
	void Start () {
		GameEventManager.registerListener(this);	
        mc = GetComponent<PlayerController>();
	}
	
	///////////////////////////////////////////////////////////////////////////
	// EVENT LISTENING
	///////////////////////////////////////////////////////////////////////////
	
	public void eventReceived(GameEvent e)
	{
		if (e is PlayerFireEvent) {
			mc.fireProjectile();
		}
		if (e is PlayerStartCharge) {
			mc.chargeAura(true);
		}
		if (e is PlayerStopCharge) {
			mc.chargeAura(false);
		}

		if (e is PlayerUpEvent) {
            if(mc.gs.onVine)
                mc.climbVine();
            //else
                //mc.checkDoor();
		}

	}
}
