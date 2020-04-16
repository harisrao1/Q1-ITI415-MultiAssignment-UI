using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Set Dynamically")]
    public GameObject Director;
    private List<GameObject> targetList;
    // Start is called before the first frame update
    void Start() {
        Director = GameObject.FindGameObjectWithTag("director");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        int index = -1;
        targetList = Director.GetComponent<TargetSpawner>().targetList;
        for (int i = 0; i< targetList.Count; i++)
        {
            if(targetList[i].name == this.name)
            {
                index = i;
            }
        }
        Director.GetComponent<TargetSpawner>().removeTarget(index);
        Destroy(this.gameObject);

    }
    
}
