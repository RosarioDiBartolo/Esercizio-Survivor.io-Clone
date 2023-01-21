using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using VSCodeEditor;


    public abstract class HitGun : MonoBehaviour
    {

     
        public abstract uint getDamage();


        public abstract uint getSpeed();

        public Entity Target;



        protected void Update()
        {

            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, getSpeed() * Time.deltaTime);
            if (!Target)
            {
                Destroy(gameObject);
            }
        }



        public bool Hit(Entity e)
        {
            e.life -= getDamage();

            if (e.life <= 0)
            {
                OtherFunctions.Destroy(e);
            }

            return true;
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            Entity e = collision.gameObject.GetComponent(typeof(Entity)) as Entity;
        if (e)
        {
            if (Hit(e))
            {

                Destroy(gameObject);
            }
        }
        }
    }

 

 