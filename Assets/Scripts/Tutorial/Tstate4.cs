using UnityEngine;
using System.Collections;

public class Tstate4 : TutorialState
{
	public CameraHandler camHandle;

	public override void Run ()
	{
		camHandle.ActivateHangarCam();
		tControl.DisplayMessage("Very good! Now equip the mining laser.", "Captain Stenis", 10.0f);
	}

	public override void sUpdate ()
	{
		if(PlayerShip.instance.weapon!=null) {
			exit = true;
		}
	}
}

