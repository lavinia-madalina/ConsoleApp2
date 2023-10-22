using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace ConsoleApp2
{
    class SimpleWindow : GameWindow
    {
        private float objectX = 0.0f;
        private float objectY = 0.0f;

        public SimpleWindow() : base(800, 600)
        {
            KeyDown += Keyboard_KeyDown;
            MouseMove += Mouse_Move;
        }

        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Left)
                objectX -= 0.1f;
            else if (e.Key == Key.Right)
                objectX += 0.1f;
        }

        void Mouse_Move(object sender, MouseMoveEventArgs e)
        {
            objectX = (float)e.X / Width * 2.0f - 1.0f;
            objectY = 1.0f - (float)e.Y / Height * 2.0f;
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.MidnightBlue);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // Control obiect prin taste
            // Momentan aplicația nu face nimic în această secțiune!
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(objectX, objectY, -2.0);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-1.0f, 1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, -1.0f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();

            this.SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (SimpleWindow example = new SimpleWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
