using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    bool clickButton = false;
    public float speed ;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MiveCamera();
        
    }
    private void MiveCamera()
		{
			 if (Input.GetButtonUp("Fire1"))
			    transform.position+=Vector3.up *speed * Time.deltaTime;
			
		}
}
