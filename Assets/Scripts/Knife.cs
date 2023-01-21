using Guns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSCodeEditor;

public class Knife : HitGun
{
    static uint SpeedGradient = 10;
    static uint RotationGradient = 60;
    static uint ROTATION = RotationGradient * SpeedGradient;
     void Start()
    {
        
    }

    // Update is called once per frame
    private new void Update()
    { 
         transform.Rotate(new Vector3(0, 0, ROTATION) * Time.deltaTime);
        base.Update();

    }


    public override uint getDamage()
    {
        return 15;
    }

    public override uint getSpeed()
    {
        return SpeedGradient;
    }


    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent(typeof(Enemy)))
        {

            base.OnTriggerEnter2D(collision);

        }
    }
}
