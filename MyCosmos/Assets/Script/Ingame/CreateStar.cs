using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStar : MonoBehaviour
{
    //https://medium.com/microsoft-design/building-a-virtual-sky-883d4d1080f4
    public GameObject star;
    StarDatabase sdb;
    ChapterManage chapterManage;
    GameObject Instance;

    [SerializeField]
    int maxStar;

    [SerializeField]
    float size;

    public float lst;
    float lat = 37.582474f;

    // Start is called before the first frame update
    void Start()
    {
        sdb = GameObject.Find("StarDatabase").GetComponent<StarDatabase>();
        chapterManage = GameObject.Find("ChapterManage").GetComponent<ChapterManage>();
        Init();
    }

    void Init()
    {
        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;
        float ra = 0.0f;
        float dec = 0.0f;
        float r = 1000.0f;
        float alt = 0.0f;
        float az = 0.0f;

        lst = chapterManage.lst;

        Debug.Log("lst: "+lst);

        for (int i = 0; i < maxStar; i++)
        {
            float startSize = size * Mathf.Min(7.0f, (-11 / 9) * sdb.star_Database[i].mag + (21 / 3));
            //ra = sdb.star_Database[i].ra * -15.0f * Mathf.Deg2Rad;
            //dec = sdb.star_Database[i].dec * Mathf.Deg2Rad;
            //SphericalToCartesian(ra, dec, r, ref x, ref y, ref z);
            EquatorialToHorizontal(sdb.star_Database[i].ra, sdb.star_Database[i].dec,lst,ref alt, ref az);
            SphericalToCartesian(az * Mathf.Deg2Rad, alt * Mathf.Deg2Rad, r, ref x, ref y, ref z);

            if (y < 0) continue;

            Instance = Instantiate(star, new Vector3(x, y, z), Quaternion.identity);
            Instance.name = sdb.star_Database[i].name;
            Instance.transform.localScale = new Vector3(startSize,startSize,startSize);
            
            //Debug.Log(sdb.star_Database[i].name + ":" + sdb.star_Database[i].ra + " " + sdb.star_Database[i].dec + " az "+ az + " alt " + alt);
            if (i == maxStar - 1) Debug.Log("마지막 mag: "+sdb.star_Database[i].mag);
        }
    }

    //지평좌표계 -> x,y,z
    void SphericalToCartesian (float az, float alt, float r, ref float x, ref float y, ref float z)
    {
        alt = (Mathf.PI / 2) - alt;
        var rr = r * Mathf.Sin(alt);
        z = rr * Mathf.Cos(az);
        x = rr * Mathf.Sin(az);
        y = r * Mathf.Cos(alt);
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



}
