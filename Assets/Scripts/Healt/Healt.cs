using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Healt : MonoBehaviour
{
    private int healtCount = 0;
    public int HealtCount { get { return healtCount; } set { healtCount = value; } }

    private int damage = 0;
    public int Damage { get { return damage; } set { damage = value; } }

    private bool dead = false;
    public bool Dead { get { return dead; } set { dead = value; } }

    private int thisHash;

    private void Awake()
    {
        thisHash = gameObject.GetHashCode();
    }

}
