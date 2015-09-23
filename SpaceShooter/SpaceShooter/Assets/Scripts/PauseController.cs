using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseController : MonoBehaviour {


	public bool paused;
	public GameObject pausePanel;
	// Use this for initialization
	void Start () {
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			ReversePause();
		}
		Pause (paused);
	}
	public void ReversePause()
	{
		paused = !paused;
	}

	public void Pause(bool pause)
	{
		if (paused) {
			pausePanel.SetActive (true);
			Time.timeScale =0;
		}
		else if (!paused)
		{
			Time.timeScale= 1;
			pausePanel.SetActive (false);
		}
	}
}
