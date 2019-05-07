using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	float actualCamPosY;

	//Camera lerp follows player from original cam position
    void FixedUpdate()
    {
        Vector3 interpolatedCamMove = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z),  0.5f);
        transform.position = interpolatedCamMove;
    }
}
