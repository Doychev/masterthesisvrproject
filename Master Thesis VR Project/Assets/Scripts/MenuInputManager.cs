using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuInputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            SceneManager.LoadScene("level");
        }

        if (Input.GetButtonDown("Jump"))
        {

        }
    }
}
