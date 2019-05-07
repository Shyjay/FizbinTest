using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCondition : MonoBehaviour
{

   void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
        	Debug.Log("Death: reload Scene");
            SceneManager.LoadScene(0);
        }
    }
}
