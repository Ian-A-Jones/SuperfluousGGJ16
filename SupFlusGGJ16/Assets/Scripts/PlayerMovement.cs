using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float h = 0;

        if(Input.GetKey(KeyCode.D))
        {
            h = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            h = -1;
        }

        transform.position += Vector3.right * h * 10 * Time.deltaTime;
    }
}
