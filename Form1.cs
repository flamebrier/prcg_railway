﻿using Roshchina_Anastasia_pri117_railway.Roshchina_Anastasia_pri117_lab15;
using System;
using System.Windows.Forms;
using Tao.DevIl;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Roshchina_Anastasia_pri117_railway
{
    public partial class Form1 : Form
    {
        public delegate double MovingCamera();

        public static double[] camera = new double[7];

        private double[] initialCamera = {
            0,-10,-10,30,1,0,0.1
        };

        private TexturesForObjects textureLoader;
        private anModelLoader model;

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация OpenGL
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Il.ilInit();
            Ilut.ilutInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluPerspective(45, AnT.Width / AnT.Height, 0.2, 200);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            camera = initialCamera;

            textureLoader = new TexturesForObjects();
            model = new anModelLoader();

            Draw();

            model.LoadModel("bench.ase");
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        // функция для отрисовки поверхности
        private void DrawGround()
        {
            Gl.glPushMatrix();

            Gl.glTranslated(0, 0, 0);
            Gl.glRotated(90, 1, 0, 0);
            Gl.glRotated(45, 0, 0, 1);

            //Gl.glBindTexture(Gl.GL_TEXTURE_2D, grassTexture);

            // включаем режим текстурирования
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glEnable(Gl.GL_NORMALIZE);

            textureLoader.LoadTextureForModel("grass.jpg");
            uint grassTexture = textureLoader.GetTextureObj();


            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, grassTexture);

            // отрисовываем полигон 
            Gl.glBegin(Gl.GL_QUADS);
            // указываем поочередно вершины и текстурные координаты 
            int quad_size = 50;

            int y = -250;
            for (int i = 0; i < 50; i++)
            {
                int x = -250;
                for (int j = 0; j < 50; j++)
                {
                    Gl.glVertex3d(x - quad_size + j * quad_size, y - quad_size, 0);
                    Gl.glTexCoord2f(0, 0);
                    Gl.glVertex3d(x - quad_size + j * quad_size, y + quad_size, 0);
                    Gl.glTexCoord2f(1, 0);
                    Gl.glVertex3d(x + quad_size + j * quad_size, y + quad_size, 0);
                    Gl.glTexCoord2f(1, 1);
                    Gl.glVertex3d(x + quad_size + j * quad_size, y - quad_size, 0);
                    Gl.glTexCoord2f(0, 1);
                    x += quad_size;
                }

                y += quad_size;
            }

            // завершаем отрисовку 
            Gl.glEnd();

            //Glut.glutSolidCylinder(30, 10, 4, 4);

            Gl.glPopMatrix();
            // отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glDisable(Gl.GL_NORMALIZE);
        }

        private void DrawBench()
        {
            if (model != null)
                model.DrawModel();
        }

        private void Draw()
        {
            Gl.glClearColor(0, 0, 0, 1);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();

            Gl.glPushMatrix();

            // используем параметры для установленной камеры
            Gl.glTranslated(camera[0], camera[1], camera[2]);
            Gl.glScaled(camera[6], camera[6], camera[6]);
            Gl.glRotated(camera[3], 1, 0, 0);
            Gl.glRotated(camera[4], 0, 1, 0);
            Gl.glRotated(camera[5], 0, 0, 1);

            DrawGround();
            DrawBench();

            Gl.glPopMatrix();
            Gl.glFlush();

            // обновляем окно
            AnT.Invalidate();
        }

        EventHandler MovingForwardHandler = new EventHandler(MovingForward);
        EventHandler MovingBackHandler = new EventHandler(MovingBack);
        EventHandler MovingRightHandler = new EventHandler(MovingRight);
        EventHandler MovingLeftHandler = new EventHandler(MovingLeft);
        EventHandler RotateRightHandler = new EventHandler(RotateRight);
        EventHandler RotateLeftHandler = new EventHandler(RotateLeft);

        private static void MovingForward(object sender, EventArgs e)
        {
            if (camera[2] < -1)
            {
                camera[2]++;
            }
        }

        private static void MovingBack(object sender, EventArgs e)
        {
            camera[2]--;
        }

        private static void MovingLeft(object sender, EventArgs e)
        {
            camera[0]++;
        }

        private static void MovingRight(object sender, EventArgs e)
        {
            camera[0]--;
        }

        private static void RotateRight(object sender, EventArgs e)
        {
            camera[4]++;
        }

        private static void RotateLeft(object sender, EventArgs e)
        {
            camera[4]--;
        }

        private void buttonForward_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += MovingForwardHandler;
            RenderTimer.Start();
        }

        private void buttonForward_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= MovingForwardHandler;
            RenderTimer.Stop();
        }

        private void buttonBack_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += MovingBackHandler;
            RenderTimer.Start();
        }

        private void buttonBack_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= MovingBackHandler;
            RenderTimer.Stop();
        }

        private void buttonLeft_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += MovingLeftHandler;
            RenderTimer.Start();
        }

        private void buttonLeft_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= MovingLeftHandler;
            RenderTimer.Stop();
        }

        private void buttonRight_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += MovingRightHandler;
            RenderTimer.Start();
        }

        private void buttonRight_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= MovingRightHandler;
            RenderTimer.Stop();
        }

        private void buttonRotRight_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += RotateRightHandler;
            RenderTimer.Start();
        }

        private void buttonRotRight_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= RotateRightHandler;
            RenderTimer.Stop();
        }

        private void buttonRotLeft_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += RotateLeftHandler;
            RenderTimer.Start();
        }

        private void buttonRotLeft_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= RotateLeftHandler;
            RenderTimer.Stop();
        }

        private void buttonToStart_Click(object sender, EventArgs e)
        {
            camera = initialCamera;
            Draw();
        }
    }
}
