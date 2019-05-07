using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCondition : MonoBehaviour
{

   void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
        	Debug.Log("Death: reload Scene");
            SceneManager.LoadScene(0);
        }
    }
}
