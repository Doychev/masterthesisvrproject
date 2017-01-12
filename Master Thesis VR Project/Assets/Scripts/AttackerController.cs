using UnityEngine;
using System.Collections;

public class AttackerController : MonoBehaviour {

    public float speed;

    private GameObject targetsList;
    private Transform target;

	// Use this for initialization
	void Start () {
        targetsList = GameObject.Find("Targets");
        Transform[] targetsArray = targetsList.GetComponentsInChildren<Transform>();
        int targetIndex = Random.Range(0, targetsArray.Length);
        target = targetsArray[targetIndex];

        transform.LookAt(target);
        GetComponent<Rigidbody>().AddRelativeForce(0, 0, speed * 10);
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Block"))
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag.Equals("Player"))
        {
            //TODO game over
        }

        Destroy(gameObject);
    }
}
