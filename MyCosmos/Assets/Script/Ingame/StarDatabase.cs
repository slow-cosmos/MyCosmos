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
        new stars_type("Sirius", 6.450891f, -16.425801f, -1.470000f),
        new stars_type("Regulus", 10.195816f, 19.50307f,2.01f), //사자자리
        new stars_type("Denebola",11.490388f, 14.34204f, 2.14f),
        new stars_type("Algieba",10.195816f, 19.50307f, 2.01f),
        new stars_type("Zozma", 11.140641f, 20.31265f, 2.56f),
        new stars_type("RasElased",9.455110f, 23.46274f, 2.97f),
        new stars_type("Aldhafera",10.164140f, 23.25024f, 3.43f),
        new stars_type("Chort",11.141444f, 15.25471f, 3.33f),
        new stars_type("Rasalas",9.524596f, 26.00255f, 3.88f)



    };
}
