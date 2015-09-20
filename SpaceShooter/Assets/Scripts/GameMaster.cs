using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    [HideInInspector]                   // another script need to access to this field but not in Inspector
    public Transform player,            // Player position is necessary to parent shoot effects to ship
                     hierarchyGuard;    // to keep all created (Clone) in one Transform


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        player = GameObject.FindGameObjectWithTag("Player").transform;                // Find GameObject is necessery because player doesn't exist yet.
        hierarchyGuard = new GameObject("HierarchyGuard").transform;

    }
}   // Karol Sobanski
