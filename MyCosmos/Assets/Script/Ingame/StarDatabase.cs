using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDatabase : MonoBehaviour
{
    public struct stars_type
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
    }

    public stars_type[] star_Database = new stars_type[]
    {
        new stars_type("Polaris", 3.0095f, 89.2132f, 1.95f),
        new stars_type("Denebola",11.835f, 14.442f, 2.10f), //사자자리
        new stars_type("Zosma",11.252f, 20.401f, 2.55f),
        new stars_type("Chertan",11.254f, 15.304f, 3.30f),
        new stars_type("Algieba",10.352f,19.723f, 2.20f),
        new stars_type("Regulus", 10.1555f, 11.834f, 1.35f),
        new stars_type("Aldzhabkhakh", 10.138f,16.652f, 3.45f),
        new stars_type("Adhafera",10.292f,23.303f, 3.40f),
        new stars_type("Rasalas",9.903f,25.900f, 3.85f),
        new stars_type("Algenubi",9.795f, 23.669f, 2.95f),
        new stars_type("Nekkar",15.041f,40.302f, 3.45f), //목동자리
        new stars_type("Printseps", 15.319f, 33.226f, 3.45f),
        new stars_type("Seginus",14.543f, 38.206f, 3.00f),
        new stars_type("Izar", 14.759f,26.975f, 2.5f),
        new stars_type("Boo",14.541f,30.271f, 3.55f),
        new stars_type("Arcturus",14.273f,19.059f, 0.15f),
        new stars_type("BooB", 14.702f,13.633f, 4.45f)




    };
}
