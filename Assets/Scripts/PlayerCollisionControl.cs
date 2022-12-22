using NaughtyAttributes;
using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionControl : MonoBehaviour
{
    [SerializeField] PuppetMaster pm;
    Animator anim;
    [SerializeField] Rigidbody football;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Attacker>().Knock();
        Knock();
    }
    [Button]
    public void Knock()
    {
        pm.state = PuppetMaster.State.Dead;
        football.isKinematic = false;
        football.transform.parent = null;
        anim.SetTrigger("knock");
        GameEvents.instance.PlayerKnocked();

    }
}
