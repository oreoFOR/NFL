using NaughtyAttributes;
using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    bool sprinting;
    [SerializeField]Image staminWheel;
    [SerializeField] float maxStamina;
    [SerializeField]float stamina;
    bool canSprint;
    private void Start()
    {
        stamina = maxStamina;
        anim = GetComponent<Animator>();
        canSprint = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canSprint)
        {
            sprinting = true;
            anim.SetBool("sprinting", sprinting);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sprinting = false;
            anim.SetBool("sprinting", sprinting);
        }
        if (sprinting)
        {
            stamina -= Time.deltaTime * 5;
            if(stamina <= 0)
            {
                stamina = 0;
                canSprint = false;
                sprinting = false;
                anim.SetBool("sprinting", sprinting);
                staminWheel.color = Color.red;
            }
            staminWheel.fillAmount = stamina / maxStamina;
        }

        else if(stamina<=maxStamina)
        {
            stamina += Time.deltaTime * 3.5f;
            staminWheel.fillAmount = stamina / maxStamina;
        }
        else
        {
            stamina = maxStamina;
            canSprint = true;
            staminWheel.color = Color.green;
        }
    }
}
