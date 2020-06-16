using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Stat health;
    
    [SerializeField]
    private Stat mana;
    
     private float initHealth = 100;
     private float initMana = 50;

   
    // Start is called before the first frame update
    protected override void Start()
    {
        health.Initialize(initHealth,initHealth);
        mana.Initialize(initMana,initMana);
        base.Start();
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        GetInput();
        base.Update();
        
    }

    private void GetInput()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            health.MyCurrentValue -=10;
            mana.MyCurrentValue -= 10;
        }
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
    }
}
