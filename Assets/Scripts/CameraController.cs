using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform attacker;
    [SerializeField] float camDist;
    [SerializeField] Vector3 offset;
    [SerializeField] Transform birdEyeCam;
    [SerializeField] Transform cam;
    private void Start()
    {
        GameEvents.instance.onNewAttacker += ChangeFocus;
        GameEvents.instance.onPlayerKnocked += ZoomOut;
    }
    void ChangeFocus(Transform focus)
    {

    }
    void ZoomOut()
    {
        Vector3 dir = (attacker.position - player.position).normalized;
        birdEyeCam.position = player.position - dir * camDist*2 + offset *1.5f;
        birdEyeCam.LookAt(player.position- dir*(camDist/3));
        birdEyeCam.gameObject.SetActive(true);
    }
    private void Update()
    {
        Vector3 dir = (attacker.position - player.position).normalized;
        cam.position = player.position - dir * camDist + offset;
        cam.LookAt(attacker);
    }
}
