using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using PackDesigner.ObjectModels;

namespace PackDesigner.BL
{
    public class XMLParser
    {
        public Document Deserialize(string path)
        {
            try
            {
                
                XDocument xdoc = XDocument.Load(path);
                Document doc = new Document
                {
                    RootX = float.Parse(xdoc.Element("folding").Attribute("rootX").Value),
                    RootY = float.Parse(xdoc.Element("folding").Attribute("rootY").Value),
                    OriginalDocumentHeight = float.Parse(xdoc.Element("folding").Attribute("originalDocumentHeight").Value),
                    OriginalDocumentWidth = float.Parse(xdoc.Element("folding").Attribute("originalDocumentWidth").Value),
                };

                doc.Panel = (CreatePanel(xdoc.Element("folding").Element("panels").Element("item")));


                return doc;
            }
            catch (FileNotFoundException)
            {
                throw new Exception($"file {path} not found");
            }
            catch(NullReferenceException)
            {
                throw new Exception("key field or attribute does not exist");
            }
        }

        private Panel CreatePanel(XElement xPanel)
        {
            Panel panel = new Panel
            {
                PanelId = xPanel?.Attribute("panelId")?.Value,
                PanelName = xPanel?.Attribute("panelName")?.Value,
                HingeOffset = float.Parse(xPanel.Attribute("hingeOffset").Value),
                PanelWidth = float.Parse(xPanel.Attribute("panelWidth").Value),
                PanelHeight = float.Parse(xPanel.Attribute("panelHeight").Value),
                AttachedToSide = int.Parse(xPanel.Attribute("attachedToSide").Value),
            };
            if (((XElement)xPanel.FirstNode).HasElements)
            {
                panel.AttachedPanels = new List<Panel>();
                foreach (var xAttachedPanel in xPanel.Element("attachedPanels").Elements("item"))
                {
                    panel.AttachedPanels.Add(CreatePanel(xAttachedPanel));
                }
            }
            return panel;
        }
    }
}
