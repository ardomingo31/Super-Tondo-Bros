using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 20;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;

    //[SerializeField] private BoxCollider2D boxCollider;
    //[SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;

    public GameObject deathEffect;
    public PlayerHealthManager player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("DefaultCharacter").GetComponent<PlayerHealthManager>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //if (PlayerInSight())
        if (OnEnemyStance)
        {
            anim.ResetTrigger("enemyStance");
            anim.SetTrigger("enemyStance");

            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                player.KillPlayer();
            }
        }
        else
        {
            anim.ResetTrigger("enemyStance");
        }
        
    }
    bool OnEnemyStance;
    void OnTriggerEnter2D(Collider2D collision)
    {
        OnEnemyStance = collision.tag == "Player";
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        OnEnemyStance = false;
    }

    /* Player in Sight Old
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null; ;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)); 
    }
    */
    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
