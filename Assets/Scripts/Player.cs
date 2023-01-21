using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VSCodeEditor
{
     
    public class Player : Entity
    {

        static uint KnifeFrameRate = 200;
        static bool SpecialMove = false;
        public static uint MaxHealth = 100;
        static uint SpeedGradient = 10;
  
        void Start()
        {
            life = MaxHealth;
        }
        void ThrowKnife() {

            int c = Enemy.enemies.Count;
            if (c  > 0)
            {
                Enemy Target = Enemy.enemies[0];

                float Dist = Vector3.Distance(Target.transform.position, transform.position);

                for (int i = 1; i < c; i++)
                {
                    float NewDist = Vector3.Distance(Enemy.enemies[i].transform.position, transform.position);

                    if (NewDist < Dist)
                    {
                        Dist = NewDist;
                        Target = Enemy.enemies[i];
                    }
                }

                Knife k=  Instantiate(GameHandler.Instance.KnifePrefab , transform.position, Quaternion.identity);
                k.Target = Target;
            }





        }


        void Update()
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * SpeedGradient * Time.deltaTime;
             
            if (Input.GetKeyDown(KeyCode.LeftShift) && SpecialMove)
            {
                Debug.Log("Special Move Used");

                Enemy[] Enemies = FindObjectsOfType(typeof(Enemy)) as Enemy[];

                foreach (Enemy e in Enemies)
                {
                    Destroy(e.gameObject);
                }
                SpecialMove = false;
            }


            if (OtherFunctions.FramesArePasssed(KnifeFrameRate))
            {
                ThrowKnife();
            }

            if (OtherFunctions.FramesArePasssed(GameHandler.SpecialMoveRateFrame))
            { 
                SpecialMove = true;

                Debug.Log("Special Move Avaible");
            }

        }


        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject == GameHandler.Instance.BackGround ) {
                transform.position = Vector3.zero;
                
            }
        }
         
    }
}