using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.01f;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement += Vector3.forward;
            animator.SetInteger("MoveSpeed", 3);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement += Vector3.back;
            animator.SetInteger("MoveSpeed", 3);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement += Vector3.left;
            animator.SetInteger("MoveSpeed", 4);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement += Vector3.right;
            animator.SetInteger("MoveSpeed", 5);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetInteger("MoveSpeed", 1);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetInteger("MoveSpeed", 1);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetInteger("MoveSpeed", 1);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetInteger("MoveSpeed", 1);
        }
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
