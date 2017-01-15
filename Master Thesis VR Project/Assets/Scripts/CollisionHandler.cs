using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    public void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag.Equals("Enemy")) // || col.gameObject.tag.Equals("Block")
        {
            GameObject.Find("Player").GetComponent<InputManager>().updatePoints();
            Destroy(col.gameObject);
        }
        Destroy(gameObject);
    }
}