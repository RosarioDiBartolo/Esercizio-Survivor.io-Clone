using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSCodeEditor;

public class Enemy : Entity
{ 
    public static List<Enemy> enemies = new List<Enemy>();

    static uint SpeedGradient = 7;
     

    public static Enemy Spawn(Vector3 pos)
    {
        Enemy e = Instantiate(GameHandler.Instance.EnemyPrefab, pos, Quaternion.identity);

        enemies.Add(e);

        return e;
    }

    void Start()
    {
        life = 30;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameHandler.Instance.Player.transform.position, SpeedGradient  * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent(typeof(Player)))
        {
 
            GameHandler.Instance.Player.life -= 15;
 
        }
    }

    private void OnDestroy()
    {
        enemies.Remove(this);
    }
}
