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
        //봄철 별자리
        new constell_type("목동자리 Bootes",new List<string>(){"187-287","187-318","279-287","Izar-279",
        "Arcturus-318","Arcturus-Izar","Arcturus-407","Arcturus-Mufrid","Mufrid-553"}),
        new constell_type("사자자리 Leo",new List<string>(){"Ras Elased Australis-462", "273-462", "Algieba-273",
        "Algieba-Zosma", "Denebola-Zosma", "Denebola-246", "Zosma-246", "Regulus-246", "Regulus-282",
        "Algieba-282"}),
        new constell_type("처녀자리 Virgo",new List<string>(){"Spica-624","564-624","457-564","Spica-255",
        "255-258","Porrima-258","Spica-Porrima","Vindemiatrix-258","Porrima-468","468-546","255-658","378-658"}),
        new constell_type("살쾡이자리 Lynx",new List<string>(){"203-421","421-983","500-983","500-677","677-1028","772-1028","772-853"}),
        new constell_type("작은사자자리 Leo Minor", new List<string>(){"410-633","633-907","410-907","907-960"}),
        new constell_type("왕관자리 Corona Borealis", new List<string>(){"350-611","Alphekka-350","Alphekka-418","418-1012","612-1012","612-1584"}),
        new constell_type("까마귀자리 Corvus", new List<string>(){"Algorab-728","Gienah Ghurab-Algorab","Kraz-Algorab","Kraz-184",
        "Gienah Ghurab-184","184-535"}),
        new constell_type("천칭자리 Libra", new List<string>(){"Zubeneschemali-Zubenelgenubi","Zubeneschemali-477","Zubenelgenubi-226","226-477","477-603"}),
        new constell_type("바다뱀자리 Hydra", new List<string>(){"173-1519","712-1519","304-712","195-304","195-425","335-425","335-588",
        "Alphard-588","Alphard-1009","959-1009","467-959","194-467","194-774","254-774","724-774","254-609","724-863","609-863"}),
        new constell_type("컵자리 Crater", new List<string>(){"1135-1986","1151-1986","559-1151","1135-1303","314-1303","314-559",
        "559-875","314-574","574-875"}),

        //여름철 별자리
        new constell_type("거문고자리 Lyra", new List<string>(){"Vega-765","Sheliak-765","650-765","227-Sheliak","227-650"}),
        new constell_type("독수리자리 Aquila", new List<string>(){"Altair-Tarazed","Altair-Alshain","Altair-252","175-252",
        "175-536","252-459","223-459","252-274"}),
        new constell_type("백조자리 Cygnus", new List<string>(){"Deneb-Sadr","Sadr-469","Albireo-469","Sadr-151","151-391",
        "391-414","Sadr-Gienah","Gienah-216","216-911"}),
        new constell_type("화살자리 Sagitta", new List<string>(){"293-1816","293-356","356-813","356-814"}),
        new constell_type("돌고래자리 Delphinus", new List<string>(){"400-699","699-847","344-847","344-400","344-543"}),
        new constell_type("헤라클레스자리 Hercules", new List<string>(){"205-479","205-283","136-283","136-479",
        "205-1066","616-1066","452-616","424-452","479-824","201-824","270-824","270-365","365-435","Kornephoros-136",
        "Kornephoros-383","283-634","478-634","478-1022"}),
        new constell_type("전갈자리 Scorpius", new List<string>(){"Shaula-86","86-174","Sargas-174","Sargas-242","242-1137",
        "179-1137","80-179","80-138","Antares-138","Antares-Graffias","Antares-Dschubba","Antares-159"}),
        new constell_type("뱀주인자리 Ophiuchus", new List<string>(){"89-1254","89-Cebalrai","Rasalhague-Cebalrai",
        "Rasalhague-214","214-219","97-219","89-97"}),
        new constell_type("뱀자리 Serpens", new List<string>(){"220-1045","220-670","306-670","306-746",
        "305-370","Unukalhai-370","Unukalhai-413","347-413","347-579","444-579","347-444"}),
        new constell_type("궁수자리 Sagittarius", new List<string>(){"Kaus Borealis-209","Kaus Meridionalis-Kaus Borealis",
        "Kaus Meridionalis-209","Nunki-209","Nunki-244","104-244","104-209","Kaus Australis-104","Kaus Australis-Kaus Meridionalis",
        "Kaus Meridionalis-Nash","Kaus Australis-Nash","Nash-954","Kaus Australis-193","Kaus Borealis-436","Nunki-299","299-390",
        "390-1414","480-1414","244-1015","845-1015","798-845","598-798","503-598","598-698"})



    };
}
