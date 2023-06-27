using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColliderMPCan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.MPPlusP1(30);
            Destroy(this.gameObject);
            Debug.Log("Drink Up");
        }
        if (other.CompareTag("Player2"))
        {
            GameManager.Instance.MPPlusP2(30);
            Destroy(this.gameObject);
            Debug.Log("Drink Up");
        }
        if (other.CompareTag("AI"))
        {
            GameManager.Instance.MPPlusP2(30);
            Destroy(this.gameObject);
            Debug.Log("Drink Up");
        }

    }
}
