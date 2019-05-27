using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PackDesigner.ObjectModels;
using PackDesigner.ObjectModels.Animations;

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
                    EnableEffects = bool.Parse(xdoc.Element("folding").Attribute("enableEffects").Value),
                    DebugMode = bool.Parse(xdoc.Element("folding").Attribute("debugMode").Value),
                    ShowStats = bool.Parse(xdoc.Element("folding").Attribute("showStats").Value),
                    CalculatePanelCollisions = bool.Parse(xdoc.Element("folding").Attribute("calculatePanelCollisions").Value),
                    AllowMouseInteraction = bool.Parse(xdoc.Element("folding").Attribute("allowMouseInteraction").Value),
                    AdjustCameraTargetPosition = bool.Parse(xdoc.Element("folding").Attribute("adjustCameraTargetPosition").Value),
                    FreeCamera = bool.Parse(xdoc.Element("folding").Attribute("freeCamera").Value),
                    StartPosition = xdoc.Element("folding").Attribute("startPosition").Value == "null" ? null : (int?)(int.Parse(xdoc.Element("folding").Attribute("startPosition").Value)),
                    InitialCameraX = float.Parse(xdoc.Element("folding").Attribute("initialCameraX").Value),
                    InitialCameraY = float.Parse(xdoc.Element("folding").Attribute("initialCameraY").Value),
                    Show3DStats = bool.Parse(xdoc.Element("folding").Attribute("show3DStats").Value),
                    BackgroundColor = xdoc.Element("folding").Attribute("backgroundColor").Value,
                    RootX = float.Parse(xdoc.Element("folding").Attribute("rootX").Value),
                    RootY = float.Parse(xdoc.Element("folding").Attribute("rootY").Value),
                    OriginalDocumentHeight = int.Parse(xdoc.Element("folding").Attribute("originalDocumentHeight").Value),
                    OriginalDocumentWidth = int.Parse(xdoc.Element("folding").Attribute("originalDocumentWidth").Value),
                    InitialCameraRadius = int.Parse(xdoc.Element("folding").Attribute("initialCameraRadius").Value),
                    IconSetID = xdoc.Element("folding").Attribute("iconSetID").Value,
                    AutoPlaySequence = bool.Parse(xdoc.Element("folding").Attribute("autoPlaySequence").Value),
                    LoopSequence = bool.Parse(xdoc.Element("folding").Attribute("loopSequence").Value),
                    InitialCameraTargetX = float.Parse(xdoc.Element("folding").Attribute("initialCameraTargetX").Value),
                    InitialCameraTargetY = float.Parse(xdoc.Element("folding").Attribute("initialCameraTargetY").Value),
                    InitialCameraTargetZ = float.Parse(xdoc.Element("folding").Attribute("initialCameraTargetZ").Value),
                    Lights = new List<Light>(),
                    Materials = new List<Material>(),
                    Animations = new List<Animation>()
                };

                foreach (var xLight in xdoc.Element("folding").Element("lights").Elements("item"))
                {
                    Light light = new Light
                    {
                        Id = xLight.Attribute("id").Value,
                        Name = xLight.Attribute("name").Value,
                        Type = xLight.Attribute("type").Value,
                        X = float.Parse(xLight.Attribute("x").Value),
                        Y = float.Parse(xLight.Attribute("y").Value),
                        Z = float.Parse(xLight.Attribute("z").Value),
                        Color = xLight.Attribute("color").Value,
                        Ambient = float.Parse(xLight.Attribute("ambient").Value),
                        Diffuse = float.Parse(xLight.Attribute("diffuse").Value),
                        Specular = float.Parse(xLight.Attribute("specular").Value),
                        AttachToCamera = bool.Parse(xLight.Attribute("attachToCamera").Value),
                        FallOff = int.Parse(xLight.Attribute("fallOff").Value)
                    };
                    doc.Lights.Add(light);
                }

                foreach(var xMaterial in xdoc.Element("folding").Element("materials").Elements("item"))
                {
                    Material material = new Material
                    {
                        Id = xMaterial.Attribute("id").Value,
                        Transparency = int.Parse(xMaterial.Attribute("transparency").Value),
                        MaterialType = xMaterial.Attribute("materialType").Value,
                        Name = xMaterial.Attribute("name").Value,
                        Color = xMaterial.Attribute("color").Value,
                        ResourceMap = xMaterial.Attribute("resourceMap").Value,
                        Ambient = float.Parse(xMaterial.Attribute("ambient").Value),
                        AmbientColor = xMaterial.Attribute("ambientColor").Value,
                        Specular = float.Parse(xMaterial.Attribute("specular").Value),
                        Gloss = xMaterial.Attribute("gloss").Value == "NaN" ? null : (int?)(int.Parse(xMaterial.Attribute("gloss").Value)),
                        PageNumber = int.Parse(xMaterial.Attribute("pageNumber").Value),
                        DocumentIdentifier = xMaterial.Attribute("documentIdentifier").Value,
                        EmbossMapType = xMaterial.Attribute("embossMapType").Value,
                        EmbossMap = xMaterial.Attribute("embossMap").Value,
                        SpecularMap = xMaterial.Attribute("specularMap").Value,
                        ReflectionIntensity = int.Parse(xMaterial.Attribute("reflectionIntensity").Value),
                        ReflectionMask = xMaterial.Attribute("reflectionMask").Value,
                        ReflectionMapName = xMaterial.Attribute("reflectionMapName").Value,
                        Mask = xMaterial.Attribute("mask").Value,
                        MirrorMaskOverYAxis = bool.Parse(xMaterial.Attribute("mirrorMaskOverYAxis").Value),
                        RenderPanelOutLines = bool.Parse(xMaterial.Attribute("renderPanelOutLines").Value),
                        InvertMask = bool.Parse(xMaterial.Attribute("invertMask").Value),
                        MirrorMask = bool.Parse(xMaterial.Attribute("mirrorMask").Value),
                    };
                    doc.Materials.Add(material);
                }

                doc.Panel = (CreatePanel(xdoc.Element("folding").Element("panels").Element("item")));

                foreach (var xAnimation in xdoc.Element("folding").Element("sequences").Element("sequence").Elements("item"))
                {
                    doc.Animations.Add(CreateAnimation(xAnimation));
                }

                return doc;
            }
            catch(Exception ex)
            {
                throw new Exception($"XML pares error - {ex.Message}");
            }
        }

        private Panel CreatePanel(XElement xPanel)
        {
            Panel panel = new Panel
            {
                PanelId = xPanel.Attribute("panelId").Value,
                PanelName = xPanel.Attribute("panelName").Value,
                MinRot = int.Parse(xPanel.Attribute("minRot").Value),
                MaxRot = int.Parse(xPanel.Attribute("maxRot").Value),
                InitialRot = int.Parse(xPanel.Attribute("initialRot").Value),
                StartRot = int.Parse(xPanel.Attribute("startRot").Value),
                EndRot = int.Parse(xPanel.Attribute("endRot").Value),
                HingeOffset = float.Parse(xPanel.Attribute("hingeOffset").Value),
                PanelWidth = float.Parse(xPanel.Attribute("panelWidth").Value),
                PanelHeight = float.Parse(xPanel.Attribute("panelHeight").Value),
                AttachedToSide = int.Parse(xPanel.Attribute("attachedToSide").Value),
                CreaseBottom = float.Parse(xPanel.Attribute("creaseBottom").Value),
                CreaseTop = float.Parse(xPanel.Attribute("creaseTop").Value),
                CreaseLeft = float.Parse(xPanel.Attribute("creaseLeft").Value),
                CreaseRight = float.Parse(xPanel.Attribute("creaseRight").Value),
                IgnoreCollisions = bool.Parse(xPanel.Attribute("ignoreCollisions").Value),
                MouseEnabled = bool.Parse(xPanel.Attribute("mouseEnabled").Value)
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

        private Animation CreateAnimation(XElement xAnimation)
        {
            string targetType = xAnimation.Attribute("targetType").Value;
            Animation animation;
            switch (targetType)
            {
                case "cameraAnimation":
                    animation = new CameraAnimation
                    {
                        FromXRad = float.Parse(xAnimation.Attribute("fromXRad").Value),
                        ToXRad = float.Parse(xAnimation.Attribute("toXRad").Value),
                        FromYRad = float.Parse(xAnimation.Attribute("fromYRad").Value),
                        ToYRad = float.Parse(xAnimation.Attribute("toYRad").Value),
                        FromRadius = int.Parse(xAnimation.Attribute("fromRadius").Value),
                        ToRadius = int.Parse(xAnimation.Attribute("toRadius").Value),
                    };
                    break;
                case "cameraTargetAnimation":
                    animation = new CameraTargetAnimation
                    {
                        FromX = int.Parse(xAnimation.Attribute("fromX").Value),
                        ToX = int.Parse(xAnimation.Attribute("toX").Value),
                        FromY = int.Parse(xAnimation.Attribute("fromY").Value),
                        ToY = int.Parse(xAnimation.Attribute("toY").Value),
                        FromZ = int.Parse(xAnimation.Attribute("fromZ").Value),
                        ToZ = int.Parse(xAnimation.Attribute("toZ").Value),
                    };
                    break;
                case "panelAnimation":
                    animation = new PanelAnimation
                    {
                        Panel = xAnimation.Attribute("panel").Value,
                        From = float.Parse(xAnimation.Attribute("from").Value),
                        To = float.Parse(xAnimation.Attribute("to").Value),
                    };
                    break;
                default:
                    throw new Exception("Incorrect animation target type");
            }
            animation.TargetType = targetType;
            animation.Delay = int.Parse(xAnimation.Attribute("delay").Value);
            animation.Time = int.Parse(xAnimation.Attribute("time").Value);
            animation.Easing = xAnimation.Attribute("easing").Value;

            return animation;
        }
    }
}
