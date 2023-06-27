using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.HealP1(30);
            Destroy(this.gameObject);
            Debug.Log("Drink Up");
        }
        if (other.CompareTag("Player2"))
        {
            GameManager.Instance.HealP2(30);
            Destroy(this.gameObject);
            Debug.Log("Drink Up");
        }
        if (other.CompareTag("AI"))
        {
            GameManager.Instance.HealP2(30);
            Destroy(this.gameObject);
            Debug.Log("Drink Up");
        }    

    }
}
