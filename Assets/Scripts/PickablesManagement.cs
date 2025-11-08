using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class Pickable
{
    public string objName;
    public string scene;
    public Vector3 pos;
    public bool isCollected;

    public Pickable(string objName, string scene, Vector3 pos, bool isCollected)
    {
        this.objName = objName;
        this.scene = scene;
        this.pos = pos;
        this.isCollected = isCollected;
    }
}

public class PickablesManagement : MonoBehaviour
{
    public static PickablesManagement Instance { get; private set; }

    public List<Pickable> pickables = new List<Pickable>();   // your list

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;

        pickables.Add(new Pickable("Broom", "大厅", new Vector3(7.2f, -3.66f, 0f), false));
        pickables.Add(new Pickable("Pen", "厨房餐厅", new Vector3(2.9f, -2.74f, 0f), true));
        pickables.Add(new Pickable("Pot", "厨房餐厅", new Vector3(8.21f, 2f, 0f), false));
        pickables.Add(new Pickable("Pumpkin", "花园", new Vector3(-2.65f, -3.68f, 0f), false));
        pickables.Add(new Pickable("Mushroom", "花园", new Vector3(-6.65f, 1.69f, 0f), false));
        pickables.Add(new Pickable("Spider", "花园", new Vector3(-1.45f, 1.34f, 0f), false));
        pickables.Add(new Pickable("Plant", "花园", new Vector3(2.73f, -3.07f, 0f), true));


        DontDestroyOnLoad(gameObject); // <-- keeps it alive across scenes
    }



    public void RecordPickables()
    {
        GameObject[] pickablesInScene = GameObject.FindGameObjectsWithTag("Pickables");

        foreach (GameObject pickable in pickablesInScene)
        {
            foreach (Pickable obj in pickables)
            {   
            if (obj.objName == pickable.name && !obj.isCollected)
            {
                    obj.pos = pickable.transform.position;
                    obj.scene = SceneManager.GetActiveScene().name;

            }
        }
        }

    }


    public void DetectPickables(string sceneName)
    {
        // Run when enters a new scene
        // Detect if any pickables should be placed into this scene
        foreach (Pickable obj in pickables)
        {   //Debug.Log("Pickables Status: " + obj.objName + " " + obj.scene + " " + obj.isCollected);
            if (obj.scene == sceneName && !obj.isCollected)
            {
                //Update obj in list
                GameObject objPrefab = Resources.Load<GameObject>("Prefabs/" + obj.objName);
                GameObject objClone = Instantiate(objPrefab, obj.pos, Quaternion.identity);
                objClone.name = objPrefab.name;

            }
        }
    }

    public void SetCollected(string objName)
    {
        foreach (Pickable obj in pickables)
        {
            if (obj.objName == objName && !obj.isCollected)
            {
                obj.isCollected = true;
            }
        }
    }


    public void UpdateDrop(string objName, string newScene, Vector3 newPos)
    {
        foreach (Pickable obj in pickables)
        {   //Debug.Log("Updating Drops");
            if (obj.objName == objName && obj.isCollected)
            {
                Debug.Log("Updating item:" + obj.objName);
                obj.scene = newScene;
                obj.pos = newPos;
                Debug.Log("New Position:" + newPos);
                obj.isCollected = false;
                Debug.Log("Object dropped, isCollected set to false");

                GameObject objPrefab = Resources.Load<GameObject>("Prefabs/" + obj.objName);
                GameObject objClone = Instantiate(objPrefab, obj.pos, Quaternion.identity);
                SpriteRenderer sr = objClone.GetComponent<SpriteRenderer>();
                sr.sortingOrder = 3;

                objClone.name = objPrefab.name;
            }
        }
    }

}







