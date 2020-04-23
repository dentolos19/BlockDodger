using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class UserConfiguration
{

    private static readonly string Source = Path.Combine(Application.persistentDataPath, "DodgeTheBlocks.cfg");
    private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(UserConfiguration));

    public int HighestScore { get; set; } = 0;

    public void Save()
    {
        using (var stream = new FileStream(Source, FileMode.Create))
            Serializer.Serialize(stream, this);
    }

    public static UserConfiguration Load()
    {
        if (!File.Exists(Source))
            return new UserConfiguration();
        using (var stream = new FileStream(Source, FileMode.Open))
            return Serializer.Deserialize(stream) as UserConfiguration;
    }

}