using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere_mesh : MonoBehaviour
{
   
    public float radius = 3f,angle=10;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }
    private void OnDrawGizmos()
    {
        
        for (int i = 0; i < 6; i++)
        {
            for (int a = 0; a < 6; a++)
            {
                Gizmos.DrawCube(new Vector3(i, a + i, a),new Vector3(.2f,.2f,.2f));
                Gizmos.color = Color.green;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
