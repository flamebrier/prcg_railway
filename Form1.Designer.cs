using Tao.Platform.Windows;

namespace Roshchina_Anastasia_pri117_railway
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.RenderTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.buttonToStart = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonRotRight = new System.Windows.Forms.Button();
            this.buttonRotLeft = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lever = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.BackColor = System.Drawing.Color.Black;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.Location = new System.Drawing.Point(-3, -3);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(1212, 864);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 0;
            // 
            // RenderTimer
            // 
            this.RenderTimer.Tick += new System.EventHandler(this.RenderTimer_Tick);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonZoomIn.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.buttonZoomIn.FlatAppearance.BorderSize = 3;
            this.buttonZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZoomIn.Image = global::Roshchina_Anastasia_pri117_railway.Properties.Resources.round_zoom_in_black_24dp;
            this.buttonZoomIn.Location = new System.Drawing.Point(967, 805);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(40, 40);
            this.buttonZoomIn.TabIndex = 9;
            this.buttonZoomIn.UseVisualStyleBackColor = false;
            this.buttonZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZoomIn_MouseDown);
            this.buttonZoomIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonZoomIn_MouseUp);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonZoomOut.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.buttonZoomOut.FlatAppearance.BorderSize = 3;
            this.buttonZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZoomOut.Image = global::Roshchina_Anastasia_pri117_railway.Properties.Resources.round_zoom_out_black_24dp;
            this.buttonZoomOut.Location = new System.Drawing.Point(1117, 805);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(40, 40);
            this.buttonZoomOut.TabIndex = 8;
            this.buttonZoomOut.UseVisualStyleBackColor = false;
            this.buttonZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZoomOut_MouseDown);
            this.buttonZoomOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonZoomOut_MouseUp);
            // 
            // buttonToStart
            // 
            this.buttonToStart.BackColor = System.Drawing.Color.DarkSalmon;
            this.buttonToStart.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.buttonToStart.FlatAppearance.BorderSize = 3;
            this.buttonToStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToStart.Image = global::Roshchina_Anastasia_pri117_railway.Properties.Resources.round_outlined_flag_black_24dp;
            this.buttonToStart.Location = new System.Drawing.Point(1042, 716);
            this.buttonToStart.Name = "buttonToStart";
            this.buttonToStart.Size = new System.Drawing.Size(40, 40);
            this.buttonToStart.TabIndex = 7;
            this.buttonToStart.UseVisualStyleBackColor = false;
            this.buttonToStart.Click += new System.EventHandler(this.buttonToStart_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRight.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.buttonRight.FlatAppearance.BorderSize = 3;
            this.buttonRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRight.Image = global::Roshchina_Anastasia_pri117_railway.Properties.Resources.round_arrow_forward_black_24dp;
            this.buttonRight.Location = new System.Drawing.Point(1088, 716);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(40, 40);
            this.buttonRight.TabIndex = 6;
            this.buttonRight.UseVisualStyleBackColor = false;
            this.buttonRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRight_MouseDown);
            this.buttonRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRight_MouseUp);
            // 
            // buttonLeft
            // 
            this.buttonLeft.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonLeft.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.buttonLeft.FlatAppearance.BorderSize = 3;
            this.buttonLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLeft.Image = global::Roshchina_Anastasia_pri117_railway.Properties.Resources.round_arrow_back_black_24dp;
            this.buttonLeft.Location = new System.Drawing.Point(996, 716);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(40, 40);
            this.buttonLeft.TabIndex = 5;
            this.buttonLeft.UseVisualStyleBackColor = false;
            this.buttonLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonLeft_MouseDown);
            this.buttonLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonLeft_MouseUp);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.buttonBack.FlatAppearance.BorderSize = 3;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Image = global::Roshchina_Anastasia_pri117_railway.Properties.Resources.round_arrow_downward_black_24dp;
            this.buttonBack.Location = new System.Drawing.Point(1042, 762);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(40, 40);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonBack_MouseDown);
            this.buttonBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonBack_MouseUp);
            // 
            // buttonRotRight
            // 
            this.buttonRotRight.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRotRight.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.buttonRotRight.FlatAppearance.BorderSize = 3;
            this.buttonRotRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRotRight.Image = global::Roshchina_Anastasia_pri117_railway.Properties.Resources.round_redo_black_24dp;
            this.buttonRotRight.Location = new System.Drawing.Point(1117, 635);
            this.buttonRotRight.Name = "buttonRotRight";
            this.buttonRotRight.Size = new System.Drawing.Size(40, 40);
            this.buttonRotRight.TabIndex = 3;
            this.buttonRotRight.UseVisualStyleBackColor = false;
            this.buttonRotRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRotRight_MouseDown);
            this.buttonRotRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRotRight_MouseUp);
            // 
            // buttonRotLeft
            // 
            this.buttonRotLeft.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRotLeft.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.buttonRotLeft.FlatAppearance.BorderSize = 3;
            this.buttonRotLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRotLeft.Image = global::Roshchina_Anastasia_pri117_railway.Properties.Resources.round_undo_black_24dp;
            this.buttonRotLeft.Location = new System.Drawing.Point(967, 635);
            this.buttonRotLeft.Name = "buttonRotLeft";
            this.buttonRotLeft.Size = new System.Drawing.Size(40, 40);
            this.buttonRotLeft.TabIndex = 2;
            this.buttonRotLeft.UseVisualStyleBackColor = false;
            this.buttonRotLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRotLeft_MouseDown);
            this.buttonRotLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRotLeft_MouseUp);
            // 
            // buttonForward
            // 
            this.buttonForward.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonForward.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.buttonForward.FlatAppearance.BorderSize = 3;
            this.buttonForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForward.Image = global::Roshchina_Anastasia_pri117_railway.Properties.Resources.round_arrow_upward_black_24dp;
            this.buttonForward.Location = new System.Drawing.Point(1042, 670);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(40, 40);
            this.buttonForward.TabIndex = 1;
            this.buttonForward.UseVisualStyleBackColor = false;
            this.buttonForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonForward_MouseDown);
            this.buttonForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonForward_MouseUp);
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.trackBarZoom.Location = new System.Drawing.Point(803, 805);
            this.trackBarZoom.Maximum = 20;
            this.trackBarZoom.Minimum = 1;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(132, 45);
            this.trackBarZoom.TabIndex = 10;
            this.trackBarZoom.Value = 1;
            this.trackBarZoom.Scroll += new System.EventHandler(this.trackBarZoom_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(803, 840);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Скорость передвижения";
            // 
            // lever
            // 
            this.lever.Location = new System.Drawing.Point(836, 762);
            this.lever.Name = "lever";
            this.lever.Size = new System.Drawing.Size(75, 23);
            this.lever.TabIndex = 12;
            this.lever.Text = "Рычаг";
            this.lever.UseVisualStyleBackColor = true;
            this.lever.Click += new System.EventHandler(this.lever_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 857);
            this.Controls.Add(this.lever);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarZoom);
            this.Controls.Add(this.buttonZoomIn);
            this.Controls.Add(this.buttonZoomOut);
            this.Controls.Add(this.buttonToStart);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonRotRight);
            this.Controls.Add(this.buttonRotLeft);
            this.Controls.Add(this.buttonForward);
            this.Controls.Add(this.AnT);
            this.Name = "Form1";
            this.Text = "Железная дорога (Рощина А.И.)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SimpleOpenGlControl AnT;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.Button buttonRotLeft;
        private System.Windows.Forms.Button buttonRotRight;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonToStart;
        private System.Windows.Forms.Timer RenderTimer;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.TrackBar trackBarZoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button lever;
    }
}

