namespace Klet
{
    partial class MainWindow
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
            this.panelCell = new System.Windows.Forms.Panel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.timerProcess = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panelCell
            // 
            this.panelCell.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelCell.Location = new System.Drawing.Point(123, 30);
            this.panelCell.Name = "panelCell";
            this.panelCell.Size = new System.Drawing.Size(200, 200);
            this.panelCell.TabIndex = 0;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(337, 260);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(195, 260);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "Next step";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(53, 260);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // timerProcess
            // 
            this.timerProcess.Enabled = true;
            this.timerProcess.Tick += new System.EventHandler(this.TimerProcess_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 318);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.panelCell);
            this.Name = "MainWindow";
            this.Text = "Клеточный автомат";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCell;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Timer timerProcess;
    }
}

