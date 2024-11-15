using System;
using System.Xml;

namespace XMLWriterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the XML file using XmlWriter
            CreateXMLFile();

            // Read the created XML file and display the output
            ReadAndDisplayXML();
        }

        static void CreateXMLFile()
        {
            // Setting up the XmlWriterSettings
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t"
            };

            using (XmlWriter writer = XmlWriter.Create("GPS.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("GPS_Log");

                // Adding the Position element with attributes and child elements
                writer.WriteStartElement("Position");
                writer.WriteAttributeString("DateTime", DateTime.Now.ToString());
                writer.WriteElementString("x", "65.8973342");
                writer.WriteElementString("y", "72.3452346");

                writer.WriteStartElement("SatteliteInfo");
                writer.WriteElementString("Speed", "40");
                writer.WriteElementString("NoSatt", "7");
                writer.WriteEndElement(); // End of SatteliteInfo

                writer.WriteEndElement(); // End of Position

                // Adding the Image element with attributes and child elements
                writer.WriteStartElement("Image");
                writer.WriteAttributeString("Resolution", "1024x800");
                writer.WriteElementString("Path", @"\images\1.jpg");
                writer.WriteEndElement(); // End of Image

                writer.WriteEndElement(); // End of GPS_Log
                writer.WriteEndDocument();
            }

            Console.WriteLine("XML file 'GPS.xml' created successfully.");
        }

        static void ReadAndDisplayXML()
        {
            // Load and display the XML content
            XmlDocument doc = new XmlDocument();
            doc.Load("GPS.xml");
            Console.WriteLine("\nReading and displaying the XML content:");
            doc.Save(Console.Out);
        }
    }
}

