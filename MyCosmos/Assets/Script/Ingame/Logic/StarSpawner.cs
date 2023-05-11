using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StarInfo
{
    public string name;
    public int id;
    public float ra, dec, mag;
    public StarInfo(int id, string name, float ra, float dec, float mag)
    {
        this.id = id;
        this.name = name;
        this.ra = ra;
        this.dec = dec;
        this.mag = mag;
    }
}

public class StarSpawner : MonoBehaviour
{
    public GameObject star;
    GameObject Instance;

    [SerializeField]
    int maxStar;

    [SerializeField]
    float size;

    public float lst;
    float lat = 37.582474f;

    public List<StarInfo> starDatabase = new List<StarInfo>();

    void Awake()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("hygdata_v3");

        for (var i = 0; i < data.Count; i++)
        {
            starDatabase.Add(new StarInfo(
                int.Parse(data[i]["id"].ToString()),
                data[i]["proper"].ToString(),
                float.Parse(data[i]["ra"].ToString()),
                float.Parse(data[i]["dec"].ToString()),
                float.Parse(data[i]["mag"].ToString())));
        }
    }

    void Start()
    {
        Init();
    }

    void Init()
    {
        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;
        float r = 1000.0f;
        float alt = 0.0f;
        float az = 0.0f;

        lst = ChapterManage.Instance.lst;
        
        for (int i = 0; i < maxStar; i++)
        {
            EquatorialToHorizontal(starDatabase[i].ra, starDatabase[i].dec,lst,ref alt, ref az);
            SphericalToCartesian(az * Mathf.Deg2Rad, alt * Mathf.Deg2Rad, r, ref x, ref y, ref z);

            // 지평선 아래는 생성하지 않게
            if (y < 0) continue;

            float startSize = size * Mathf.Min(7.0f, (-11 / 9) * starDatabase[i].mag + (21 / 3));
            Instance = Instantiate(star, new Vector3(x, y, z), Quaternion.identity);
            Instance.transform.localScale = new Vector3(startSize,startSize,startSize);

            Instance.name = starDatabase[i].name;
            Instance.transform.parent = GameObject.Find("StarGroup").transform;
            Instance.GetComponent<Star>().index = starDatabase[i].id;
            
            //Debug.Log(sdb.star_Database[i].name + ":" + sdb.star_Database[i].ra + " " + sdb.star_Database[i].dec + " az "+ az + " alt " + alt);
            if (i == maxStar - 1) Debug.Log("마지막 mag: "+starDatabase[i].mag);
        }
    }

    //적도좌표계 -> 지평좌표계
    void EquatorialToHorizontal(float ra, float dec, float lst, ref float alt, ref float az)
    {
        float ha = (lst - ra)*15%360;

        alt = Mathf.Rad2Deg*(Mathf.Asin(Mathf.Sin(Mathf.Deg2Rad*dec) * Mathf.Sin(Mathf.Deg2Rad*lat) +
            Mathf.Cos(Mathf.Deg2Rad*dec) * Mathf.Cos(Mathf.Deg2Rad*lat) * Mathf.Cos(Mathf.Deg2Rad*ha)));

        az = Mathf.Rad2Deg*(Mathf.Atan2(-Mathf.Cos(Mathf.Deg2Rad*dec)*Mathf.Sin(Mathf.Deg2Rad*ha),
            Mathf.Sin(Mathf.Deg2Rad*dec)*Mathf.Cos(Mathf.Deg2Rad*lat)-
            Mathf.Cos(Mathf.Deg2Rad*dec)*Mathf.Sin(Mathf.Deg2Rad*lat)*Mathf.Cos(Mathf.Deg2Rad*ha)));
    }

    //지평좌표계 -> x,y,z
    void SphericalToCartesian(float az, float alt, float r, ref float x, ref float y, ref float z)
    {
        alt = (Mathf.PI / 2) - alt;
        var rr = r * Mathf.Sin(alt);
        z = rr * Mathf.Cos(az);
        x = rr * Mathf.Sin(az);
        y = r * Mathf.Cos(alt);
    }
}
