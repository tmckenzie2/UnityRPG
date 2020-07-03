using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class Spell 
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject spellPrefab;

    public string MyName
    {
        get{
            return name;
        }
        
    }

    public int MyDamage
    {
        get{
            return damage;
        }
        
    }

    public float MySpeed
    {
        get
        {
            return speed;
        }
    }

    public GameObject MySpellPrefab
    {
        get
        {
            return spellPrefab;
        }
    }

}

