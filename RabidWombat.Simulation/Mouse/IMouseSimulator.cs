﻿using RabidWombat.Simulation.Keyboard;
using System;

namespace RabidWombat.Simulation.Mouse
{
    /// <summary>
    /// The service contract for a mouse simulator for the Windows platform.
    /// </summary>
    public interface IMouseSimulator
    {
        /// <summary>
        /// Gets the <see cref="IKeyboardSimulator"/> instance for simulating keyboard input.
        /// </summary>
        /// <value>The <see cref="IKeyboardSimulator"/> instance.</value>
        IKeyboardSimulator Keyboard { get; }

        /// <summary>
        /// Simulates mouse movement by the specified distance measured as delta from the current mouse location in pixels.
        /// </summary>
        /// <param name="pixelDeltaX">The distance in pixels to move the mouse horizontally.</param>
        /// <param name="pixelDeltaY">The distance in pixels to move the mouse vertically.</param>
        IMouseSimulator MoveMouseBy(int pixelDeltaX, int pixelDeltaY);

        /// <summary>
        /// Simulates mouse movement to the specified location on the primary display device.
        /// </summary>
        /// <param name="absoluteX">The destination's absolute X-coordinate on the primary display device where 0 is the extreme left hand side of the display device and 65535 is the extreme right hand side of the display device.</param>
        /// <param name="absoluteY">The destination's absolute Y-coordinate on the primary display device where 0 is the top of the display device and 65535 is the bottom of the display device.</param>
        IMouseSimulator MoveMouseTo(double absoluteX, double absoluteY);

        /// <summary>
        /// Simulates mouse movement to the specified location on the Virtual Desktop which includes all active displays.
        /// </summary>
        /// <param name="absoluteX">The destination's absolute X-coordinate on the virtual desktop where 0 is the left hand side of the virtual desktop and 65535 is the extreme right hand side of the virtual desktop.</param>
        /// <param name="absoluteY">The destination's absolute Y-coordinate on the virtual desktop where 0 is the top of the virtual desktop and 65535 is the bottom of the virtual desktop.</param>
        IMouseSimulator MoveMouseToPositionOnVirtualDesktop(double absoluteX, double absoluteY);

        /// <summary>
        /// Simulates a mouse left button down gesture.
        /// </summary>
        IMouseSimulator LeftButtonDown();

        /// <summary>
        /// Simulates a mouse left button up gesture.
        /// </summary>
        IMouseSimulator LeftButtonUp();

        /// <summary>
        /// Simulates a mouse left button click gesture.
        /// </summary>
        IMouseSimulator LeftButtonClick();

        /// <summary>
        /// Simulates a mouse left button double-click gesture.
        /// </summary>
        IMouseSimulator LeftButtonDoubleClick();

        /// <summary>
        /// Simulates a mouse right button down gesture.
        /// </summary>
        IMouseSimulator RightButtonDown();

        /// <summary>
        /// Simulates a mouse right button up gesture.
        /// </summary>
        IMouseSimulator RightButtonUp();

        /// <summary>
        /// Simulates a mouse right button click gesture.
        /// </summary>
        IMouseSimulator RightButtonClick();

        /// <summary>
        /// Simulates a mouse right button double-click gesture.
        /// </summary>
        IMouseSimulator RightButtonDoubleClick();

        /// <summary>
        /// Simulates a mouse X button down gesture.
        /// <param name="buttonId">The button id.</param>
        /// </summary>
        IMouseSimulator XButtonDown(int buttonId);

        /// <summary>
        /// Simulates a mouse X button up gesture.
        /// /// <param name="buttonId">The button id.</param>
        /// </summary>
        IMouseSimulator XButtonUp(int buttonId);

        /// <summary>
        /// Simulates a mouse X button click gesture.
        /// /// <param name="buttonId">The button id.</param>
        /// </summary>
        IMouseSimulator XButtonClick(int buttonId);

        /// <summary>
        /// Simulates a mouse X button double-click gesture.
        /// /// <param name="buttonId">The button id.</param>
        /// </summary>
        IMouseSimulator XButtonDoubleClick(int buttonId);

        /// <summary>
        /// Simulates a mouse vertical wheel scroll gesture.
        /// </summary>
        /// <param name="scrollAmountInClicks">The amount to scroll in clicks. A positive value indicates the wheel was rotated forward, away from the user; a negative value indicates the wheel was roated backward, towards the user.</param>
        IMouseSimulator VerticalScroll(int scrollAmountInClicks);

        /// <summary>
        /// Simulates a mouse horizontal wheel scroll gesture.
        /// </summary>
        /// <param name="scrollAmountInClicks">The amount to scroll in clicks. A positive value indicates the wheel was rotated to the right; a negative value indicates the wheel was roated to the left.</param>
        IMouseSimulator HorizontalScroll(int scrollAmountInClicks);

        /// <summary>
        /// Sleeps the executing thread to create a pause between simulated inputs.
        /// </summary>
        /// <param name="millisecondsTimeout">The number of milliseconds to wait.</param>
        IMouseSimulator Sleep(int millisecondsTimeout);

        /// <summary>
        /// Sleeps the executing thread to create a pause between simulated inputs.
        /// </summary>
        /// <param name="timeout">The time to wait.</param>
        IMouseSimulator Sleep(TimeSpan timeout);
    }
}
