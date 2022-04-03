using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStar : MonoBehaviour
{
    //https://medium.com/microsoft-design/building-a-virtual-sky-883d4d1080f4
    public GameObject star;
    StarDatabase sdb;
    int maxStar=9;

    // Start is called before the first frame update
    void Start()
    {
        sdb = GameObject.Find("StarDatabase").GetComponent<StarDatabase>();
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

        for (int i = 0; i < maxStar; i++)
        {
            ra = sdb.star_Database[i].ra * -15.0f * Mathf.Deg2Rad;
            dec = sdb.star_Database[i].dec * Mathf.Deg2Rad;
            SphericalToCartesian(ra, dec, r, ref x, ref y, ref z);
            GameObject Instance = Instantiate(star, new Vector3(x, y, z), Quaternion.identity);
            Instance.name = sdb.star_Database[i].name;

        }
    }

    void SphericalToCartesian (float ra, float dec, float r, ref float x, ref float y, ref float z)
    {
        dec = (Mathf.PI / 2) - dec;
        var rr = r * Mathf.Sin(dec);
        z = rr * Mathf.Cos(ra);
        x = rr * Mathf.Sin(ra);
        y = r * Mathf.Cos(dec);
    }

}
