using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Configuration
{

    public enum GameControl
    {

        Keyboard,
        Tilt,
        Touch

    }

    private static readonly string Source = Path.Combine(Application.persistentDataPath, "DodgeTheBlocks.cfg");
    private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(Configuration));

    public float Sensitivity { get; set; } = 20;
    public GameControl Control { get; set; }
    public int HighestScore { get; set; }
    public bool PrivacyPolicyAgreed { get; set; }
    public bool MuteGameSounds { get; set; }

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
            var control = Application.isMobilePlatform ? GameControl.Tilt : GameControl.Keyboard;
            return new Configuration { Control = control };
        }
        var stream = new FileStream(Source, FileMode.Open);
        var result = Serializer.Deserialize(stream) as Configuration;
        stream.Close();
        return result;
    }

}