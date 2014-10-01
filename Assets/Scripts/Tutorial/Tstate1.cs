using UnityEngine;
using System.Collections;

public class Tstate1 : TutorialState
{

	public Ship ship;

	private float tPlayed;
	private float hInterval = 20.0f;
	private float eTime;
	private bool msgPlayed = false;

	public override void Run ()
	{
		tPlayed = Time.time;
		tControl.DisplayMessage("System recovery; \nRunning diagnostic.. \nCommence main engine test. (Default key: W)", "Rob", 10.0f);
	}

	public override void sUpdate ()
	{

		ship = PlayerShip.instance;

		if(ship==null)
			return;

		if(ship.weapon!=null)
			Destroy(ship.weapon.gameObject,0f);

		if(exit)
			return;

		if(!msgPlayed && ship.rigidbody2D.velocity.magnitude > 10.0f) {
			tControl.DisplayMessage("Success; Main engine test complete.", "Rob", 6.0f);
			msgPlayed = true;
			return;
		}

		if(Time.time > tPlayed + hInterval)
			Run ();
	}

	public override void GuiCallback ()
	{
		exit = msgPlayed;
	}
}

