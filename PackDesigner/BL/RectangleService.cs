using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PackDesigner.ObjectModels;
using PackDesigner.Models;

namespace PackDesigner.BL
{
    public class RectangleService
    {

        public List<RectangleF> GetRectangles(float rootX, float rootY, Panel panel)
        {
            List<RectangleF> rectangles = new List<RectangleF>();
            float x = rootX - panel.PanelWidth / 2;
            float y = rootY - panel.PanelHeight;
            rectangles.Add(new RectangleF(x, y, panel.PanelWidth, panel.PanelHeight));
            foreach (Panel attachedPanel in panel.AttachedPanels)
            {
                AddRectangle(rectangles, x, y, Rotations.Top, panel.PanelWidth, panel.PanelHeight, attachedPanel);
            }
            return rectangles;
        }

        private void AddRectangle(
            List<RectangleF> rectangles,
            float parentX,
            float parentY,
            Rotations parentRotation,
            float parentWidth,
            float parentHeight,
            Panel current)
        {
            Rotations currentRotation = (Rotations)((current.AttachedToSide + (int)parentRotation + 2) % 4);

            float x = 0;
            float y = 0;
            float width = 0;
            float height = 0;

            switch (currentRotation)
            {
                case Rotations.Top:
                    x = parentX + ((parentWidth / 2) - (current.PanelWidth / 2) + current.HingeOffset);
                    y = parentY - current.PanelHeight;
                    width = current.PanelWidth;
                    height = current.PanelHeight;
                    break;
                case Rotations.Right:
                    x = parentX + parentWidth;
                    y = parentY + ((parentHeight / 2) - (current.PanelWidth / 2) + current.HingeOffset);
                    width = current.PanelHeight;
                    height = current.PanelWidth;
                    break;
                case Rotations.Bottom:
                    x = parentX + ((parentWidth / 2) - (current.PanelWidth / 2) - current.HingeOffset);
                    y = parentY + parentHeight;
                    width = current.PanelWidth;
                    height = current.PanelHeight;
                    break;
                case Rotations.Left:
                    x = parentX - current.PanelHeight;
                    y = parentY + ((parentHeight / 2) - (current.PanelWidth / 2) - current.HingeOffset);
                    width = current.PanelHeight;
                    height = current.PanelWidth;
                    break;
            }

            rectangles.Add(new RectangleF(x, y, width, height));

            if (current.AttachedPanels != null)
            {
                foreach (Panel attachedPanel in current.AttachedPanels)
                {
                    AddRectangle(rectangles, x, y, currentRotation, width, height, attachedPanel);
                }
            }

        }
    }
}
