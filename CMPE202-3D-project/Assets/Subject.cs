using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Subject 
{
    void addObserver(GameController gameController);
    void removeObserver(GameController gameController);
    void notifyObservers(int scoreChange);
}