using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int speed = 1;
    public float distance;
    Vector3 startPosition= Vector3.zero;

    public GameObject cube;
    public int initCubePosition = 299600;
    public int initValue = 300;

    public List<GameObject> lists;
    public List<Material> materials;

    public Transform parent;
    
    public bool cubi_punto_interrogativo;
    
    private void Awake()
    {
        InitCube();
        this.transform.position = startPosition;
    }
    private void FixedUpdate()
    {
        distance = this.transform.position.z;
        //distance=Vector3.Distance(new Vector3(this.transform.position.x, this.transform.position.y, distance), startPosition);
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
    public void changeDistance(int changeDistance)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, changeDistance);
    }

    public void InitCube() {
        
        
        
        for (int i = 0; i < initValue; i += 2) {
            Vector3 v = new Vector3(3, 0, 299600 + i);
            GameObject newCube = null;

            if(cubi_punto_interrogativo)
                newCube = Instantiate(GetObjcet(), parent);
            else {
                newCube = Instantiate(cube, parent);
            }
            
            newCube.transform.position = v;
            newCube.isStatic = true;
        }
        for (int i = 0; i < initValue; i += 2) {
            Vector3 v = new Vector3(-3, 0, 299600 + i);
            GameObject newCube = null;
            if(cubi_punto_interrogativo)
                newCube = Instantiate(GetObjcet(), parent);
            else {
                newCube = Instantiate(cube, parent);
            }
            newCube.transform.position = v;
            newCube.isStatic = true;
        }
    }

    GameObject GetObjcet(){
        int value = UnityEngine.Random.Range(0, lists.Count);
        int material = UnityEngine.Random.Range(0, materials.Count);
        lists[value].GetComponent<MeshRenderer>().material = materials[material];
        return lists[value];
    }
}
