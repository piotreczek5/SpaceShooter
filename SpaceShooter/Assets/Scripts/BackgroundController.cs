using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{

    public GameObject[] galaxyObjects;                                // Planets, whirls, small nebulas, supernovas
    public GameObject[] nebulas;                                      // big nebula
    public GameObject[] asteroids;                                    // asteroids rain
    public Vector3 galaxyObjectsSpawn;                                // position where objects will spawn
    public Vector3 nebulaSpawn;                                       // Big nebula and rain asteroids position
    public Vector3 asteroidSpawn;                                     // asteroid rand spawn position
    public float timeBetweenObjects, timeBetweenAsteroids, timeBetweenNebulas;

    private float timeBetweenObjectsLeft, timeBetweenAsteroidsLeft, timeBetweenNebulasLeft;



    void Update()
    {
        if (CheckTimeLeft(ref timeBetweenObjects, ref timeBetweenObjectsLeft))             // galaxy objects
            CreateRandomObject(ref galaxyObjects,  galaxyObjectsSpawn, true);

        if (CheckTimeLeft(ref timeBetweenAsteroids, ref timeBetweenAsteroidsLeft))         // asteroids
            CreateRandomObject(ref asteroids,  asteroidSpawn, false);

        if (CheckTimeLeft(ref timeBetweenNebulas, ref timeBetweenNebulasLeft))             // nebulas
            CreateRandomObject(ref nebulas,  nebulaSpawn, false);
    }


    bool CheckTimeLeft(ref float maxTime, ref float timeLeft)                             
    {
        if (timeLeft > 0)                   // if time didn't elapse
        {
            timeLeft -= Time.deltaTime;
            return false;
        }

        timeLeft = maxTime;                 // if time eplised reset timer
        return true;            
    }


    void CreateRandomObject(ref GameObject[] objects,  Vector3 position, bool isRandPosition)
    {
        int randIndex = Random.Range(0, objects.Length);               // choose random index in array
        GameObject randObject = objects[randIndex];                    // choose GameObject in array

        if (isRandPosition)                                             // if is nessesery to set random position
            position = new Vector3(Random.Range(-position.x, position.x), position.y, position.z);                                  // choose random position on X axis

        GameObject newObject = Instantiate(randObject, position, randObject.transform.rotation) as GameObject;                  // create new GameObject
    }
}  // Karol Sobanski
