namespace CmdBash
{
	partial class Install
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Install));
			this.InstallCheckBox = new System.Windows.Forms.CheckBox();
			this.Logger = new System.Windows.Forms.Label();
			this.myPath = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// InstallCheckBox
			// 
			this.InstallCheckBox.AutoSize = true;
			this.InstallCheckBox.Location = new System.Drawing.Point(134, 61);
			this.InstallCheckBox.Name = "InstallCheckBox";
			this.InstallCheckBox.Size = new System.Drawing.Size(86, 17);
			this.InstallCheckBox.TabIndex = 0;
			this.InstallCheckBox.Text = "Установить";
			this.InstallCheckBox.UseVisualStyleBackColor = false;
			this.InstallCheckBox.CheckedChanged += new System.EventHandler(this.Install_checkBox);
			// 
			// Logger
			// 
			this.Logger.AutoSize = true;
			this.Logger.Location = new System.Drawing.Point(134, 85);
			this.Logger.Name = "Logger";
			this.Logger.Size = new System.Drawing.Size(0, 13);
			this.Logger.TabIndex = 2;
			// 
			// myPath
			// 
			this.myPath.Location = new System.Drawing.Point(15, 30);
			this.myPath.Name = "myPath";
			this.myPath.ReadOnly = true;
			this.myPath.Size = new System.Drawing.Size(344, 20);
			this.myPath.TabIndex = 0;
			this.myPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Install
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(371, 141);
			this.Controls.Add(this.myPath);
			this.Controls.Add(this.Logger);
			this.Controls.Add(this.InstallCheckBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Install";
			this.Text = "Install";
			this.Load += new System.EventHandler(this.Install_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox InstallCheckBox;
		private System.Windows.Forms.Label Logger;
		private System.Windows.Forms.TextBox myPath;
	}
}

