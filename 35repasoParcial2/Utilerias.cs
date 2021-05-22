using System;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
public class Utilerias{
    public static void xmlGrabar(string ruta, Red red){
        FileStream fs = File.Open(ruta+".xml", FileMode.Create);
        XmlSerializer xml = new XmlSerializer(typeof(Red));
        xml.Serialize(fs,red);
        fs.Close();
    }

    public static void xmlLeer(string ruta, ref Red red){
        FileStream fs = File.Open(ruta+".xml", FileMode.Create);
        XmlSerializer xml = new XmlSerializer(typeof(Red));
        red = (Red)xml.Deserialize(fs);
        fs.Close();
    }

    public static void jsonGrabar(string ruta, Red red){
        StreamWriter sw = File.CreateText(ruta+".json");
        JsonSerializer json = new JsonSerializer();
        json.Serialize(sw, red);
        sw.Close();
    }

    public static void jsonLeer(string ruta, ref Red red){
        StreamReader sr = File.OpenText(ruta+".json");
        string srtData = sr.ReadToEnd();
        red = JsonConvert.DeserializeObject<Red>(srtData);
        sr.Close();
    }
}
