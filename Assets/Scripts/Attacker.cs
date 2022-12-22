using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform player;
    [SerializeField] float jumpDist;
    [SerializeField]Animator anim;
    [SerializeField] PuppetMaster pm;
    float predictionOffset;

    bool crashed;
    private void Start()
    {
        //predictionOffset = Random.Range(3, 5);
    }
    private void Update()
    {
        if(!crashed)
        transform.LookAt(player.position + Vector3.forward * predictionOffset);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Vector3.Distance(player.position, transform.position) < jumpDist)
        {
            StartCoroutine(Leap());
        }
    }
    IEnumerator Leap()
    {
        anim.SetTrigger("leap");
        yield return new WaitForSeconds(2.5f);
        if (!crashed)
        {
            Destroy(gameObject);
        }
    }
    public void Knock()
    {
        pm.state = PuppetMaster.State.Dead;
        crashed = true;
    }
}
