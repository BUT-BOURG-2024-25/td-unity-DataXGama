using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public static MobSpawner Instance { get; private set; }

    [SerializeField]
    private GameObject SpawnPart;

    [SerializeField]
    private GameObject ObjectToSpawn;

    [SerializeField]
    private double SpawnDelay = 1;

    [SerializeField]
    private int MaxMobs = 10;

    private double lastSpawn = 0;
    private List<GameObject> mobs = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        double delta = Time.time - lastSpawn;

        if (delta > SpawnDelay && mobs.Count < MaxMobs)
        {
            lastSpawn = Time.time;
            SpawnMobRandomly();
        }
    }

    public void SpawnMobRandomly()
    {
        GameObject newObject = GameObject.Instantiate(ObjectToSpawn);
        Transform spawnTransform = SpawnPart.transform;
        Vector3 scale = spawnTransform.localScale;

        newObject.transform.parent = spawnTransform;
        newObject.transform.localPosition = new Vector3(
                Random.value * scale.x - scale.x / 2,
                newObject.transform.localScale.y / 2,
                Random.value * scale.z - scale.z / 2);

        mobs.Add( newObject );
    }

    public void DestroyAllAround(Vector3 position, float radius)
    {
        for (int i = 0; i < mobs.Count; ++i) {
            GameObject item = mobs[i];

            if ((item.transform.position - position).magnitude <= radius)
            {
                mobs.Remove(item);
                Destroy(item);
                --i;
            }
        }
    }
}
