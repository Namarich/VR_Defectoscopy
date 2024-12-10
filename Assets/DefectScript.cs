using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefectScript : MonoBehaviour
{
    // Start is called before the first frame update

    private DefectoscopyProcess d;

    void Start()
    {
        d = GameObject.FindGameObjectWithTag("GameController").GetComponent<DefectoscopyProcess>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IGotFound()
    {
        d.FindDefect();
        gameObject.SetActive(false);
    }
}
