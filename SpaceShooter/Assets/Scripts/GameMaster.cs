using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public Vector3 boundry;                             // area where ships can move

    [HideInInspector]
    public Transform hierarchyGuard;                    // to keep all created (Clone) in one Transform
    public GameObject playerHolder;


    public Text scoreText;
    public Text lifesText;
    public int score;
    public int lifes;

    [Header("Enemy Spawn Settings")]
    public bool enemySpawn=true;
    public GameObject[] enemies;
    [Tooltip("Place where enemy will be spawn")]
    public Vector3 enemyPosition;
    [Tooltip("Time between spawning enemy")]
    public float EnemyTime = 3;

    private float EnemyTimeLeft;



    void Awake()
    {
        lifes = 3;								// that also
        //StartCoroutine (this.SpawnPlayer (0)); // this will be erased later on

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        //lifesText.text = "Lifes: " + lifes;
        //scoreText.text = "Score: " + score;

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(lifesText);
        DontDestroyOnLoad(scoreText);
     
        hierarchyGuard = new GameObject ("HierarchyGuard").transform;
    }


    void Update()
    {
        if (enemySpawn)
        SpawnEnemies();
    }


    void SpawnEnemies()
    {
        EnemyTimeLeft -= Time.deltaTime;

        if(EnemyTimeLeft < 0)
        {
            EnemyTimeLeft = EnemyTime;

            GameObject randEnemy =enemies[Random.Range(0, enemies.Length)];
            Vector3 randPosition = new Vector3(Random.Range(-enemyPosition.x, enemyPosition.x), enemyPosition.y, enemyPosition.z);
            GameObject newEnemy = Instantiate( randEnemy, randPosition, Quaternion.identity) as GameObject;
            newEnemy.transform.SetParent(hierarchyGuard);                                                                               // Parent Enemy to  hierarchyGuard
        }
    }


    void OnLevelWasLoaded(int level)
    {
        Debug.Log("Level " + level + " loaded");
        if (level == 0)
        {


        }
        else if (level == 1)
        {

            lifes = 3;
            //scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
            //lifesText = GameObject.FindGameObjectWithTag("Life").GetComponent<Text>();
            StartCoroutine(this.SpawnPlayer(0));


        }
        else if (level == 2)
        {

        }
        else if (level == 3)
        {
        }

    }


    public void Spawn()
    {
        StartCoroutine(SpawnPlayer(2));
    }


    public void GameOver()
    {
        //TODO: Animation or Particle
        //lifesText.text = "";
        //scoreText.text = "";
        StartCoroutine(ResetScene());
    }


    public void DescreaseLifes()
    {
        //lifes--;
        //lifesText.text = "Lifes: " + lifes;
    }


    IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(4);
        Application.LoadLevel(2);
    }


    public IEnumerator SpawnPlayer(int seconds)
    {
        Debug.Log("Spawning player");
        yield return new WaitForSeconds(seconds);
        Instantiate(playerHolder, new Vector3(0, 0, -4.0f), Quaternion.identity);
    }


    public void IncreaseScore(int amount)
    {
        this.score += amount;
        scoreText.text = "Score: " + score;
    }
}
