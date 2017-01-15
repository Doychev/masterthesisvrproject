using UnityEngine;
using System.Collections;

public class AttackerController : MonoBehaviour {

    public float speed;

    private GameObject[] targetsList;
    private GameObject target;

	// Use this for initialization
	void Start () {
        targetsList = GameObject.FindGameObjectsWithTag("Block");
        int targetIndex = Random.Range(0, targetsList.Length);
        target = targetsList[targetIndex];

        transform.LookAt(target.transform);
        GetComponent<Rigidbody>().AddRelativeForce(0, 0, speed * 10);
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Block"))
        {
            Destroy(col.gameObject);
            targetsList = GameObject.FindGameObjectsWithTag("Block");
            if (targetsList.Length <= 1)
            {
                endGame();
            }
        }
        else if (col.gameObject.tag.Equals("Player"))
        {
            endGame();
        }

        Destroy(gameObject);
    }

    public void endGame()
    {
        GameObject.Find("Player").GetComponent<InputManager>().endGame();
    }
}
