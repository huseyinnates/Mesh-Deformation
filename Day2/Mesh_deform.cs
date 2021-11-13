using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class Mesh_deform : MonoBehaviour
{
    
    public GameObject parent,prefab_to_create_hit;
    public float radius = 2f;
    public SphereCollider[] col;
    /// <summary>
    /// ///////////////////
    /// </summary>
    public Vector3[] vertices;
    int[] triangles = new int[54];
    Mesh mesh;
    public Ray ray;
    public float[] increase,compare;
    public int max_16 = 12;
    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        SphereColliderCreator();
        increase = new float[16];
        compare = new float[16];
        mesh = new Mesh()
        {
            name = "Procedural mesh"
        };
        vertices= new Vector3[16];
        MeshShaper();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RayToHeight();
            Plane();
      
        }

        
    }

    public void Plane()
    {
        
        for (int l = 0; l < 16; l++)
        {
            if(compare[l] != increase[l])
            {
                Debug.Log("Somethings Different MeshShaper will work");
                MeshShaper();

                for (int j = 0; j < 16; j++)
                {
                    compare[j] = increase[j];
                }
                Debug.Log("COMPARE DATA IS SAVED ");


            }
        }
        Debug.Log("NOTHING HAPPEND ");

    }
    public void MeshShaper()
    {
        int k = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int a = 0; a < 4; a++)
            {

                vertices[k] = new Vector3(i, increase[k], a);

                SphereColliderForVerticesManager(k, radius, vertices[k]);

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
            Instantiate(prefab_to_create_hit, hit.point, Quaternion.identity);
        }
    }
    public void SphereColliderCreator()
    {
        col = new SphereCollider[16];
        for (int i = 0; i < 16; i++)
        {
            Vector3 a = new Vector3(-10, 0, 0);

            col[i] = parent.gameObject.AddComponent<SphereCollider>();

            col[i].center = a;
            col[i].radius = radius;

        }
    }
    public void SphereColliderForVerticesManager(int index,float radius,Vector3 pos)
    {
        col[index].center = pos;
        col[index].radius = radius;
    }
}
