using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationDatabase : MonoBehaviour
{
    public struct constell_type
    {
        public string krName;
        public string name;
        public List<string> construction;
        public bool check;
        public constell_type(string krName, string name, List<string> construction)
        {
            this.krName = krName;
            this.name = name;
            this.construction = construction;
            this.check = false;
        }
    }

    public constell_type[] springConstell = new constell_type[]
    {
        //봄철 별자리
        new constell_type("목동자리", "Bootes",new List<string>(){"187-287","187-318","279-287","Izar-279",
        "Arcturus-318","Arcturus-Izar","Arcturus-407","Arcturus-Mufrid","Mufrid-553"}),
        new constell_type("사자자리", "Leo",new List<string>(){"Ras Elased Australis-462", "273-462", "Algieba-273",
        "Algieba-Zosma", "Denebola-Zosma", "Denebola-246", "Zosma-246", "Regulus-246", "Regulus-282",
        "Algieba-282"}),
        new constell_type("처녀자리", "Virgo",new List<string>(){"Spica-624","564-624","457-564","Spica-255",
        "255-258","Porrima-258","Spica-Porrima","Vindemiatrix-258","Porrima-468","468-546","255-658","378-658"}),
        new constell_type("살쾡이자리", "Lynx",new List<string>(){"203-421","421-983","500-983","500-677","677-1028","772-1028","772-853"}),
        new constell_type("작은사자자리", "Leo Minor", new List<string>(){"410-633","633-907","410-907","907-960"}),
        new constell_type("왕관자리", "Corona Borealis", new List<string>(){"350-611","Alphekka-350","Alphekka-418","418-1012","612-1012","612-1584"}),
        new constell_type("까마귀자리", "Corvus", new List<string>(){"Algorab-728","Gienah Ghurab-Algorab","Kraz-Algorab","Kraz-184",
        "Gienah Ghurab-184","184-535"}),
        new constell_type("천칭자리", "Libra", new List<string>(){"Zubeneschemali-Zubenelgenubi","Zubeneschemali-477","Zubenelgenubi-226","226-477","477-603"}),
        new constell_type("바다뱀자리", "Hydra", new List<string>(){"173-1519","712-1519","304-712","195-304","195-425","335-425","335-588",
        "Alphard-588","Alphard-1009","959-1009","467-959","194-467","194-774","254-774","724-774","254-609","724-863","609-863"}),
        new constell_type("컵자리", "Crater", new List<string>(){"1135-1986","1151-1986","559-1151","1135-1303","314-1303","314-559",
        "559-875","314-574","574-875"})
    };

    public constell_type[] summerConstell = new constell_type[]
    {
        //여름철 별자리
        new constell_type("거문고자리", "Lyra", new List<string>(){"Vega-765","Sheliak-765","650-765","227-Sheliak","227-650"}),
        new constell_type("독수리자리", "Aquila", new List<string>(){"Altair-Tarazed","Altair-Alshain","Altair-252","175-252",
        "175-536","252-459","223-459","252-274"}),
        new constell_type("백조자리", "Cygnus", new List<string>(){"Deneb-Sadr","Sadr-469","Albireo-469","Sadr-151","151-391",
        "391-414","Sadr-Gienah","Gienah-216","216-911"}),
        new constell_type("화살자리", "Sagitta", new List<string>(){"293-1816","293-356","356-813","356-814"}),
        new constell_type("돌고래자리", "Delphinus", new List<string>(){"400-699","699-847","344-847","344-400","344-543"}),
        new constell_type("헤라클레스자리", "Hercules", new List<string>(){"205-479","205-283","136-283","136-479",
        "205-1066","616-1066","452-616","424-452","479-824","201-824","270-824","270-365","365-435","Kornephoros-136",
        "Kornephoros-383","283-634","478-634","478-1022"}),
        new constell_type("전갈자리", "Scorpius", new List<string>(){"Shaula-86","86-174","Sargas-174","Sargas-242","242-1137",
        "179-1137","80-179","80-138","Antares-138","Antares-Graffias","Antares-Dschubba","Antares-159"}),
        new constell_type("뱀주인자리", "Ophiuchus", new List<string>(){"89-1254","89-Cebalrai","Rasalhague-Cebalrai",
        "Rasalhague-214","214-219","97-219","89-97"}),
        new constell_type("뱀자리", "Serpens", new List<string>(){"220-1045","220-670","306-670","306-746",
        "305-370","Unukalhai-370","Unukalhai-413","347-413","347-579","444-579","347-444"}),
        new constell_type("궁수자리", "Sagittarius", new List<string>(){"Kaus Borealis-209","Kaus Meridionalis-Kaus Borealis",
        "Kaus Meridionalis-209","Nunki-209","Nunki-244","104-244","104-209","Kaus Australis-104","Kaus Australis-Kaus Meridionalis",
        "Kaus Meridionalis-Nash","Kaus Australis-Nash","Nash-954","Kaus Australis-193","Kaus Borealis-436","Nunki-299","299-390",
        "390-1414","480-1414","244-1015","845-1015","798-845","598-798","503-598","598-698"})
    };
    
    public constell_type[] autumnConstell = new constell_type[]
    {
        //가을철 별자리
        new constell_type("페가수스자리", "Pegasus", new List<string>(){"Scheat-Markab","Alpheratz-Scheat","Alpheratz-Algenib","Markab-Algenib",
        "Scheat-Matar","Matar-707","402-514","402-613","Markab-635","267-635","267-300","Enif-300","Scheat-294","294-514"}),
        new constell_type("안드로메다자리", "Andromeda", new List<string>(){"Alpheratz-229","Mirach-229","Mirach-Almaak","Mirach-447","447-949"}),
        new constell_type("페르세우스자리", "Perseus", new List<string>(){"Mirphak-Algol","Algol-240","240-642","Mirphak-163","163-393",
        "Mirphak-181","160-181","160-515","143-515","143-429"}),
        new constell_type("도마뱀자리", "Lacerta", new List<string>(){"614-947","392-768","392-839","839-979","768-979","768-947"}),
        //new constell_type("삼각형자리", "Triangulum", new List<string>(){"176-538","176-268","268-538"}),
        new constell_type("양자리", "Aries",  new List<string>(){"Hamal-333","Hamal-Sheratan","Sheratan-461"}),
        new constell_type("물고기자리", "Pisces", new List<string>(){"338-682","420-682","420-1026","859-1026","859-1345",
        "691-1345","691-850","850-2485","544-2485","544-606","606-912","912-1539","366-1539","366-700","606-700",
        "338-1098","1098-1180","1180-2837","1098-2837"}),
        //new constell_type("조랑말자리", "Equuleus", new List<string>(){"891-1974","891-1140","891-1140","481-1974"}),
        new constell_type("남쪽물고기자리", "Piscis Austrinus", new List<string>(){"Fomalhaut-628","628-2644","1672-2644","1525-1672",
        "716-1525","636-716"}),
        new constell_type("물병자리", "Aquarius", new List<string>(){"231-556","231-357","556-1326","623-1326","715-2645","623-2645",
        "Sadalmelik-623","Sadalmelik-453","349-453","349-548","381-548","381-671","505-671","Sadalsuud-Sadalmelik","Sadalsuud-408"}),
        new constell_type("염소자리", "Capricornus", new List<string>(){"189-321","189-604","189-576","576-599","576-706","401-706",
        "401-576","363-706","148-363"}),
        new constell_type("고래자리", "Cetus", new List<string>(){"277-327","Diphda-277","Diphda-312","Diphda-284","284-1181","666-1181",
        "666-1331","1331-1403","382-1403","327-382","280-570","570-2604","1331-2604","Menkar-280","Menkar-1143","692-1143",
        "692-719","719-1392","280-1392","719-783"})
    };

    public constell_type[] winterConstell = new constell_type[]
    {
        //겨울철 별자리
        new constell_type("오리온자리", "Orion", new List<string>(){"Alnilam-Mintaka","Alnilam-Alnitak","Alnitak-Saiph","Rigel-Saiph",
        "Rigel-Mintaka","Bellatrix-Mintaka","Bellatrix-256","Betelgeuse-256","Betelgeuse-Alnitak","Bellatrix-212","212-770",
        "770-1060","212-354","354-2363","881-2363","Betelgeuse-596","596-830","830-862","596-862","806-830","862-1905"}),
        new constell_type("큰개자리", "Canis Major", new List<string>(){"Sirius-496","Mirzam-496","Sirius-183","Wezen-183","Wezen-285",
        "285-466","466-496","496-958","Sirius-789","586-789","572-586","572-789","Wezen-528","Aludra-528","Adhara-285","Adhara-182","Adhara-290"}),
        new constell_type("토끼자리", "Lepus", new List<string>(){"Arneb-232","Arneb-Nihal","Nihal-213","213-232","232-787","Nihal-324","Arneb-388",
        "324-388","Arneb-308","308-368","368-1102","232-710","710-2278","787-861","787-861"}),
        new constell_type("황소자리", "Taurus", new List<string>(){"263-334","263-345","345-395","339-395","395-722","302-722",
        "Aldebaran-302","Aldebaran-260","260-345","302-695","Alnath-695","Aldebaran-170"}),
        new constell_type("쌍둥이자리", "Gemini", new List<string>(){"Castor-822","328-822","190-822","404-822","404-558","Pollux-558",
        "316-558","291-558","291-527","Alhena-527","291-320","250-320","152-190","152-237","237-618","190-602"}),
        new constell_type("외뿔소자리", "Monoceros", new List<string>(){"807-3582","389-518","389-615","615-790","491-790","615-807"}),
        new constell_type("마차부자리", "Auriga", new List<string>(){"Alnath-Hassaleh","Alnath-109","Menkalinan-109","Capella-Menkalinan",
        "Capella-360","Hassaleh-360"}),
        new constell_type("게자리", "Cancer", new List<string>(){"303-493","493-687","493-1088","540-1088","1088-1889"})
    };

    
}
