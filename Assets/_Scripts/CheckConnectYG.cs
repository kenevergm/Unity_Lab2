using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using TMPro;

public class CheckConnectYG : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += CheckSDK;
    private void OnDisable() => YandexGame.GetDataEvent -= CheckSDK;
    private TextMeshProUGUI scoreBest;
    void Start()
    {
        Debug.Log(YandexGame.SDKEnabled);
        if (YandexGame.SDKEnabled == true){
           CheckSDK();
        }
    }

    public void CheckSDK(){
        if (YandexGame.auth == true){
            Debug.Log("User autorization is ok");
        }
        else{
            Debug.Log("User not autorizate");
            YandexGame.AuthDialog();
        }
        GameObject scoreBO = GameObject.Find("BestScore");
        scoreBest = scoreBO.GetComponent<TextMeshProUGUI>();
        scoreBest.text = "Best score:" + YandexGame.savesData.bestScore.ToString();
        // if ((YandexGame.savesData.achivMent[0]) == null & !GameObject.Find("ListAchiv")){ 

        // }
        // else {
        //     foreach (string value in YandexGame.savesData.achivMent){
        //         GameObject.Find("ListAchiv").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ListAchiv").GetComponent<TextMeshProUGUI>().text + value + '\n';
        //     }
        // }
    }
}
