﻿//////////////////////////////////////////////////////////////////////////////
// PlayerMoveEvent
//////////////////////////////////////////////////////////////////////////////
// This event is dispatched when a movement key is pressed.
//////////////////////////////////////////////////////////////////////////////

//default namespaces
using UnityEngine;
using System.Collections;

//Add access to game events classes
using GameEvents;

//PlayerMoveEvent is a GameEvent
public class PlayerStopEvent : GameEvent
{

   ///////////////////////////////////////////////////////////////////////////
   // EVENT DATA
   ///////////////////////////////////////////////////////////////////////////
   
   public Vector3 direction;
   
   ///////////////////////////////////////////////////////////////////////////
   // CONSTRUCTOR
   ///////////////////////////////////////////////////////////////////////////
   
   public PlayerStopEvent(Vector3 d)
   {
      direction = d;
   }

}
