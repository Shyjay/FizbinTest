using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCondition : MonoBehaviour
{

	//If player hits death collider level gets reseted
	void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
        	Debug.Log("Death: reload Scene");
            SceneManager.LoadScene(0);
        }
    }
}
