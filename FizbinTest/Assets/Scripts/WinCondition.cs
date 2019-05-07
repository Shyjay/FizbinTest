using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
	public GameObject winningStuff;
	//if player enters this zone he wins!
    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
			winningStuff.SetActive(true);
        }
    }
}
