using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    [HideInInspector]
    public Transform target;
    // Start is called before the first frame update
   private void LateUpdate() {
       Vector3 newPosition = target.position;
       newPosition.y=transform.position.y;
       transform.position=newPosition;
       transform.rotation=Quaternion.Euler(90.0f,target.eulerAngles.y,0.0f);
   }
}
