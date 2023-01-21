using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Patrol : MonoBehaviour
{
    [Header ("Fly Point-to-Point")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [SerializeField] private Transform bird;

    [Header ("Bird Speed")]
    [SerializeField] private float flySpeed;
    private Vector3 initScale;

    private void Awake()
    {
        initScale = bird.localScale;
    }

    private void Update()
    {
        MoveInDirection(1); 
    }
    private void MoveInDirection(int _direction)
    {

        bird.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        bird.position = new Vector3(bird.position.x + Time.deltaTime * _direction * flySpeed,
            bird.position.y, bird.position.z);
    }

   
}
