using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public Animator anim;
    public int loadSceneNumber;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement.enableMovement = false;
            StartCoroutine(LoadNextlevel());
            anim.SetTrigger("Victory");
        }
    }

    IEnumerator LoadNextlevel()
    {
        yield return new WaitForSeconds(2);
        PlayerMovement.enableMovement = true;
        SceneManager.LoadScene(loadSceneNumber);
    }
}
