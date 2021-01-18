using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Building
{

    private void Start()
    {
        health = maxHealth;
    }

    private void OnDestroy()
    {
        print("GAME OVER");
    }
}
