using UnityEngine;

public class InputManager : MonoBehaviour {

    public Transform projectile;
    public float bulletSpeed;

    public GameObject debugText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire"))
        {
            GameObject camera = GameObject.Find("Main Camera");
            Transform clone = (Transform) Instantiate(projectile, camera.transform.position + camera.transform.forward, transform.rotation);
            clone.GetComponent<Rigidbody>().AddForce(camera.transform.forward * bulletSpeed);
        }

        if (Input.GetButtonDown("Jump"))
        {
            float distToGround = GetComponent<Collider>().bounds.extents.y;
            if (Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f))
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            }
        }

        if (Input.GetButton("Move"))
        {
            GameObject cameraObject = GameObject.Find("Main Camera");
            transform.position += cameraObject.transform.forward * Time.deltaTime * 5;
        }

        if (Input.GetButton("MoveBack"))
        {
            GameObject cameraObject = GameObject.Find("Main Camera");
            transform.position -= cameraObject.transform.forward * Time.deltaTime * 5;
        }

        if (Input.GetButton("MoveLeft"))
        {
            GameObject cameraObject = GameObject.Find("Main Camera");
            transform.position -= cameraObject.transform.right * Time.deltaTime * 5;
        }

        if (Input.GetButton("MoveRight"))
        {
            GameObject cameraObject = GameObject.Find("Main Camera");
            transform.position += cameraObject.transform.right * Time.deltaTime * 5;
        }

        if (Input.GetButton("Reset"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}


// 0 - square
// 1 - x
// 4 - l2
// 5 - r2
// 7 - options

//2 - circle?
//3 - triangle?
//6 - share?
//8 - l1?
//9 - r1?