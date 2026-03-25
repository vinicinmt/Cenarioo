using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class movimentoController : NetworkBehaviour
{
 public CharacterController characterController;
 public float speed = 5f;
 public Animator animator;   

    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    public override void FixedUpdateNetwork()
    {
       if (HasStateAuthority)
       {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direcao = new Vector3 (horizontal, 0, vertical);
            if (direcao.magnitude > 0.1f)
            {
                characterController.Move(direcao * speed * Runner.DeltaTime);
                transform.rotation = Quaternion.LookRotation(direcao);
                animator.SetBool("canWalk", true);
            }
            else
            {
                animator.SetBool("canWalk", false);
            }
       }
    }
}
