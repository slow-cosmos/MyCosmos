using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDatabase : MonoBehaviour
{
    public struct stars_type
    {
        public string name;
        public int id;
        public float ra, dec, mag;
        public stars_type(int id, string name, float ra, float dec, float mag)
        {
            this.id = id;
            this.name = name;
            this.ra = ra;
            this.dec = dec;
            this.mag = mag;
        }
    }

    public List<stars_type> star_Database = new List<stars_type>();

    void Start()
    {

        List<Dictionary<string, object>> data = CSVReader.Read("hygdata_v3");

        for (var i = 0; i < data.Count; i++)
        {
            star_Database.Add(new stars_type(
                int.Parse(data[i]["id"].ToString()),
                data[i]["proper"].ToString(),
                float.Parse(data[i]["ra"].ToString()),
                float.Parse(data[i]["dec"].ToString()),
                float.Parse(data[i]["mag"].ToString())));
        }

    }
}
