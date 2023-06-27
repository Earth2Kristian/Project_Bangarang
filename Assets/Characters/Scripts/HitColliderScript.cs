using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitColliderScript : MonoBehaviour
{

    [SerializeField] private Transform hit;
    [SerializeField] private Transform attacker;

    // Particle System when the characters are getting hit

    // Player 1's Impact Effect
    [SerializeField] ParticleSystem playerEffect;
    [SerializeField] ParticleSystem lowPlayerEffect;
    [SerializeField] ParticleSystem highPlayerEffect;

    // Plyaer 2's Impact Effect
    [SerializeField] ParticleSystem player2Effect;
    [SerializeField] ParticleSystem lowplayer2Effect;
    [SerializeField] ParticleSystem highplayer2Effect;

    // AI's Impact Effect
    [SerializeField] ParticleSystem aiEffect;
    [SerializeField] ParticleSystem lowAiEffect;
    [SerializeField] ParticleSystem highAiEffect;

    // When characters are getting hit, it cause a back thrust force
    private float knockbackForce = 8;
    private float strongKnockbackForce = 12;
    private float weakKnockbackForce = 5;

    public float knockTime = 1;
    private Rigidbody rb;

    private int attackDamage;

    public AudioSource impactSound;

    void Start()
    {
        attackDamage = Random.Range(3, 7);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AI"))
        {
            Debug.Log("Hit AI");
            rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                if(GameManager.Instance.p2Damage >= 0 && GameManager.Instance.p2Damage < 50)
                {

                    Vector3 differnce = hit.transform.position - attacker.transform.position;
                    differnce = differnce.normalized * weakKnockbackForce;
                    rb.AddForce(differnce, ForceMode.Impulse);
                    impactSound.Play();
                    lowAiEffect.Play();
                    StartCoroutine(KnockCo(rb));
                    GameManager.Instance.HitP2(attackDamage);
                }
                if (GameManager.Instance.p2Damage >= 50 && GameManager.Instance.p2Damage < 100)
                {

                    Vector3 differnce = hit.transform.position - attacker.transform.position;
                    differnce = differnce.normalized * knockbackForce;
                    rb.AddForce(differnce, ForceMode.Impulse);
                    impactSound.Play();
                    aiEffect.Play();
                    StartCoroutine(KnockCo(rb));
                    GameManager.Instance.HitP2(attackDamage);
                }
                if (GameManager.Instance.p2Damage >= 100)
                {
                    Vector3 differnce = hit.transform.position - attacker.transform.position;
                    differnce = differnce.normalized * strongKnockbackForce;
                    rb.AddForce(differnce, ForceMode.Impulse);
                    impactSound.Play();
                    highAiEffect.Play();
                    StartCoroutine(KnockCo(rb));
                    GameManager.Instance.HitP2(attackDamage);
                }



            }
        }
        if (other.CompareTag("Player2"))
        {
            Debug.Log("Hit Player 2");
            rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                if (GameManager.Instance.p2Damage >= 0 && GameManager.Instance.p2Damage < 50)
                {

                    Vector3 differnce = hit.transform.position - attacker.transform.position;
                    differnce = differnce.normalized * weakKnockbackForce;
                    rb.AddForce(differnce, ForceMode.Impulse);
                    impactSound.Play();
                    lowplayer2Effect.Play();
                    StartCoroutine(KnockCo(rb));
                    GameManager.Instance.HitP2(attackDamage);
                }
                if (GameManager.Instance.p2Damage >= 50 && GameManager.Instance.p2Damage < 100)
                {

                    Vector3 differnce = hit.transform.position - attacker.transform.position;
                    differnce = differnce.normalized * knockbackForce;
                    rb.AddForce(differnce, ForceMode.Impulse);
                    impactSound.Play();
                    player2Effect.Play();
                    StartCoroutine(KnockCo(rb));
                    GameManager.Instance.HitP2(attackDamage);
                }
                if (GameManager.Instance.p2Damage >= 100)
                {
                    Vector3 differnce = hit.transform.position - attacker.transform.position;
                    differnce = differnce.normalized * strongKnockbackForce;
                    rb.AddForce(differnce, ForceMode.Impulse);
                    impactSound.Play();
                    highplayer2Effect.Play();
                    StartCoroutine(KnockCo(rb));
                    GameManager.Instance.HitP2(attackDamage);
                }



            }
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit Player 1");
            rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                if (GameManager.Instance.p1Damage >= 0 && GameManager.Instance.p1Damage < 50)
                {
                    Vector3 differnce = hit.transform.position - attacker.transform.position;
                    differnce = differnce.normalized * weakKnockbackForce;
                    rb.AddForce(differnce, ForceMode.Impulse);
                    impactSound.Play();
                    lowPlayerEffect.Play();
                    StartCoroutine(KnockCo(rb));
                    GameManager.Instance.HitP1(attackDamage);

                }
                if (GameManager.Instance.p1Damage >= 50 && GameManager.Instance.p1Damage < 100)
                {
                    Vector3 differnce = hit.transform.position - attacker.transform.position;
                    differnce = differnce.normalized * knockbackForce;
                    rb.AddForce(differnce, ForceMode.Impulse);
                    impactSound.Play();
                    playerEffect.Play();
                    StartCoroutine(KnockCo(rb));
                    GameManager.Instance.HitP1(attackDamage);

                }
                if (GameManager.Instance.p1Damage >= 100)
                {
                    Vector3 differnce = hit.transform.position - attacker.transform.position;
                    differnce = differnce.normalized * strongKnockbackForce;
                    rb.AddForce(differnce, ForceMode.Impulse);
                    impactSound.Play();
                    highPlayerEffect.Play();
                    StartCoroutine(KnockCo(rb));
                    GameManager.Instance.HitP1(attackDamage);
                }

             

            }
        }
    }

    private IEnumerator KnockCo(Rigidbody rb)
    {
        if (rb != null)
        {
            yield return new WaitForSeconds(knockTime);
            rb.velocity = Vector3.zero;
            
        }
    }

 
    
    
}
