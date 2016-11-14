using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * Buttons
    Square  = joystick button 0
    X       = joystick button 1
    Circle  = joystick button 2
    Triangle= joystick button 3
    L1      = joystick button 4
    R1      = joystick button 5
    L2      = joystick button 6
    R2      = joystick button 7
    Share   = joystick button 8
    Options = joystick button 9
    L3      = joystick button 10
    R3      = joystick button 11
    PS      = joystick button 12
    PadPress= joystick button 13

Axes:
    LeftStickX      = X-Axis
    LeftStickY      = Y-Axis (Inverted?)
    RightStickX     = 3rd Axis
    RightStickY     = 4th Axis (Inverted?)
    L2              = 5th Axis (-1.0f to 1.0f range, unpressed is -1.0f)
    R2              = 6th Axis (-1.0f to 1.0f range, unpressed is -1.0f)
    DPadX           = 7th Axis
    DPadY           = 8th Axis (Inverted?)
*/

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
            transform.position += transform.forward * Time.deltaTime * 5;
        }

        if (Input.GetButton("MoveBack"))
        {
            transform.position -= transform.forward * Time.deltaTime * 5;
        }


        //CharacterController controller = GetComponent<CharacterController>();
        //Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Forward"));
        ////moveDirection = transform.TransformDirection(moveDirection);
        //debugText.GetComponent<Text>().text = moveDirection.ToString();
        //controller.Move(moveDirection);


    }
}
