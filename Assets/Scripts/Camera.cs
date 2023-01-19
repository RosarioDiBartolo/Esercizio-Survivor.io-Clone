using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


namespace VSCodeEditor
{

    public class Camera : MonoBehaviour
    {

        public Vector3 offset = new Vector3(0, 2, -10);
 
        
        private void LateUpdate()
        {
            transform.position = GameHandler.Instance.Player.transform.position + offset;
        }
    }
}