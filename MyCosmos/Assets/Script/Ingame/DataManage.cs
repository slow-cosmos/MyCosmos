using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[System.Serializable]
public class SoundData
{
    public bool onBGM;
    public bool onSFX;
}

[System.Serializable]
public class GameData
{
    public bool[] chapterClear;
}

[System.Serializable]
public class ChapterData
{
    public bool[] springQuestClear;
    public bool[] summerQuestClear;
    public bool[] autumnQuestClear;
    public bool[] winterQuestClear;
}

public class DataManage : MonoBehaviour
{
    static GameObject _container;
    static DataManage _instance;
    public static DataManage Instance
    {
        get
        {
            if(!_instance)
            {
                _container = new GameObject();
                _container.name = "DataManage";
                _instance = _container.AddComponent(typeof(DataManage)) as DataManage;

                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }

    // 사운드 데이터 ---------------------------------------------

    public string SoundDataFileName = "SoundData.json";

    public SoundData soundData = new SoundData();

    public void LoadSoundData()
    {
        string filePath = Application.persistentDataPath + SoundDataFileName;
        if(File.Exists(filePath))
        {
            Debug.Log("불러오기 성공 : Sound Data");
            string FromJsonData = File.ReadAllText(filePath);
            soundData=JsonUtility.FromJson<SoundData>(FromJsonData);

            // 사운드
            SoundManage.Instance.onSFX = soundData.onSFX;
            SoundManage.Instance.onBGM = soundData.onBGM;
        }
    }

    public void SaveSoundData()
    {
        // 사운드
        soundData.onSFX = SoundManage.Instance.onSFX;
        soundData.onBGM = SoundManage.Instance.onBGM;

        string ToJsonData = JsonUtility.ToJson(soundData);
        string filePath = Application.persistentDataPath + SoundDataFileName;
        File.WriteAllText(filePath, ToJsonData);
        Debug.Log("저장 완료 : Sound Data");
    }

    // 전체 챕터 클리어 데이터 ---------------------------------------------

    public string GameDataFileName = "GameData.json";

    public GameData gameData = new GameData();

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;
        if(File.Exists(filePath))
        {
            Debug.Log("불러오기 성공 : Game Data");
            string FromJsonData = File.ReadAllText(filePath);
            gameData=JsonUtility.FromJson<GameData>(FromJsonData);
            
            // 챕터 클리어
            for(int i=0;i<gameData.chapterClear.Length;i++)
            {
                ChapterManage.Instance.chapterClear[i] = gameData.chapterClear[i];
            }
        }
    }

    public void SaveGameData()
    {
        //챕터 클리어
        gameData.chapterClear = new bool[ChapterManage.Instance.chapterClear.Length];
        for(int i=0;i<ChapterManage.Instance.chapterClear.Length;i++)
        {
            gameData.chapterClear[i] = ChapterManage.Instance.chapterClear[i];
        }

        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;
        File.WriteAllText(filePath, ToJsonData);
        Debug.Log("저장 완료 : Game Data");
    }

    // 챕터 데이터 ---------------------------------------------

    public string ChapterDataFileName = "ChapterData.json";

    public ChapterData chapterData = new ChapterData();

    public void LoadChapterData()
    {
        string filePath = Application.persistentDataPath + ChapterDataFileName;
        if(File.Exists(filePath))
        {
            Debug.Log("불러오기 성공 : Chapter Data");
            string FromJsonData = File.ReadAllText(filePath);
            chapterData=JsonUtility.FromJson<ChapterData>(FromJsonData);

            CheckConstellation constellDB = GameObject.Find("CheckConstellation").GetComponent<CheckConstellation>();
            
            //봄 챕터 퀘스트 클리어
            for(int i=0;i<chapterData.springQuestClear.Length;i++)
            {
                constellDB.springConstell[i].check = chapterData.springQuestClear[i];
            }

            //여름 챕터 퀘스트 클리어
            for(int i=0;i<chapterData.summerQuestClear.Length;i++)
            {
                constellDB.summerConstell[i].check = chapterData.summerQuestClear[i];
            }

            //가을 챕터 퀘스트 클리어
            for(int i=0;i<chapterData.autumnQuestClear.Length;i++)
            {
                constellDB.autumnConstell[i].check = chapterData.autumnQuestClear[i];
            }

            //겨울 챕터 퀘스트 클리어
            for(int i=0;i<chapterData.winterQuestClear.Length;i++)
            {
                constellDB.winterConstell[i].check = chapterData.winterQuestClear[i];
            }
            
        }
    }

    public void SaveChapterData()
    {
        CheckConstellation constellDB = GameObject.Find("CheckConstellation").GetComponent<CheckConstellation>();

        //봄 챕터 퀘스트 클리어
        chapterData.springQuestClear = new bool[constellDB.springConstell.Length];
        for(int i=0;i<constellDB.springConstell.Length;i++)
        {
            chapterData.springQuestClear[i] = constellDB.springConstell[i].check;
        }

        //여름 챕터 퀘스트 클리어
        chapterData.summerQuestClear = new bool[constellDB.summerConstell.Length];
        for(int i=0;i<constellDB.summerConstell.Length;i++)
        {
            chapterData.summerQuestClear[i] = constellDB.summerConstell[i].check;
        }

        //가을 챕터 퀘스트 클리어
        chapterData.autumnQuestClear = new bool[constellDB.autumnConstell.Length];
        for(int i=0;i<constellDB.autumnConstell.Length;i++)
        {
            chapterData.autumnQuestClear[i] = constellDB.autumnConstell[i].check;
        }

        //겨울 챕터 퀘스트 클리어
        chapterData.winterQuestClear = new bool[constellDB.winterConstell.Length];
        for(int i=0;i<constellDB.winterConstell.Length;i++)
        {
            chapterData.winterQuestClear[i] = constellDB.winterConstell[i].check;
        }

        string ToJsonData = JsonUtility.ToJson(chapterData);
        string filePath = Application.persistentDataPath + ChapterDataFileName;
        File.WriteAllText(filePath, ToJsonData);
        Debug.Log("저장 완료 : Chapter Data");
    }
}
