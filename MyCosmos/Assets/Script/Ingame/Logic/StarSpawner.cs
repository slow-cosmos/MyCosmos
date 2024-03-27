using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;

    [SerializeField] private int maxStarCount = 2000;

    [SerializeField] private float starSize = 2;

    [SerializeField] private float lat = 37.582474f; // 위도

    public List<Dictionary<string, string>> starDatabase;

    private void Awake()
    {
        starDatabase = CSVReader.Read("hygdata_v3");
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;
        float r = 1000.0f;
        float alt = 0.0f;
        float az = 0.0f;

        int starCount = 0;
        for (int i = 0; i < starDatabase.Count && starCount < maxStarCount; i++)
        {
            string name = starDatabase[i]["proper"];
            int id = int.Parse(starDatabase[i]["id"]);
            float ra = float.Parse(starDatabase[i]["ra"]); // 적도
            float dec = float.Parse(starDatabase[i]["dec"]); // 적경
            float mag = float.Parse(starDatabase[i]["mag"]); // 밝기

            EquatorialToHorizontal(ref alt, ref az, ra, dec);
            Debug.Log(alt + ", " + az);
            SphericalToCartesian(ref x, ref y, ref z, az * Mathf.Deg2Rad, alt * Mathf.Deg2Rad, r);

            if (y < 0) continue;

            float startSize = starSize * Mathf.Min(7.0f, -1.05f * mag + 7.0f);
            GameObject starInstance = Instantiate(starPrefab, new Vector3(x, y, z), Quaternion.identity);
            starInstance.transform.localScale = new Vector3(startSize, startSize, startSize);

            starInstance.name = name;
            starInstance.transform.parent = GameObject.Find("StarGroup").transform;
            starInstance.GetComponent<Star>().index = id;

            starCount++;
        }
    }

    // 적도 좌표계(적경, 적위) -> 천구(구면) 좌표계(고도, 방위각)
    private void EquatorialToHorizontal(ref float alt, ref float az, float ra, float dec)
    {
        /*
        ra : hour
        dec : -90 ~ +90
        lat : -90 ~ +90
        LST : hour
        az : -180 ~ 180 // TODO: 다시 확인, 0~360이 나와야함
        alt : -90 ~ +90
        HA : 0 ~ 360
        */

        float LST = ChapterManage.Instance.lst;
        float HA = (LST - ra) * 15 % 360;

        // 고도
        alt = Mathf.Rad2Deg * (Mathf.Asin(Mathf.Sin(dec * Mathf.Deg2Rad) * Mathf.Sin(lat * Mathf.Deg2Rad) +
            Mathf.Cos(dec * Mathf.Deg2Rad) * Mathf.Cos(lat * Mathf.Deg2Rad) * Mathf.Cos(HA * Mathf.Deg2Rad)));

        // 방위각
        az = Mathf.Rad2Deg * Mathf.Atan2(Mathf.Sin(HA * Mathf.Deg2Rad),
            Mathf.Cos(HA * Mathf.Deg2Rad) * Mathf.Sin(lat * Mathf.Deg2Rad) -
            Mathf.Tan(dec * Mathf.Deg2Rad) * Mathf.Cos(lat * Mathf.Deg2Rad));
    }

    // 구면 좌표계(고도, 방위각) -> 직교 좌표계(x, y, z)
    private void SphericalToCartesian(ref float x, ref float y, ref float z, float az, float alt, float r)
    {
        alt = 90 - alt; // 위에서 아래로 값이 증가하게
        var rr = r * Mathf.Sin(alt);
        z = rr * Mathf.Cos(az);
        x = rr * Mathf.Sin(az);
        y = r * Mathf.Cos(alt);
    }
}
