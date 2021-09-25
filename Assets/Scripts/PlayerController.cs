using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform gunPoint;
    public Transform gunpointForAiming;
    public PlayerStats stats;
    public Bullet bulletPrefab;
    Animator animator;
    CharacterController characterController;
    float angle;
    Vector2 movement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleRotation();
        HandleMovement();
        HandleAnimation();
        HandleShooting(0);
    }

    private void HandleShooting(float angle)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Quaternion rotation = Quaternion.Euler(0, angle + transform.localEulerAngles.y, 0);
            Ammo ammo = Instantiate(bulletPrefab, gunPoint.position, rotation);
            ammo.Init();

        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void HandleRotation()
    {
        // Cast a ray from screen point
        Vector3 mousePosition = Input.mousePosition;
        //Debug.Log(mousePosition.y);
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        // Save the info
        RaycastHit hit;
        // You successfully hit
        if (Physics.Raycast(ray, out hit, 100, 1 << 18))
        {
            Vector3 dir = hit.point - gunpointForAiming.position;
            dir.y = 0;
            transform.localRotation = Quaternion.LookRotation(dir);
            angle = transform.localRotation.eulerAngles.y;

        }
    }

    void HandleMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

    void HandleAnimation()
    {
        float sin = Mathf.Sin(angle * Mathf.Deg2Rad);
        float cos = Mathf.Cos(angle * Mathf.Deg2Rad);
        float tx = movement.x;
        float ty = movement.y;

        Vector2 movemntRotated;
        movemntRotated.x = (cos * tx) - (sin * ty);
        movemntRotated.y = (sin * tx) + (cos * ty);

        animator.SetFloat("x", movemntRotated.x);
        animator.SetFloat("y", movemntRotated.y);
    }


    void MovePlayer()
    {
        characterController.Move(
            new Vector3(
                movement.x * stats.moveSpeed * Time.fixedDeltaTime,
                0,
                movement.y * stats.moveSpeed * Time.fixedDeltaTime
            )
        );
    }
}
