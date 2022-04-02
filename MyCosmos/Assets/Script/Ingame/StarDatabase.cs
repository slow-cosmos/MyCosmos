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
        new stars_type("Sirius", 6.752500f, -16.716101f, -1.460000f)

    };
}
