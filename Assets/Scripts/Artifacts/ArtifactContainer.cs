using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("ArtifactCollection")]
public class ArtifactContainer {
    
    [XmlArray("Artifacts")]
    [XmlArrayItem("Artifact")]
    public List<Artifact> artifacts = new List<Artifact>();

    public static ArtifactContainer Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);
        XmlSerializer serializer = new XmlSerializer(typeof(ArtifactContainer));
        StringReader reader = new StringReader(_xml.text);
        ArtifactContainer artifacts = serializer.Deserialize(reader) as ArtifactContainer;
        reader.Close();
        return artifacts;
    }
}
