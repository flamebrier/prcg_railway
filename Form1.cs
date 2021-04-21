using System;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Roshchina_Anastasia_pri117_railway
{
    public partial class Form1 : Form
    {
        private double[] camera = new double[7];

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

            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluPerspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 200);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            camera[0] = 0;
            camera[1] = 0;
            camera[2] = -10;
            camera[3] = 10;
            camera[4] = 1;
            camera[5] = 0;
            camera[6] = 0.1;

            Draw();
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {

        }

        // функция для отрисовки матрицы
        private void DrawGround()
        {
            Gl.glPushMatrix();

            Gl.glTranslated(0, 0, 0);
            Gl.glRotated(90, 1, 0, 0);
            Gl.glRotated(45, 0, 0, 1);

            Glut.glutSolidCylinder(300, 10, 4, 4);

            Gl.glEnd();

            Gl.glPopMatrix();
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

            Gl.glPopMatrix();
            Gl.glFlush();

            // обновляем окно
            AnT.Invalidate();
        }
    }
}
