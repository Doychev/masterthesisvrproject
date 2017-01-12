using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject attackerPrefab;
    public Vector3 minCoordinates, maxCoordinates;

    public float spawnDelay;
    public bool spawning = true;

	// Use this for initialization
	void Start () {
        spawning = true;
        instantiateEnemy();
        StartCoroutine(instantiateMultipleEnemies());
    }

    // Update is called once per frame
    void Update () {
	
	}

    IEnumerator instantiateMultipleEnemies()
    {
        while (spawning)
        {
            Debug.Log("waiting...");
            yield return new WaitForSeconds(spawnDelay);
            instantiateEnemy();
        }
    }

    void instantiateEnemy()
    {
        Debug.Log("spawning!");
        Vector3 position = new Vector3(
            Random.Range(minCoordinates.x, maxCoordinates.x),
            Random.Range(minCoordinates.y, maxCoordinates.y),
            Random.Range(minCoordinates.z, maxCoordinates.z));
        Instantiate(attackerPrefab, position, Quaternion.identity);
    }
}