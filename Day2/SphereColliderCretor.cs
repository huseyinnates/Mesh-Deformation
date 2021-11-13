using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColliderCretor : MonoBehaviour
{
   
    public GameObject parent;
    int _flag = 0;
    public float pos_z = 2f;
    public float radius=2f;
    public SphereCollider[] col;
    // Start is called before the first frame update
    void Start()
    {
        col=new SphereCollider[5];
        for (int i = 0; i <5; i++)
        {
            Vector3 a = new Vector3(0, 2*i, 0);
            
            col[i]=  parent.gameObject.AddComponent<SphereCollider>();

            col[i].center = a;
            col[i].radius = radius;
            
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < 5; i++)
                {
                    Vector3 a = new Vector3(0, 2, i*pos_z);
                   

                    col[i].center = a;
                    col[i].radius = radius;
                    

                }
                _flag++;
            

        }
    }
}
