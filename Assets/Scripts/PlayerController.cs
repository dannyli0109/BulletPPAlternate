using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public Transform gunPoint;
    public Transform gunpointForAiming;
    public PlayerStats stats;
    
    Animator animator;
    CharacterController characterController;
    float angle;
    Vector2 movement;
    Inventory inventory;
    int inventoryIndex;
    float reloadTime;
    bool reloading;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        inventory = new Inventory(stats.inventoryCapacity);
        inventory.AddAugment(AugmentManager.GetAugments()[0]);
        inventoryIndex = 0;
        reloadTime = 0;
        reloading = true;
    }

    private void Update()
    {
        HandleRotation();
        HandleMovement();
        HandleAnimation();
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (reloading)
        {
            reloadTime += Time.deltaTime;
            if (reloadTime >= stats.reloadTime)
            {
                reloadTime = 0;
                reloading = false;
                inventoryIndex = 0;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                inventory[inventoryIndex++].Shoot(gunPoint);
                if (inventoryIndex >= inventory.Count)
                {
                    reloading = true;
                }
            }
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
