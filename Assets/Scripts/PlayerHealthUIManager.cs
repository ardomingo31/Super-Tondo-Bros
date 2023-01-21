using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUIManager : MonoBehaviour
{
    public PlayerHealth currenthealth;
    public GameObject uiHealthPrefab;

    void Start()
    {
        NumberOfPlayerHealth();
    }
    private void OnEnable()
    {
        PlayerHealthManager.OnReducedHealth += NumberOfPlayerHealth;
    }
    private void OnDisable()
    {
        PlayerHealthManager.OnReducedHealth -= NumberOfPlayerHealth;
    }

    void NumberOfPlayerHealth()
    {
        ResetInventory();
        for (int i = 0; i < currenthealth.value; i++)
        {
            GameObject health = Instantiate(uiHealthPrefab);
            health.transform.SetParent(transform, false);
        }
    }

    void ResetInventory()
    {
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
    }
}
