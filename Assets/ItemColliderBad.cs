using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColliderBad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.HitP1(50);
            Destroy(this.gameObject);
            Debug.Log("Drink Up");
        }
        if (other.CompareTag("Player2"))
        {
            GameManager.Instance.HitP2(50);
            Destroy(this.gameObject);
            Debug.Log("Drink Up");
        }
        if (other.CompareTag("AI"))
        {
            GameManager.Instance.HitP2(50);
            Destroy(this.gameObject);
            Debug.Log("Drink Up");
        }

    }
}
