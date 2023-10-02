using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove1 : MonoBehaviour
{


    [SerializeField] private float moveSpeed;

    private Vector3 moveDirection;


    [SerializeField] private CharacterController characterController;
    // Start is called before the first frame update
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
     
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 move =  new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
       
        moveDirection = move * moveSpeed * Time.deltaTime;
        characterController.Move(moveDirection);
    }
}