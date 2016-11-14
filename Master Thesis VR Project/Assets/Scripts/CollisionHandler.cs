using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    public void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag.Equals("Block"))
        {
            Destroy(col.gameObject);
        }
        Destroy(gameObject);
    }
}