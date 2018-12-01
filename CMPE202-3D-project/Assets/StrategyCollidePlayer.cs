using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StrategyCollide3DPlayer : MonoBehaviour, StrategyCollide
{

    public void destoryPattern(DestroyByContact destroyByContact, GameObject other)
    {
        foreach (Observer observer in destroyByContact.getObservers())
        {
            ((GameController)observer).GameOver();
        }
        Destroy(other);

    }
}
