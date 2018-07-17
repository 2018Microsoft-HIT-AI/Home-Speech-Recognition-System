namespace HSRS_demo
{
    partial class SmartHomeForm
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
            this.Heater = new System.Windows.Forms.PictureBox();
            this.Aircondition = new System.Windows.Forms.PictureBox();
            this.Waveoven = new System.Windows.Forms.PictureBox();
            this.Light = new System.Windows.Forms.PictureBox();
            this.Button = new System.Windows.Forms.Button();
            this.textbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Heater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aircondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Waveoven)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Light)).BeginInit();
            this.SuspendLayout();
            // 
            // Heater
            // 
            this.Heater.Location = new System.Drawing.Point(10, 10);
            this.Heater.Name = "Heater";
            this.Heater.Size = new System.Drawing.Size(400, 300);
            this.Heater.TabIndex = 5;
            this.Heater.TabStop = false;
            // 
            // Aircondition
            // 
            this.Aircondition.Location = new System.Drawing.Point(10, 320);
            this.Aircondition.Name = "Aircondition";
            this.Aircondition.Size = new System.Drawing.Size(400, 300);
            this.Aircondition.TabIndex = 6;
            this.Aircondition.TabStop = false;
            // 
            // Waveoven
            // 
            this.Waveoven.Location = new System.Drawing.Point(420, 10);
            this.Waveoven.Name = "Waveoven";
            this.Waveoven.Size = new System.Drawing.Size(400, 300);
            this.Waveoven.TabIndex = 7;
            this.Waveoven.TabStop = false;
            // 
            // Light
            // 
            this.Light.Location = new System.Drawing.Point(420, 320);
            this.Light.Name = "Light";
            this.Light.Size = new System.Drawing.Size(400, 300);
            this.Light.TabIndex = 8;
            this.Light.TabStop = false;
            // 
            // Button
            // 
            this.Button.Location = new System.Drawing.Point(830, 520);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(200, 100);
            this.Button.TabIndex = 9;
            this.Button.Text = "start";
            this.Button.UseVisualStyleBackColor = true;
            this.Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // textbox
            // 
            this.textbox.Location = new System.Drawing.Point(830, 10);
            this.textbox.Multiline = true;
            this.textbox.Name = "textbox";
            this.textbox.ReadOnly = true;
            this.textbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textbox.Size = new System.Drawing.Size(200, 500);
            this.textbox.TabIndex = 10;
            // 
            // SmartHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 630);
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.Button);
            this.Controls.Add(this.Light);
            this.Controls.Add(this.Waveoven);
            this.Controls.Add(this.Aircondition);
            this.Controls.Add(this.Heater);
            this.Name = "SmartHomeForm";
            this.Text = "SmartHome";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Heater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aircondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Waveoven)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Light)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Heater;
        private System.Windows.Forms.PictureBox Aircondition;
        private System.Windows.Forms.PictureBox Waveoven;
        private System.Windows.Forms.PictureBox Light;
        private System.Windows.Forms.Button Button;
        private System.Windows.Forms.TextBox textbox;
    }
}

