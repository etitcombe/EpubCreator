using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ETitcombe.EpubCreator
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			this.Font = SystemFonts.IconTitleFont;

			_outputFileNameTextBox.Text = "MyEbook.epub";
			_sourceFolderTextBox.Text = GetAppSetting("defaultSourceFolder", "");
			_creatorTextBox.Text = Environment.UserName;
			_languageTextBox.Text = GetAppSetting("defaultLanguage", "en");
			_rightsTextBox.Text = GetAppSetting("defaultRights", "Attribution-NonCommercial-ShareAlike 3.0 Unported (CC BY-NC-SA 3.0)");
			_sourceTextBox.Text = GetAppSetting("defaultSource", "");
			_titleTextBox.Text = GetAppSetting("defaultTitle", "");
		}

		private void BrowseButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.ShowNewFolderButton = false;
			if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				_sourceFolderTextBox.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{
			if (!this.ValidateChildren())
			{
				return;
			}

			DisableControls();

			try
			{
				ConfigurationSettings configurationSettings = new ConfigurationSettings();
				configurationSettings.OutputFileName = _outputFileNameTextBox.Text.Trim();
				configurationSettings.OutputFolder = GetAppSetting("outputPath", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
				configurationSettings.SourceFolder = _sourceFolderTextBox.Text.Trim();
				configurationSettings.TempFolder = Path.Combine(Path.GetTempPath(), "epubcreator");
				configurationSettings.Creator = _creatorTextBox.Text.Trim();
				configurationSettings.Language = _languageTextBox.Text.Trim();
				configurationSettings.Rights = _rightsTextBox.Text.Trim();
				configurationSettings.Title = _titleTextBox.Text.Trim();
				configurationSettings.TitlePage = GetAppSetting("defaultTitlePage", String.Empty);

				EpubCreator epubCreator = new EpubCreator(configurationSettings);
				epubCreator.Create();

				if (!GetAppSetting("preserveTempFiles", "false").Equals("true", StringComparison.OrdinalIgnoreCase))
				{
					Directory.Delete(configurationSettings.TempFolder);
				}
			}
			finally
			{
				EnableControls();
			}
		}

		private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Escape closes the form.
			if (e.KeyChar == (Char)Keys.Escape)
			{
				this.Close();
			}
		}

		private void SourceFolderTextBox_Validating(object sender, CancelEventArgs e)
		{
			String errorMessage = String.Empty;

			if (String.IsNullOrEmpty(_sourceFolderTextBox.Text.Trim()))
			{
				e.Cancel = true;
				errorMessage = "A source folder must be specified.";
			}
			else
			{
				if (!Directory.Exists(_sourceFolderTextBox.Text.Trim()))
				{
					e.Cancel = true;
					errorMessage = "The source folder must exist.";
				}
			}

			_errorProvider.SetError(_sourceFolderTextBox, errorMessage);
		}

		private void DisableControls()
		{
			_outputFileNameTextBox.Enabled = false;
			_sourceFolderTextBox.Enabled = false;
			_browseButton.Enabled = false;
			_creatorTextBox.Enabled = false;
			_languageTextBox.Enabled = false;
			_rightsTextBox.Enabled = false;
			_sourceTextBox.Enabled = false;
			_titleTextBox.Enabled = false;
			_createButton.Enabled = false;
		}

		private void EnableControls()
		{
			_outputFileNameTextBox.Enabled = true;
			_sourceFolderTextBox.Enabled = true;
			_browseButton.Enabled = true;
			_creatorTextBox.Enabled = true;
			_languageTextBox.Enabled = true;
			_rightsTextBox.Enabled = true;
			_sourceTextBox.Enabled = true;
			_titleTextBox.Enabled = true;
			_createButton.Enabled = true;
		}

		private String GetAppSetting(String appSettingKey, String defaultValue)
		{
			String appSettingValue = ConfigurationManager.AppSettings[appSettingKey];
			if (String.IsNullOrEmpty(appSettingValue))
			{
				return defaultValue;
			}
			else
			{
				return appSettingValue;
			}
		}
	}
}
