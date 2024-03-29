﻿using MYDIPLOMA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MYDIPLOMA.Editor
{
   public class EditorScreen:Canvas
    {


        public EditorScreen()
        {
            this.MouseDown += canvas1_MouseDown;
            this.MouseMove += canvas1_MouseMove;
            this.MouseUp += canvas1_MouseUp;
            Background = Brushes.White;
            ClipToBounds = true;
            Width = 900;
            Height = Double.NaN;
            SnapsToDevicePixels = true;
        }



        private enum HitType
        {
            None, Body, UL, UR, LR, LL, L, R, T, B
        };

        // True if a drag is in progress.
        private bool DragInProgress = false;

        // The drag's last point.
        private Point LastPoint;

        // The part of the rectangle under the mouse.
        private HitType MouseHitType = HitType.None;

        // The Rectangle that was hit.
        private FrameworkElement HitController = null;

        public FrameworkElement SelectedControl;
        // The Rectangles that the user can move and resize.
 

        private HitType SetHitType(FrameworkElement rect, Point point)
        {
            double left = Canvas.GetLeft(rect);
            double top = Canvas.GetTop(rect);
            double right = left + rect.Width;
            double bottom = top + rect.Height;
            if (point.X < left) return HitType.None;
            if (point.X > right) return HitType.None;
            if (point.Y < top) return HitType.None;
            if (point.Y > bottom) return HitType.None;

            const double GAP = 10;
            if (point.X - left < GAP)
            {
                // Left edge.
                if (point.Y - top < GAP) return HitType.UL;
                if (bottom - point.Y < GAP) return HitType.LL;
                return HitType.L;
            }
            if (right - point.X < GAP)
            {
                // Right edge.
                if (point.Y - top < GAP) return HitType.UR;
                if (bottom - point.Y < GAP) return HitType.LR;
                return HitType.R;
            }
            if (point.Y - top < GAP) return HitType.T;
            if (bottom - point.Y < GAP) return HitType.B;
            return HitType.Body;
        }

        private void SetMouseCursor()
        {
            // See what cursor we should display.
            Cursor desired_cursor = Cursors.Arrow;
            switch (MouseHitType)
            {
                case HitType.None:
                    desired_cursor = Cursors.Arrow;
                    break;
                case HitType.Body:
                    desired_cursor = Cursors.ScrollAll;
                    break;
                case HitType.UL:
                case HitType.LR:
                    desired_cursor = Cursors.SizeNWSE;
                    break;
                case HitType.LL:
                case HitType.UR:
                    desired_cursor = Cursors.SizeNESW;
                    break;
                case HitType.T:
                case HitType.B:
                    desired_cursor = Cursors.SizeNS;
                    break;
                case HitType.L:
                case HitType.R:
                    desired_cursor = Cursors.SizeWE;
                    break;
            }

            // Display the desired cursor.
            if (Cursor != desired_cursor) Cursor = desired_cursor;
        }
        private void canvas1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FindHit(Mouse.GetPosition(this));
            SetMouseCursor();

            if (MouseHitType == HitType.None) return;

            SelectedControl = HitController;
            ClearSelection();
            ((ControlInterface)HitController).setSelection();
            LastPoint = Mouse.GetPosition(this);
            DragInProgress = true;
        }

        // If a drag is in progress, continue the drag.
        // Otherwise display the correct cursor.
        private void canvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!DragInProgress)
            {
                FindHit(Mouse.GetPosition(this));
                SetMouseCursor();
            }
            else
            {
                // See how much the mouse has moved.
                Point point = Mouse.GetPosition(this);
                double offset_x = point.X - LastPoint.X;
                double offset_y = point.Y - LastPoint.Y;

                // Get the rectangle's current position.
                double new_x = Canvas.GetLeft(HitController);
                double new_y = Canvas.GetTop(HitController);
                double new_width = HitController.Width;
                double new_height = HitController.Height;

                // Update the rectangle.
                switch (MouseHitType)
                {
                    case HitType.Body:
                        new_x += offset_x;
                        new_y += offset_y;
                        break;
                    case HitType.UL:
                        new_x += offset_x;
                        new_y += offset_y;
                        new_width -= offset_x;
                        new_height -= offset_y;
                        break;
                    case HitType.UR:
                        new_y += offset_y;
                        new_width += offset_x;
                        new_height -= offset_y;
                        break;
                    case HitType.LR:
                        new_width += offset_x;
                        new_height += offset_y;
                        break;
                    case HitType.LL:
                        new_x += offset_x;
                        new_width -= offset_x;
                        new_height += offset_y;
                        break;
                    case HitType.L:
                        new_x += offset_x;
                        new_width -= offset_x;
                        break;
                    case HitType.R:
                        new_width += offset_x;
                        break;
                    case HitType.B:
                        new_height += offset_y;
                        break;
                    case HitType.T:
                        new_y += offset_y;
                        new_height -= offset_y;
                        break;
                }

                // Don't use negative width or height.
                if ((new_width > 0) && (new_height > 0))
                {
                    // Update the rectangle.
                    Canvas.SetLeft(HitController, new_x);
                    Canvas.SetTop(HitController, new_y);
                    HitController.Width = new_width;
                    HitController.Height = new_height;

                    // Save the mouse's new location.
                    LastPoint = point;
                }
            }
        }

        // Stop dragging.
        private void canvas1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DragInProgress = false;
        }

        private void FindHit(Point point)
        {
            HitController = null;
            MouseHitType = HitType.None;

            foreach (FrameworkElement rect in this.Children)
            {
                MouseHitType = SetHitType(rect, point);
                if (MouseHitType != HitType.None)
                {
                   
                    HitController = rect;
                   
                    
                    return;
                }
            }

            // We didn't find a hit.
            return;
        }

        public void AddController(FrameworkElement f)
        {
            Children.Add(f);
        }

        public void ClearSelection()
        {


            foreach (UserControl item in Children)
            {
                if (item != HitController)
                {
                    item.BorderThickness = new Thickness(0);
                    item.BorderBrush = Brushes.Transparent;
                }
            }

        }

    }
}
