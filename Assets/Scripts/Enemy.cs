using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSCodeEditor;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    static uint SpeedGradient = 7;
    void Start()
    {
        
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
}
