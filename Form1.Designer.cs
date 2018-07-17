namespace smarthome
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.heater = new System.Windows.Forms.PictureBox();
            this.aircondition = new System.Windows.Forms.PictureBox();
            this.waveoven = new System.Windows.Forms.PictureBox();
            this.light = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.heater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aircondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveoven)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.light)).BeginInit();
            this.SuspendLayout();
            // 
            // heater
            // 
            this.heater.Location = new System.Drawing.Point(591, 93);
            this.heater.Name = "heater";
            this.heater.Size = new System.Drawing.Size(100, 50);
            this.heater.TabIndex = 5;
            this.heater.TabStop = false;
            // 
            // aircondition
            // 
            this.aircondition.Location = new System.Drawing.Point(459, 182);
            this.aircondition.Name = "aircondition";
            this.aircondition.Size = new System.Drawing.Size(100, 50);
            this.aircondition.TabIndex = 6;
            this.aircondition.TabStop = false;
            // 
            // waveoven
            // 
            this.waveoven.Location = new System.Drawing.Point(591, 182);
            this.waveoven.Name = "waveoven";
            this.waveoven.Size = new System.Drawing.Size(100, 50);
            this.waveoven.TabIndex = 7;
            this.waveoven.TabStop = false;
            // 
            // light
            // 
            this.light.Location = new System.Drawing.Point(459, 93);
            this.light.Name = "light";
            this.light.Size = new System.Drawing.Size(100, 50);
            this.light.TabIndex = 8;
            this.light.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 77);
            this.button1.TabIndex = 9;
            this.button1.Text = "start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 120);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(415, 255);
            this.textBox2.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.light);
            this.Controls.Add(this.waveoven);
            this.Controls.Add(this.aircondition);
            this.Controls.Add(this.heater);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.heater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aircondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveoven)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.light)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox heater;
        private System.Windows.Forms.PictureBox aircondition;
        private System.Windows.Forms.PictureBox waveoven;
        private System.Windows.Forms.PictureBox light;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

