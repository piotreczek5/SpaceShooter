using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	public void changeSceneTo(int noOfScene)
	{
		Application.LoadLevel (noOfScene);
		
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
