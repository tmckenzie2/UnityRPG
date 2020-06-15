using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
   
    // Start is called before the first frame update
    protected override void Start()
    {
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
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
    }
}
