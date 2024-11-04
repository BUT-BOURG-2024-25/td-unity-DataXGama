using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestructOnCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject destructor;


    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == destructor)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
