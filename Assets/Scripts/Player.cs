using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}
public class Player : Character
{
    public PlayerState currentState;
    
    [SerializeField]
    private Stat health;
    
    [SerializeField]
    private Stat mana;

    
     private float initHealth = 100;
     private float initMana = 50;
    
    [SerializeField]
    private GameObject[] spellPrefab;

    [SerializeField]
    private Transform[] exitPoints;

    private int exitIndex;

    //Picking a target
    public Transform myTarget {get; set;}

   
    // Start is called before the first frame update
    protected override void Start()
    {
        health.Initialize(initHealth,initHealth);
        mana.Initialize(initMana,initMana);
        currentState = PlayerState.walk;
        base.Start();
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        GetInput();

        if(myTarget != null && Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk)
        {
            base.Update();
        }

        if(Input.GetKey(KeyCode.W))
        {
            exitIndex=2;
        }
        if(Input.GetKey(KeyCode.A))
        {
            exitIndex=3;
        }
        if(Input.GetKey(KeyCode.S))
        {
            exitIndex=0;
        }
        if(Input.GetKey(KeyCode.D))
        {
            exitIndex=1;
        }
        
    }



    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.4f);
        CastSpell();
        currentState = PlayerState.walk;
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

    public void CastSpell()
    {
        Instantiate(spellPrefab[0], exitPoints[exitIndex].position, Quaternion.identity);

    }

}
