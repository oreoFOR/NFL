using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public event Action<Transform> onNewAttacker;
    public void NewAttacker(Transform attacker)
    {
        if(onNewAttacker != null)
        {
            onNewAttacker(attacker);
        }
    }
    public event Action onPlayerKnocked;
    public void PlayerKnocked()
    {
        onPlayerKnocked();
    }
}
