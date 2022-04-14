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
            //Debug.Log(data[i]["proper"] + " " + data[i]["ra"] + " " + data[i]["dec"] + " " + data[i]["mag"]);
        }

    }

    /*public struct stars_type
    {
        public string name;
        public float ra, dec, mag;
        public stars_type(string name, float ra, float dec, float mag)
        {
            this.name = name;
            this.ra = ra;
            this.dec = dec;
            this.mag = mag;
        }
        public stars_type(string name, float ra_h, float ra_m, float ra_s, float dec_deg, float dec_m, float dec_s, float mag)
        {
            this.name = name;
            this.ra = ra_h + (ra_m / 60) + (ra_s / 3600);
            if(dec_deg>0) this.dec = dec_deg + (dec_m / 60) + (dec_s / 3600);
            else this.dec = dec_deg + -1*((dec_m / 60) + (dec_s / 3600));
            this.mag = mag;
        }
    }

    //public List<stars_type> star_Database = new List<stars_type>();

    /*void Start()
    {

        List<Dictionary<string,object>> data = CSVReader.Read("hygdata_v3");

        for (var i = 0; i < 10; i++)
        {
            //star_Database.Add(new stars_type(data[i]["proper"].ToString(), (float)data[i]["ra"], (float)data[i]["dec"], (float)data[i]["mag"]));
            Debug.Log(data[i]["proper"] + " " + data[i]["ra"] + " " + data[i]["dec"] + " " + data[i]["mag"]);
        }

    }

    public stars_type[] star_Database = new stars_type[]
    {
        new stars_type("Polaris", 3,0,18,89,21,26, 1.95f),
        new stars_type("Denebola",11,50,12,14,26,52, 2.10f), //사자자리
        new stars_type("Zosma",11,15,17,20,24,7, 2.55f),
        new stars_type("Chertan",11,15,24,15,18,28, 3.30f),
        new stars_type("Algieba",10,21,12,18,43,40, 2.20f),
        new stars_type("Regulus", 10,9,33,11,51,29, 1.35f),
        new stars_type("Aldzhabkhakh", 10,8,33,16,39,12, 3.45f),
        new stars_type("Adhafera",10,17,56,23,18,21, 3.40f),
        new stars_type("Rasalas",9,54,2,25,54,5, 3.85f),
        new stars_type("Algenubi",9,47,7,23,40,15, 2.95f),
        new stars_type("Nekkar",15,2,47,40,18,14, 3.45f), //목동자리
        new stars_type("Printseps", 15,16,24,33,13,58, 3.45f),
        new stars_type("Seginus",14,32,59,38,12,41, 3.00f),
        new stars_type("Izar", 14,45,58,26,58,53, 2.5f),
        new stars_type("Boo",14,32,47,30,16,29, 3.55f),
        new stars_type("Arcturus",14,16,41,19,3,58, 0.15f),
        new stars_type("BooB", 14,42,13,13,38,3, 4.45f),
        new stars_type("Muphrid",13,55,45,18,17,16,2.65f),
        new stars_type("uBoo",13,50,33,15,41,18,4.05f),
        new stars_type("RijlalAwwa",14,44,14,-5,45,11,3.85f), //처녀자리
        new stars_type("Syrma",14,17,11,-6,6,18,4.05f),
        new stars_type("kVir",14,14,4,-10,22,34,4.15f),
        new stars_type("Spica",13,26,22,-11,16,36,0.95f),
        new stars_type("Vir109",14,47,23,1,48,1,3.7f),
        new stars_type("Vir93", 14,2,47,1,26,16,4.2f),
        new stars_type("Heze",13,35,50,-0,43,33,3.35f)
    };*/
}
