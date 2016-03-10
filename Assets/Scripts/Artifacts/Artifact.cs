using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Artifact {

    [XmlElement("name")]
    public string name;
    [XmlElement("location")]
    public string location;
    [XmlElement("description")]
    public string description;

}
