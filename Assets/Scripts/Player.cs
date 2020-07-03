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
    private Stat mana;

    private SpellBook spellBook;

    
     private float initMana = 50;
    
    [SerializeField]
    private GameObject[] spellPrefab;

    [SerializeField]
    private Transform[] exitPoints;

    private int exitIndex;

    //Picking a target
    public Transform MyTarget {get; set;}

   
    // Start is called before the first frame update
    protected override void Start()
    {
        spellBook = GetComponent<SpellBook>();
        mana.Initialize(initMana,initMana);
        currentState = PlayerState.walk;
        base.Start();
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        GetInput();


        if (currentState == PlayerState.walk)
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



    private IEnumerator AttackCo(int spellIndex)
    {
        Transform currentTarget = MyTarget;
        Spell newSpell = spellBook.CastSpell(spellIndex);
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.4f);
        if (currentTarget != null)
        {
            SpellScript s = Instantiate(newSpell.MySpellPrefab, exitPoints[exitIndex].position, Quaternion.identity).GetComponent<SpellScript>();
            s.Initialize(currentTarget, newSpell.MyDamage);
        }
        
        //s.MyTarget = MyTarget;
        
        currentState = PlayerState.walk;
    }

    private void GetInput()
    {
        //if(Input.GetKeyDown(KeyCode.I)){
           // health.MyCurrentValue -=10;
           // mana.MyCurrentValue -= 10;
        //}
        
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
    }

    public void CastSpell(int spellIndex)
    {
        if(MyTarget != null && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo(spellIndex));
        }   

    }

}
