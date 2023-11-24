using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacter : MonoBehaviour
{
    private int health = 100;

    private void Start()
    {
        health = 100; 
    }

    public void Hurt(int damage)
    {
        health -= damage;

    }
}
