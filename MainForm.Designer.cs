namespace ETitcombe.EpubCreator
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this._outputFileNameTextBox = new System.Windows.Forms.TextBox();
			this._createButton = new System.Windows.Forms.Button();
			this._sourceFolderTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this._browseButton = new System.Windows.Forms.Button();
			this._groupBox = new System.Windows.Forms.GroupBox();
			this._titleTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this._sourceTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this._rightsTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this._languageTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this._creatorTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this._groupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Output file name:";
			// 
			// _outputFileNameTextBox
			// 
			this._outputFileNameTextBox.Location = new System.Drawing.Point(15, 25);
			this._outputFileNameTextBox.Name = "_outputFileNameTextBox";
			this._outputFileNameTextBox.Size = new System.Drawing.Size(198, 20);
			this._outputFileNameTextBox.TabIndex = 1;
			// 
			// _createButton
			// 
			this._createButton.Location = new System.Drawing.Point(423, 319);
			this._createButton.Name = "_createButton";
			this._createButton.Size = new System.Drawing.Size(75, 23);
			this._createButton.TabIndex = 6;
			this._createButton.Text = "&Create";
			this._createButton.UseVisualStyleBackColor = true;
			this._createButton.Click += new System.EventHandler(this.CreateButton_Click);
			// 
			// _sourceFolderTextBox
			// 
			this._sourceFolderTextBox.Location = new System.Drawing.Point(15, 64);
			this._sourceFolderTextBox.Name = "_sourceFolderTextBox";
			this._sourceFolderTextBox.Size = new System.Drawing.Size(402, 20);
			this._sourceFolderTextBox.TabIndex = 3;
			this._sourceFolderTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.SourceFolderTextBox_Validating);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Source folder:";
			// 
			// _browseButton
			// 
			this._browseButton.Location = new System.Drawing.Point(423, 64);
			this._browseButton.Name = "_browseButton";
			this._browseButton.Size = new System.Drawing.Size(75, 23);
			this._browseButton.TabIndex = 4;
			this._browseButton.Text = "&Browse...";
			this._browseButton.UseVisualStyleBackColor = true;
			this._browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
			// 
			// _groupBox
			// 
			this._groupBox.Controls.Add(this._titleTextBox);
			this._groupBox.Controls.Add(this.label7);
			this._groupBox.Controls.Add(this._sourceTextBox);
			this._groupBox.Controls.Add(this.label6);
			this._groupBox.Controls.Add(this._rightsTextBox);
			this._groupBox.Controls.Add(this.label5);
			this._groupBox.Controls.Add(this._languageTextBox);
			this._groupBox.Controls.Add(this.label4);
			this._groupBox.Controls.Add(this._creatorTextBox);
			this._groupBox.Controls.Add(this.label3);
			this._groupBox.Location = new System.Drawing.Point(15, 90);
			this._groupBox.Name = "_groupBox";
			this._groupBox.Size = new System.Drawing.Size(483, 223);
			this._groupBox.TabIndex = 5;
			this._groupBox.TabStop = false;
			this._groupBox.Text = "Properties";
			// 
			// _titleTextBox
			// 
			this._titleTextBox.Location = new System.Drawing.Point(9, 188);
			this._titleTextBox.Name = "_titleTextBox";
			this._titleTextBox.Size = new System.Drawing.Size(361, 20);
			this._titleTextBox.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 172);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(30, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Title:";
			// 
			// _sourceTextBox
			// 
			this._sourceTextBox.Location = new System.Drawing.Point(9, 149);
			this._sourceTextBox.Name = "_sourceTextBox";
			this._sourceTextBox.Size = new System.Drawing.Size(361, 20);
			this._sourceTextBox.TabIndex = 7;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 133);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Source:";
			// 
			// _rightsTextBox
			// 
			this._rightsTextBox.Location = new System.Drawing.Point(9, 110);
			this._rightsTextBox.Name = "_rightsTextBox";
			this._rightsTextBox.Size = new System.Drawing.Size(361, 20);
			this._rightsTextBox.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 94);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Rights:";
			// 
			// _languageTextBox
			// 
			this._languageTextBox.Location = new System.Drawing.Point(9, 71);
			this._languageTextBox.Name = "_languageTextBox";
			this._languageTextBox.Size = new System.Drawing.Size(198, 20);
			this._languageTextBox.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 55);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Language:";
			// 
			// _creatorTextBox
			// 
			this._creatorTextBox.Location = new System.Drawing.Point(9, 32);
			this._creatorTextBox.Name = "_creatorTextBox";
			this._creatorTextBox.Size = new System.Drawing.Size(198, 20);
			this._creatorTextBox.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Creator:";
			// 
			// _errorProvider
			// 
			this._errorProvider.ContainerControl = this;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.ClientSize = new System.Drawing.Size(516, 358);
			this.Controls.Add(this._groupBox);
			this.Controls.Add(this._browseButton);
			this.Controls.Add(this._sourceFolderTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._createButton);
			this.Controls.Add(this._outputFileNameTextBox);
			this.Controls.Add(this.label1);
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
			this._groupBox.ResumeLayout(false);
			this._groupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _outputFileNameTextBox;
		private System.Windows.Forms.Button _createButton;
		private System.Windows.Forms.TextBox _sourceFolderTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button _browseButton;
		private System.Windows.Forms.GroupBox _groupBox;
		private System.Windows.Forms.TextBox _sourceTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox _rightsTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox _languageTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox _creatorTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox _titleTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ErrorProvider _errorProvider;
	}
}