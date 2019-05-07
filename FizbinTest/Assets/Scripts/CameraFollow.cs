using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	float actualCamPosY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 interpolatedCamMove = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z),  0.5f);
        transform.position = interpolatedCamMove;
    }
}
