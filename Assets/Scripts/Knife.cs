using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSCodeEditor;

public class Knife : MonoBehaviour
{
    static uint SpeedGradient = 10;
    static uint RotationGradient = 60;
    static uint ROTATION = RotationGradient * SpeedGradient;
    public Enemy Target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Target)
        {
            Destroy(gameObject);
        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, SpeedGradient * Time.deltaTime);
            transform.Rotate(new Vector3(0, 0, ROTATION) * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy e = collision.gameObject.GetComponent(typeof(Enemy)) as Enemy;
        if (e){
            Destroy(gameObject);

            Destroy(collision.gameObject);
        }
    }
}
