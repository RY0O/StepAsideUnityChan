using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject coinPreFab;
    public GameObject carPreFab;
    public GameObject conePreFab;

    public float posRange =3.4f;
    public  int goalPos = 120;
    public  int startPos = -160;

    public GameObject unitychan;

    public int k=0;
    
    void Start()
    {

        this.unitychan= GameObject.Find("unitychan");GetComponent<Transform>();
               
    }


    void Update()
    {
        float u = unitychan.transform.position.z;
        if (u < startPos && startPos < u + 40)
            ///型は大丈夫？
        {


            startPos += 15;
            
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                for (float j = -1; j <= 1; j += 0.4F)
                {

                    ////
                    GameObject cone = Instantiate(conePreFab) as GameObject;

                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, startPos);

                    
                   
                }

            }

            else
            {
                for (int j = -1; j <= 1; j++)
                {
                    int item = Random.Range(1, 11);
                    int offsetZ = Random.Range(-5, 6);
                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPreFab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, startPos + offsetZ);

                        
                    }
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carPreFab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, startPos + offsetZ);

                        
                    }
                }
            }

           

            
            
            

        }

      


        ////作ったたくさんのPrefabのクローンをそれぞれ識別できない？
        ///→PrefabConntrollerをPrefabにアタッチして解決済み
        ///

        //if (gameObject.tag=="CarTag"
        //    && gameObject.transform.position.z<u-1)
        //{
        //    Destroy(gameObject);

        //}

        //if (gameObject.tag == "CoinTag"
        //    && gameObject.transform.position.z < u - 1)
        //{
        //    Destroy(gameObject);

        //}

        //if (gameObject.tag == "TrafficConeTag"
        //    && gameObject.transform.position.z < u - 1)
        //{
        //    Destroy(gameObject);

        //}







       

    }
}
