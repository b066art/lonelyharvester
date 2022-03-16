using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Joystick joystick;
    public GameObject scythe;
    public GameObject arrow;

    private CharacterController controller;
    private Animator animator;
    private float moveSpeed = 4f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckGrass();
        Move();
        if(animator.GetCurrentAnimatorStateInfo(1).IsName("UpperBody.Harvesting"))
            scythe.SetActive(true);
        else
            scythe.SetActive(false);
    }

    private void Move()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 dir = new Vector3(horizontal, 0f, vertical);
        Vector3 velocity = moveSpeed * Time.deltaTime * dir;

        if (Mathf.Abs(horizontal) > 0.5 || Mathf.Abs(vertical) > 0.5) {
            animator.SetBool("Running", true); }
        else {
            animator.SetBool("Running", false); }

        if (dir.magnitude >= 0.3f) {
            transform.rotation = Quaternion.LookRotation(dir);
            controller.Move(velocity); }

        animator.SetFloat("Speed", dir.magnitude);
    }

    private void CheckGrass()
    {
        Collider[] hitColliders;
        int counter = 0;
        hitColliders = Physics.OverlapSphere(transform.position, 1.15f);
        foreach(Collider coll in hitColliders) {
            if (coll.gameObject.tag == "Grass")
                counter++; }
        if (counter != 0)
            animator.SetBool("Harvesting", true);
        else
            animator.SetBool("Harvesting", false);
    }
}
