using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefectScript : MonoBehaviour
{
    // Start is called before the first frame update

    private DefectoscopyProcess d;
    private Pipe myPipe;

    void Start()
    {
        d = GameObject.FindGameObjectWithTag("GameController").GetComponent<DefectoscopyProcess>();
        myPipe = transform.parent.gameObject.GetComponent<Pipe>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IGotFound()
    {
        //d.FindDefect();
        myPipe.FindDefect();
        gameObject.SetActive(false);
    }
}
