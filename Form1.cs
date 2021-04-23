using Roshchina_Anastasia_pri117_railway.Roshchina_Anastasia_pri117_lab15;
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

        private int fieldSize = 500;

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textureLoader = new TexturesForObjects();
            model = new anModelLoader();

            // инициализация OpenGL
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Il.ilInit();
            Ilut.ilutInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            Gl.glClearColor(255, 255, 255, 1);

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

            // включаем режим текстурирования
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glEnable(Gl.GL_NORMALIZE);

            textureLoader.LoadTextureForModel("grass.jpg");
            uint grassTexture = textureLoader.GetTextureObj();

            Gl.glActiveTexture(Gl.GL_TEXTURE0);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, grassTexture);

            // отрисовываем полигон 
            Gl.glBegin(Gl.GL_QUADS);
            // указываем поочередно вершины и текстурные координаты 
            int count = 25;
            int quad_size = fieldSize / count;

            int y = -fieldSize / 2;
            for (int i = 0; i < count; i++)
            {
                int x = -fieldSize / 2;
                for (int j = 0; j < count; j++)
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


        

        private void DrawLever()
        {
            int leverHeight = 70;
            textureLoader.LoadTextureForModel("metal.jpg");
            uint metalTexture = textureLoader.GetTextureObj();

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glEnable(Gl.GL_TEXTURE_GEN_S);
            Gl.glEnable(Gl.GL_TEXTURE_GEN_T);
            Gl.glTexGeni(Gl.GL_S, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_SPHERE_MAP);
            Gl.glTexGeni(Gl.GL_T, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_SPHERE_MAP);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, metalTexture);

            Gl.glPushMatrix();
            Gl.glRotated(90, 1, 0, 0);
            Gl.glTranslated(0, 0, -leverHeight);
            Glut.glutSolidCylinder(1, leverHeight, 16, 16);

            // отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glDisable(Gl.GL_TEXTURE_GEN_S);
            Gl.glDisable(Gl.GL_TEXTURE_GEN_T);
            Gl.glDisable(Gl.GL_TEXTURE_2D);

            Gl.glColor3d(1, 0.01, 0.01);
            Glut.glutSolidSphere(2, 16, 16);
            Gl.glPopMatrix();

           
        }


        private void DrawRail()
        {
            textureLoader.LoadTextureForModel("metal.jpg");
            uint metalTexture = textureLoader.GetTextureObj();
            textureLoader.LoadTextureForModel("wood.jpg");
            uint woodTexture = textureLoader.GetTextureObj();

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glEnable(Gl.GL_TEXTURE_GEN_S);
            Gl.glEnable(Gl.GL_TEXTURE_GEN_T);
            Gl.glTexGeni(Gl.GL_S, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_SPHERE_MAP);
            Gl.glTexGeni(Gl.GL_T, Gl.GL_TEXTURE_GEN_MODE, Gl.GL_SPHERE_MAP);


            Gl.glPushMatrix();
            Gl.glRotated(90, 1, 0, 0);
            //Gl.glRotated(45, 0, 0, 1);

            int[,] segmentsRot =
            {
                { 0, 0, 0 },{0, 0, 0 },{0 , 0, 0},{0, 0, 0 },{0, 0, 0 },{10, 0, 0 },{30, 0, -15 }
            };

            int railSize = 3;
            int segmentsCount = segmentsRot.Length / 3;
            int segmentLength = fieldSize / segmentsCount;


            int x = -fieldSize / 2;
            int currentRotation = 0;
            double width = segmentLength / 2;

           int step = segmentLength / 4;
            for (int i = 0; i < segmentsCount; i++)
            {
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, metalTexture);
                Gl.glPushMatrix();
                Gl.glTranslated(x + i * segmentLength, 0, 0);
                Gl.glRotated(90, 0, 1, 0);
                if (i == 0)
                {
                    Gl.glRotated(-30, 1, 0, 0);
                    Gl.glTranslated(0, 2, width - 4);
                }

                Gl.glPushMatrix();
                Gl.glTranslated(0,  0, -railSize * 2);
                Glut.glutSolidCylinder(railSize, segmentLength, 16, 16);
                Gl.glPushMatrix();
                Gl.glTranslated(0, -width, 0);
                Glut.glutSolidCylinder(railSize, segmentLength, 16, 16);
                Gl.glPopMatrix();
                Gl.glPopMatrix();


                Gl.glPushMatrix();
                Gl.glTranslated(0, 0, -railSize);
                Glut.glutSolidCylinder(railSize * 0.8, segmentLength, 16, 16);
                Gl.glPushMatrix();
                Gl.glTranslated(0, -width, 0);
                Glut.glutSolidCylinder(railSize * 0.8, segmentLength, 16, 16);
                Gl.glPopMatrix();
                Gl.glPopMatrix();


                Gl.glBindTexture(Gl.GL_TEXTURE_2D, woodTexture);

                Gl.glPushMatrix();
                Gl.glRotated(90, 1, 0, 0);
                Gl.glTranslated(0, 5, 0);
                
                for (int j = 0; j < segmentLength - step; j += step)
                {
                    Gl.glTranslated(0, step, 0);
                    Gl.glPushMatrix();
                    Gl.glRotated(45, 0, 0, 1);
                    Glut.glutSolidCylinder(railSize, width, 4, 4);
                    Gl.glPopMatrix();
                }

                Gl.glPopMatrix();
                Gl.glPopMatrix();

                currentRotation += segmentsRot[i, 0];
            }

            Gl.glPopMatrix();

            // отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glDisable(Gl.GL_TEXTURE_GEN_S);
            Gl.glDisable(Gl.GL_TEXTURE_GEN_T);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }

        private void Draw()
        {

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
            DrawRail();
            Gl.glPushMatrix();
            Gl.glRotated(leverRotation, 0, 0, 1);
            DrawLever();
            Gl.glPopMatrix();


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
        EventHandler ZoomInHandler = new EventHandler(ZoomIn);
        EventHandler ZoomOutHandler = new EventHandler(ZoomOut);
        EventHandler LeverHandler = new EventHandler(MovingLever);

        static double scaleSpeed = 2;
        static int leverRotation = 0;
        private static void MovingLever(object sender, EventArgs e)
        {
            if (leverRotation < 30)
            {
                leverRotation++;
            } else
            {
            }
        }

        private static void MovingForward(object sender, EventArgs e)
        {
            if (camera[2] < -1)
            {
                camera[2] += scaleSpeed;
            }
        }

        private static void MovingBack(object sender, EventArgs e)
        {
            camera[2] -= scaleSpeed;
        }

        private static void MovingLeft(object sender, EventArgs e)
        {
            camera[0] += scaleSpeed;
        }

        private static void MovingRight(object sender, EventArgs e)
        {
            camera[0] -= scaleSpeed;
        }

        private static void RotateRight(object sender, EventArgs e)
        {
            camera[4] += scaleSpeed;
        }

        private static void RotateLeft(object sender, EventArgs e)
        {
            camera[4] -= scaleSpeed;
        }

        private static void ZoomIn(object sender, EventArgs e)
        {
            if (camera[6] < 5)
            {
                camera[6] += scaleSpeed / 10;
            }
        }

        private static void ZoomOut(object sender, EventArgs e)
        {
            if (camera[6] > 0.1)
            {
                camera[6] -= scaleSpeed / 100;
            }
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

        private void buttonZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += ZoomInHandler;
            RenderTimer.Start();
        }

        private void buttonZoomIn_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= ZoomInHandler;
            RenderTimer.Stop();
        }

        private void buttonZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += ZoomOutHandler;
            RenderTimer.Start();
        }

        private void buttonZoomOut_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= ZoomOutHandler;
            RenderTimer.Stop();
        }

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            scaleSpeed = trackBarZoom.Value;
        }

        private void lever_Click(object sender, EventArgs e)
        {
            RenderTimer.Tick += LeverHandler;
            RenderTimer.Start();
            if (leverRotation == 30)
            {
                RenderTimer.Stop();
            }
        }
    }
}
