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
            this.buttonForward = new System.Windows.Forms.Button();
            this.buttonRotLeft = new System.Windows.Forms.Button();
            this.buttonRotRight = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonToStart = new System.Windows.Forms.Button();
            this.RenderTimer = new System.Windows.Forms.Timer(this.components);
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
            // RenderTimer
            // 
            this.RenderTimer.Tick += new System.EventHandler(this.RenderTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 857);
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
            this.ResumeLayout(false);

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
    }
}

