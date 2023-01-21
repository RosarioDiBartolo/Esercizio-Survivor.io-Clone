using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using VSCodeEditor;
 

namespace VSCodeEditor
{
    public class GameHandler: MonoBehaviour
    {
         public static uint SpecialMoveRateFrame = 2000;


        public static uint CureToSpawn = 100;
        public static uint CureSpawningRate = 10000;
        public static uint EnemiesSpawiningRate = 300;

        public static System.Random rnd = new System.Random();

        public GameObject BackGround;
        public Enemy EnemyPrefab;
        public Player Player;
        public Knife KnifePrefab;
        public Health HealthPrefab;

         

        const uint MinDist = 10;
        const uint MaxDist = 15;
        public static GameHandler Instance { get; private set; }

        private void Awake()
        {
            // If there is an instance, and it's not me, delete myself.

 
 

            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void CURE()
        {
            for (int i = 0; i < CureToSpawn; i++)
            {
                Instantiate(HealthPrefab, new Vector3(Random.Range(-80, 80), Random.Range(-50, 50),0), Quaternion.identity);
            }
        }

        private void SpawnEnemy()
        {


            Vector3 Pos = new Vector3(Random.Range(MinDist, MaxDist), Random.Range(MinDist, MaxDist), 0);

            for (int i = 0; i < 2; i++)
            {
                double d = rnd.NextDouble();
                if (d < 0.5)
                {
                    d = -1;
                }
                else
                {
                    d = 1;
                }

                Pos[i] *= (float)d;
            }

            Enemy e = Enemy.Spawn(Pos);
        }

        private void Update()
        {
 
            if (Player.life <= 0)
            {
                Destroy(Player.gameObject);
            }
            if (OtherFunctions.FramesArePasssed(EnemiesSpawiningRate))
            {
                SpawnEnemy();
            }

            if (OtherFunctions.FramesArePasssed(CureSpawningRate))
            {
                CURE();
            }
            
        }

    }
}