using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform player2;
    [SerializeField] private Transform ai;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform respawnPoint2;

    public AudioSource outSound;

    public Rigidbody rb_Player;
    public  Rigidbody rb_Player2;
    public Rigidbody rb_AI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // When Player 1 is out of the stage zone
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
            outSound.Play();

           // Player 1's Damage % will be reset
            GameManager.Instance.p1Damage = 0;
            GameplayScript.Instance.p1Damagetxt.text = 0 + "%";

            // Player 1's MP will be reset
            GameManager.Instance.p1MP = 100;
            GameplayScript.Instance.p1MPtxt.text = "MP: " + 100;

            // Player 1 will lose one stock (aka lives)
            GameManager.Instance.LoseLivesP1(1);

            // This is to prevent player 1 to keep moving once it loses a live
            rb_Player.velocity = Vector3.zero;

        }

        if (other.CompareTag("Player2"))
        {
            // When Player 2 is out of the stage zone
            player2.transform.position = respawnPoint2.transform.position;
            Physics.SyncTransforms();
            outSound.Play();

            // Player 2's Damage % will be reset
            GameManager.Instance.p2Damage = 0;
            GameplayScript.Instance.p2Damagetxt.text = 0 + "%";

            // Player 2's MP will be reset
            GameManager.Instance.p2MP = 100;
            GameplayScript.Instance.p2MPtxt.text = "MP: " + 100;

            // Player 2 will lose one stock (aka lives)
            GameManager.Instance.LoseLivesP2(1);

            // This is to prevent player 2 to keep moving once it loses a live
            rb_Player2.velocity = Vector3.zero;

        }
        if (other.CompareTag("AI"))
        {
            // When AI is out of the stage zone
            ai.transform.position = respawnPoint2.transform.position;
            Physics.SyncTransforms();
            outSound.Play();

            // AI's Damage % will be reset
            GameManager.Instance.p2Damage = 0;
            GameplayScript.Instance.p2Damagetxt.text = 0 + "%";

            // AI's MP will be reset
            GameManager.Instance.p2MP = 100;
            GameplayScript.Instance.p2MPtxt.text = "MP: " + 100;

            // AI will lose one stock (aka lives)
            GameManager.Instance.LoseLivesP2(1);

            // This is to prevent the AI to keep moving once it loses a live
            rb_AI.velocity = Vector3.zero;

        }
    }
}
