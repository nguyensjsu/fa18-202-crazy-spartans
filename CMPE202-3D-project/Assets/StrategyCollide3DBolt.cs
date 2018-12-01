using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StrategyCollide3DBolt: MonoBehaviour, StrategyCollide {

    public void destoryPattern(DestroyByContact destroyByContact,GameObject other) {
        Instantiate(destroyByContact.explosion, destroyByContact.transform.position, destroyByContact.transform.rotation);
        destroyByContact.notifyObservers(destroyByContact.getScore());
        Destroy(destroyByContact.gameObject);
        Destroy(other);
    }
}
