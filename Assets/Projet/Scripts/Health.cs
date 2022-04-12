using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;



public class Health : MonoBehaviour
{
    [SerializeField] private int maxLife = 1;
    [SerializeField] private Inventory inventory = null;

    public bool isDead = false;

    public GameObject GameOverPanel;

    private int currentLife;

    public Animator animator;
  
    public event Action<int> OnDamageTaken;

    public event Action OnDeath;
    public Collider colliderCollision;

    private void Update()
    {
    }

    public void Hit(int damage)
    {
        if (currentLife <= 0)
            return;

        currentLife -= damage;
        OnDamageTaken?.Invoke(damage);

        if (currentLife <= 0)
        {
            OnDeath?.Invoke();
            isDead = true;

            if(gameObject.tag == "Player")
            {
                StartCoroutine(GameOver());
            }
            else if (gameObject.tag == "IA")
            {
                StartCoroutine(GameOverIA());
            }
        }
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        colliderCollision.enabled = false;
        yield return new WaitForSeconds(1f);
        GameOverPanel.SetActive(true);
        animator.SetTrigger("GameOver");

    }
    public IEnumerator GameOverIA()
    {
        yield return new WaitForSeconds(2f);
        GetComponentInParent<NavMeshAgent>().enabled = false;
        colliderCollision.enabled = false;
        inventory.AddCoins(5);
        


    }

    private void Awake()
    {
        currentLife = maxLife;
    }
}
