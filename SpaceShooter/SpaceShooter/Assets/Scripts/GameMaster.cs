using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;


    [HideInInspector]                   // another script need to access to this field but not in Inspector
    public Transform player,            // Player position is necessary to parent shoot effects to ship
                     hierarchyGuard;    // to keep all created (Clone) in one Transform
	public GameObject playerHolder;

	public Text scoreText;
	public Text lifesText;
	public int score;
	public int lifes;

    void Awake()
    {
		lifes = 3;								// that also
		StartCoroutine (this.SpawnPlayer (0)); // this will be erased later on
        
		if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
		lifesText.text = "Lifes: " + lifes;
		scoreText.text = "Score: " + score;
        
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(lifesText);
		DontDestroyOnLoad(scoreText);
		//player = GameObject.FindGameObjectWithTag ("Player").transform;                // Find GameObject is necessery because player doesn't exist yet.
		//hierarchyGuard = new GameObject ("HierarchyGuard").transform;
           }


	void OnLevelWasLoaded(int level) {
		Debug.Log ("Level "+level+" loaded");
		if (level == 0) {


		} else if (level == 1) {

			lifes = 3;
			scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
			lifesText = GameObject.FindGameObjectWithTag("Life").GetComponent<Text>();
			StartCoroutine (this.SpawnPlayer (0));


		} else if (level == 2) {

		} else if (level == 3) {
		}
		
	}
	void Start()
	{

		lifesText.text = "Lifes: " + lifes;
		scoreText.text = "Score: " + score;
	}
	public void Spawn()
	{
		StartCoroutine (SpawnPlayer (2));
	}

	public void GameOver()
	{
		//TODO: Animation or Particle
		lifesText.text = "";
		scoreText.text = "";
		StartCoroutine(ResetScene());
	}
	public void DescreaseLifes()
	{
		lifes--;
		lifesText.text = "Lifes: " + lifes;
	}
	
	IEnumerator ResetScene()
	{
		yield return new WaitForSeconds(4);
		Application.LoadLevel(2);
	}

	public IEnumerator SpawnPlayer(int seconds)
	{
		Debug.Log ("Spawning player");
		yield return new WaitForSeconds(seconds);
		Instantiate (playerHolder, new Vector3 (0, 0, -4.0f), Quaternion.identity);

	}


	public void IncreaseScore(int amount)
	{

		this.score += amount;
		scoreText.text = "Score: "+  score;
	}
}   // Karol Sobanski
