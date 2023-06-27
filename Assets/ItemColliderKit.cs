using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColliderKit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.p1Damage = 0;
            Destroy(this.gameObject);
            Debug.Log("Drink Up");
        }
        if (other.CompareTag("Player2"))
        {
            GameManager.Instance.p2Damage = 0;
            Destroy(this.gameObject);
            Debug.Log("Drink Up");
        }
        if (other.CompareTag("AI"))
        {
            GameManager.Instance.p2Damage = 0;
            Destroy(this.gameObject);
            Debug.Log("Drink Up");
        }

    }
}
