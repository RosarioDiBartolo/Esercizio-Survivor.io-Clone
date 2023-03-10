using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VSCodeEditor
{


    class OtherFunctions
    {
        static public bool FramesArePasssed(uint Frames)
        {
            return Time.frameCount % Frames == 0;
        }

        public static void Destroy(MonoBehaviour obj)
        {
            MonoBehaviour.Destroy(obj.gameObject);
        }
    }
}