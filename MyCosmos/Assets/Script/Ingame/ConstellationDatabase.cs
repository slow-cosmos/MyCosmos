using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationDatabase : MonoBehaviour
{
    public struct constell_type
    {
        public string name;
        public List<string> construction;
        public constell_type(string name,List<string> construction)
        {
            this.name = name;
            this.construction = construction;
        }
    }

    public constell_type[] constell_Database = new constell_type[]
    {
        new constell_type("Bootes",new List<string>(){"187","287","187","318","279","287","Izar","279",
        "Arcturus","318","Arcturus","Izar","Arcturus","407","Arcturus","Mufrid","Mufrid","553"}),
        new constell_type("Leo",new List<string>(){"Ras Elased Australis", "462", "273", "462", "Algieba", "273",
        "Algieba", "Zosma", "Denebola", "Zosma", "Denebola", "246", "Zosma", "246", "Regulus", "246", "Regulus", "282",
        "Algieba", "282"}),

    };
}
