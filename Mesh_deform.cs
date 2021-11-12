using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class Mesh_deform : MonoBehaviour
{

    public Vector3[] vertices;
    int[] triangles = new int[54];
    Mesh mesh;
    public Ray ray;
    public float[] increase;
    public int max_16 = 12;
    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        increase = new float[16];
        mesh = new Mesh()
        {
            name = "Procedural mesh"
        };
        vertices= new Vector3[16];
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RayToHeight();
            Plane(increase);
        }

        
    }
    public void Plane(float[] increase)
    {
        int k = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int a = 0; a < 4; a++)
            {
                
                vertices[k] = new Vector3(i, increase[k], a);
               
                
                k++;
            }
        }
        int index = 0;
        for (int l = 0; l < 3; l++)
        {
            for (int j = 0; j < 3; j++)
            {
                triangles[index++] = j + 4 * l; //
                triangles[index++] = j + 4 * l + 1;
                triangles[index++] = 4 * (l + 1) + j;

                triangles[index++] = 4 * (l + 1) + j;
                triangles[index++] = j + 4 * l + 1;
                triangles[index++] = 4 * (l + 1) + 1 + j;

            }
        }
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;
    }
    public void RayToHeight()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit, 30f))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
