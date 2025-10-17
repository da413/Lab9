using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    float horizontal;
    Animator animator; 
    
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3((horizontal*playerSpeed*Time.deltaTime), 0, 0));
        if(horizontal != 0){
            animator.SetBool("IsWalking", true);
        }
        else{
            animator.SetBool("IsWalking", false);
        }
        
    }
}
