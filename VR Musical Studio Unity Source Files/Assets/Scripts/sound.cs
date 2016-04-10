using UnityEngine;
using System.Collections;

public class sound : MonoBehaviour
{
    AudioSource a;
    FloorTom floor;


    void Start()
    {
        a = GetComponent<AudioSource>();
        GameObject go = GameObject.Find("wood_scen");
        floor = go.GetComponent<FloorTom>();

    }

    //void OnMouseOver() {
    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag.Equals("IndexLeft"))
        {
            print("Palm");
            floor.flag = "1";
            a.Play();
            //print("Palm");
        }

        if (Col.gameObject.tag.Equals("IndexRight"))
        {
            print("Palm2");
            floor.flag = "2";
            a.Play();
            //print("Palm");
        }

    }

    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag.Equals("IndexLeft"))
        {
            print("Palm");
            floor.flag = "0";
             //print("Palm");
        }

        if (Col.gameObject.tag.Equals("IndexRight"))
        {
            print("Palm2");
            floor.flag = "0";
            //print("Palm");
        }


    }


}
