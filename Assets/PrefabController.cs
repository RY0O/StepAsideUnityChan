using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabController : MonoBehaviour
{

    /// <summary>
    /// 
    /// 複製してできるcloneの座標の取得方法がわからなかったため
    /// Prefabそのものに以下スクリプトを作りアタッチしました
    /// 
    ///
    /// 
    /// </summary>
    GameObject unityChan;
   
    void Start()
    {
        unityChan = GameObject.Find("unitychan"); GetComponent<Transform>();
    }

   
    void Update()
    {
    if(  this.transform.position.z< unityChan.transform.position.z -5)
        {
            Destroy(this.gameObject);
        }
    }
}
