using UnityEngine;
using System.Collections;


public  class EnemyController : ObjectController
{
    public bool isShooting = true;
    public int pointForKill;                          // points for player


    [Tooltip("How many frames object will change his material to white after taking damage")]
    private float whiteFrames = 3;
    private MeshRenderer[] meshRenderers;                   // all renderer in model will be change to white color after taking damage
    private Material[] orginalMaterials;
    private Material white;


    protected virtual void Start()
    {
        base.Start();

        white = UnityEditor.AssetDatabase.LoadAssetAtPath<Material>("Assets/Materials/white.mat");
        SetMaterialArrays();
    }


    protected virtual void Update()
    {
        if (isShooting) Shot();
    }


    void SetMaterialArrays()
    {
        meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();    // get all mesh renderes in objects

        int size = meshRenderers.Length;
        orginalMaterials = new Material[size];                                 // set array size

        for (int i = 0; i < size; i++)
            orginalMaterials[i] = meshRenderers[i].material;
    }


    IEnumerator SwitchMaterial()
    {
        for (int i = 0; i < meshRenderers.Length; i++)
            meshRenderers[i].material = white;

        for (int i = 0; i < whiteFrames; i++)                                 // wait whiteFrames before change material again
            yield return null;


        for (int i = 0; i < meshRenderers.Length; i++)
            meshRenderers[i].material = orginalMaterials[i];
    }


    protected override void CheckBoundry()           // Enemy Boundry
    {
        rigidbody.position = new Vector3(
        Mathf.Clamp(rigidbody.position.x, -boundryPosition.x, boundryPosition.x),
        rigidbody.transform.position.y,
        rigidbody.transform.position.z);
    }


    public override void TakeDamage(int damage)
    {
        StartCoroutine(SwitchMaterial());

        print(gameObject.name + " pozostalo " + maxHealth + "zycia");
        maxHealth -= damage;
        if (maxHealth <= 0)
        {
            DestroyEffect();
            Destroy(gameObject);
        }
    }


    protected virtual void Shot()
    {
        for (int i = 0; i < visualWeapons.Length; i++)      // Shot from all weapons
            visualWeapons[i].weaponScripts.Shot();
    }
}   // Karol Sobanski


