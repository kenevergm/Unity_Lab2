using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using TMPro;

public class DragonPicker : MonoBehaviour
{

    private void OnEnable() => YandexGame.GetDataEvent += GetLoadSave;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoadSave;
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
     public float energyShieldBottomY = -6f;
     public float energyShieldRadius = 1.5f;

     public List<GameObject> shieldList;

     public TextMeshProUGUI scoreGT;

     public TextMeshProUGUI playerName;

    void Start()
    {
        if (YandexGame.SDKEnabled == true){
           GetLoadSave();
        }

        shieldList = new List<GameObject>();

        for (int i =1; i <= numEnergyShield; i++){
            GameObject tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            tShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShieldGo.transform.localScale = new Vector3(1*i, 1*i, 1*i);
            shieldList.Add(tShieldGo);
        }
    }


    public void DragonEggDestroyed(){
       GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("DragonEgg");
       foreach (GameObject tGO in tDragonEggArray){
        Destroy(tGO);
       }
       int shieldIndex = shieldList.Count - 1;
       GameObject tShieldGo = shieldList[shieldIndex];
       shieldList.RemoveAt(shieldIndex);
       Destroy(tShieldGo);

       if(shieldList.Count == 0){
        GameObject scoreGO = GameObject.Find("Score");
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        // string [] achivList ;
        // achivList = new string[5];
        // achivList = YandexGame.savesData.achivMent;
        // // achivList[0] = "Береги щиты!";
        UserSave(int.Parse(scoreGT.text), YandexGame.savesData.bestScore);
        YandexGame.NewLeaderboardScores("TOPPlayerScore", int.Parse(scoreGT.text));
        SceneManager.LoadScene("_0Scene");
        GetLoadSave();
       }
    }

    public void GetLoadSave(){
        Debug.Log(YandexGame.savesData.score);
        GameObject playerNamePrefabGUI = GameObject.Find("PlayerName");
        playerName = playerNamePrefabGUI.GetComponent<TextMeshProUGUI>();
        playerName.text = YandexGame.playerName;    
    }

    public void UserSave(int currentScore, int currentBestScore){
        if(currentScore > currentBestScore){
            YandexGame.savesData.bestScore = currentScore;
        }
        YandexGame.savesData.score = currentScore;
        YandexGame.SaveProgress();
    }
}
