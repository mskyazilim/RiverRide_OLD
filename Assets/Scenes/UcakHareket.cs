using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UcakHareket : MonoBehaviour
{
    // Start is called before the first frame update
    float Dikey;
    float Yatay;
    Rigidbody2D Rigi;
    float UcakHiz;
    Vector3 fark;
    Vector3 UcakY;
    float Yatis;
    public GameObject KameraAl;
    public GameObject Puan;
    void Start()
    {
        Rigi = GetComponent<Rigidbody2D>();
        fark = KameraAl.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UcakMove();

        // Kamera Takip
        UcakY = transform.position + fark;
        KameraAl.transform.position = new Vector3(KameraAl.transform.position.x, UcakY.y,KameraAl.transform.position.z);
    }
    void UcakMove()
    {

        Dikey = Input.GetAxis("Vertical");
        if (Dikey > 0)
            UcakHiz = 2;
        else
            UcakHiz = 1;

        Yatay = Input.GetAxis("Horizontal");
       
        if (Yatay>0)
        {
            Yatis = 5;
           Yatay = 0;
            transform.Rotate(new Vector3(0, 1, 0)); 
        }
        else if (Yatay < 0)
        {
            Yatis = -5;
           Yatay = 0;
            transform.Rotate(new Vector3(0, -1, 0));
        } 
        else if (Yatay == 0)
            Yatis = 0;
       // transform.Rotate(new Vector3(0, 0, 0));
        Rigi.AddForce(new Vector3(Yatis, UcakHiz, 0));



    }
}
