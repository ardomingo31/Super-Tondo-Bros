using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public static event HandledItemCollected OnReducedHealth;
    public delegate void HandledItemCollected();

    public PlayerHealth maxHealth;
    public PlayerHealth currentHealth;

    public Animator anim;

    public GameObject startingPoint;
    void Start()
    {
        currentHealth.value = maxHealth.value;
    }

    public void KillPlayer()
    {
        if (currentHealth.value > 0)
        {
            Debug.Log($"Player Health: {currentHealth.value}");
            currentHealth.value--;
            OnReducedHealth?.Invoke();
            
            StartCoroutine(ResetPlayer());
        }
        else
        {
            Debug.Log($"Player Health: {currentHealth.value}");
            Debug.Log("Game Over");
        }
    }
    IEnumerator ResetPlayer()
    {
        PlayerMovement.enableMovement = false;
        yield return new WaitForSeconds(1);
        transform.position = startingPoint.transform.position;
        PlayerMovement.enableMovement = true;
    }
}
