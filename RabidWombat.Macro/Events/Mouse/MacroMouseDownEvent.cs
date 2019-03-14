﻿using System;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml;

namespace RabidWombat.Macro.Events.Mouse
{
    /// <summary>
    /// Represents a mouse button down event that occurs during recording.
    /// </summary>
    public class MacroMouseDownEvent : MacroMouseEvent
    {
        /// <summary>
        /// Gets or sets the mouse button associated with the event.
        /// </summary>
        public MouseButton Button { get; set; }

        /// <summary>
        /// Initializes a new instance of a macro mouse down event.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="button"></param>
        public MacroMouseDownEvent(Point location, MouseButton button) : base(location)
        {
            this.Button = button;
        }

        /// <summary>
        /// Initializes a new instance of a macro mouse down event.
        /// </summary>
        /// <param name="element">The serialized XML element to instialize from.</param>
        public MacroMouseDownEvent(XmlElement element) : base(new Point(0, 0))
        {
            foreach (XmlElement e in element)
            {
                switch (e.Name)
                {
                    case "Location":
                        Location = Point.Parse(e.InnerText);
                        break;
                    case "Button":
                        Button = (MouseButton)Enum.Parse(typeof(MouseButton), e.InnerText);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Serializes this object to an XML string for saving.
        /// </summary>
        /// <returns></returns>
        public override string ToXML()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<MacroMouseDownEvent>");
            sb.AppendLine("<Location>" + Location.ToString() + "</Location>");
            sb.AppendLine("<Button>" + Button.ToString() + "</Button>");
            sb.AppendLine("</MacroMouseDownEvent>");

            return sb.ToString();
        }
    }
}
