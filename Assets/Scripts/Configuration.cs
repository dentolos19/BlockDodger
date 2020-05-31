using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Configuration
{

    private static readonly string Source = Path.Combine(Application.persistentDataPath, "DodgeTheBlocks.cfg");
    private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(Configuration));

    public int ControlType { get; set; }
    public int HighestScore { get; set; }
    public bool MuteSounds { get; set; }
    public bool IsPrivacyPolicyAgreed { get; set; }
    public float Sensitivity { get; set; }

    public void Save()
    {
        var stream = new FileStream(Source, FileMode.Create);
        Serializer.Serialize(stream, this);
        stream.Close();
    }

    public static Configuration Load()
    {
        if (!File.Exists(Source))
        {
            var control = 0;
            var sensitivity = 20;
            if (!Application.isMobilePlatform)
                return new Configuration { ControlType = control, Sensitivity = sensitivity };
            control = 1;
            sensitivity = 50;
            return new Configuration { ControlType = control, Sensitivity = sensitivity};
        }
        var stream = new FileStream(Source, FileMode.Open);
        var result = Serializer.Deserialize(stream) as Configuration;
        stream.Close();
        return result;
    }

}