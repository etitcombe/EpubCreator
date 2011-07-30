using System;
using System.IO;
using System.Text;

using Ionic.Zip;
using Ionic.Zlib;

namespace ETitcombe.EpubCreator
{
	class EpubCreator
	{
		private const String OPF_FILENAME = "epub.opf";

		private ConfigurationSettings _configurationSettings;

		public EpubCreator(ConfigurationSettings configurationSettings)
		{
			_configurationSettings = configurationSettings;
		}

		public void Create()
		{
			CreateOutputFolders();
			CopyStylesheet();
			CreateMimetypeFile();
			CreateContainerFile();
			CreateOpfFile();
			CreateNcxFile();
			CreateZipFile();
		}

		private void CopyStylesheet()
		{
			File.Copy("stylesheet.css", Path.Combine(_configurationSettings.TempFolder, "stylesheet.css"), true);
		}

		private void CreateContainerFile()
		{
			File.WriteAllText(Path.Combine(_configurationSettings.TempFolder, "META-INF\\container.xml"),
				"<?xml version=\"1.0\"?>" + Environment.NewLine +
				"<container version=\"1.0\" xmlns=\"urn:oasis:names:tc:opendocument:xmlns:container\">" + Environment.NewLine +
				"  <rootfiles>" + Environment.NewLine +
				"    <rootfile full-path=\"" + OPF_FILENAME + "\"" + Environment.NewLine +
				"      media-type=\"application/oebps-package+xml\" />" + Environment.NewLine +
				"  </rootfiles>" + Environment.NewLine +
				"</container>");
		}

		private void CreateMimetypeFile()
		{
			File.WriteAllText(Path.Combine(_configurationSettings.TempFolder, "mimetype"), "application/epub+zip");
		}

		private void CreateOpfFile()
		{
			StringBuilder opfBuilder = new StringBuilder();
			opfBuilder.AppendLine("<?xml version=\"1.0\"?>");
			opfBuilder.AppendLine("<package version=\"2.0\" xmlns=\"http://www.idpf.org/2007/opf\" unique-identifier=\"BookId\">");
			opfBuilder.AppendLine("  <metadata xmlns:dc=\"http://purl.org/dc/elements/1.1/\"");
			opfBuilder.AppendLine("    xmlns:opf=\"http://www.idpf.org/2007/opf\">");
			opfBuilder.AppendLine(String.Format("    <dc:creator opf:file-as=\"{0}\" opf:role=\"aut\">{0}</dc:creator>", _configurationSettings.Creator));
			opfBuilder.AppendLine(String.Format("    <dc:date opf:event=\"creation\">{0}</dc:date>", DateTime.Now.ToString("yyyy-MM-dd")));
			opfBuilder.AppendLine("    <dc:identifier id=\"BookId\" opf:scheme=\"uuid\">1D429102-60D6-4067-9529-8E6D91DE4B59</dc:identifier>");
			opfBuilder.AppendLine(String.Format("    <dc:language>{0}</dc:language>", _configurationSettings.Language));
			opfBuilder.AppendLine(String.Format("    <dc:rights>{0}</dc:rights>", _configurationSettings.Rights));
			opfBuilder.AppendLine(String.Format("    <dc:source>{0}</dc:source>", _configurationSettings.Source)); // http://blog.iblamethepatriarchy.com
			opfBuilder.AppendLine(String.Format("    <dc:title>{0}</dc:title>", _configurationSettings.Title)); // I Blame the Patriarchy
			opfBuilder.AppendLine("  </metadata>");
			opfBuilder.AppendLine("  <manifest>");
			opfBuilder.AppendLine("    <item id=\"ncx\" href=\"toc.ncx\" media-type=\"application/x-dtbncx+xml\" />");
			opfBuilder.AppendLine("    <item id=\"css\" href=\"stylesheet.css\" media-type=\"text/css\" />");
			//opfBuilder.AppendLine("    <item id=\"title-image\" href=\"ibtp.jpg\" media-type=\"image/jpeg\" />");
			opfBuilder.AppendLine(String.Format("    <item id=\"title-page\" href=\"{0}\" media-type=\"application/xhtml+xml\" />", _configurationSettings.TitlePage));
			opfBuilder.Append(GetManifestItems());
			opfBuilder.AppendLine("  </manifest>");
			opfBuilder.AppendLine("  <spine toc=\"ncx\">");
			opfBuilder.Append(GetSpineItems());
			opfBuilder.AppendLine("  </spine>");
			//opfBuilder.AppendLine("  <guide>");
			//opfBuilder.AppendLine("  </guide>");
			opfBuilder.AppendLine("</package>");

			File.WriteAllText(Path.Combine(_configurationSettings.TempFolder, OPF_FILENAME), opfBuilder.ToString());
		}

		private void CreateOutputFolders()
		{
			if (!Directory.Exists(Path.Combine(_configurationSettings.TempFolder, "META-INF")))
			{
				Directory.CreateDirectory(Path.Combine(_configurationSettings.TempFolder, "META-INF"));
			}

			//if (!Directory.Exists(Path.Combine(_configurationSettings.TempFolder, "OEBPS")))
			//{
			//  Directory.CreateDirectory(Path.Combine(_configurationSettings.TempFolder, "OEBPS"));
			//}

			if (!Directory.Exists(_configurationSettings.OutputFolder))
			{
				Directory.CreateDirectory(_configurationSettings.OutputFolder);
			}
		}

		private void CreateNcxFile()
		{
			StringBuilder ncxBuilder = new StringBuilder();
			ncxBuilder.AppendLine("<?xml version=\"1.0\"?>");
			ncxBuilder.AppendLine("<!DOCTYPE ncx PUBLIC \"-//NISO//DTD ncx 2005-1//EN\"");
			ncxBuilder.AppendLine("\"http://www.daisy.org/z3986/2005/ncx-2005-1.dtd\">");
			ncxBuilder.AppendLine("<ncx xmlns=\"http://www.daisy.org/z3986/2005/ncx/\" version=\"2005-1\">");
			ncxBuilder.AppendLine("  <head>");
			ncxBuilder.AppendLine("    <meta name=\"dtb:uid\" content=\"1D429102-60D6-4067-9529-8E6D91DE4B59\"/>");
			ncxBuilder.AppendLine("    <meta name=\"dtb:depth\" content=\"1\"/>");
			ncxBuilder.AppendLine("    <meta name=\"dtb:totalPageCount\" content=\"0\"/>");
			ncxBuilder.AppendLine("    <meta name=\"dtb:maxPageNumber\" content=\"0\"/>");
			ncxBuilder.AppendLine("  </head>");
			ncxBuilder.AppendLine("  <docTitle>");
			ncxBuilder.AppendLine("    <text>I Blame the Patriarchy</text>");
			ncxBuilder.AppendLine("  </docTitle>");
			ncxBuilder.AppendLine("  <navMap>");
			ncxBuilder.Append(GetNcxItems());
			ncxBuilder.AppendLine("  </navMap>");
			ncxBuilder.AppendLine("</ncx>");

			File.WriteAllText(Path.Combine(_configurationSettings.TempFolder, "toc.ncx"), ncxBuilder.ToString());
		}

		private void CreateZipFile()
		{
			ZipFile zipFile = new ZipFile(Encoding.UTF8);
			zipFile.UseUnicodeAsNecessary = true;
			zipFile.EmitTimesInWindowsFormatWhenSaving = false;
			zipFile.Encryption = EncryptionAlgorithm.None;
			zipFile.CompressionLevel = CompressionLevel.None;
			//zipFile.AddEntry("mimetype", data.Mimetype, Encoding.ASCII);
			zipFile.AddFile(Path.Combine(_configurationSettings.TempFolder, "mimetype"), "");

			zipFile.CompressionLevel = CompressionLevel.BestCompression; //.Default;
			zipFile.AddFile(Path.Combine(_configurationSettings.TempFolder, OPF_FILENAME), "");
			zipFile.AddFile(Path.Combine(_configurationSettings.TempFolder, "stylesheet.css"), "");
			zipFile.AddFile(Path.Combine(_configurationSettings.TempFolder, "toc.ncx"), "");
			//zipFile.AddFile(Path.Combine(_configurationSettings.TempFolder, "ibtp.jpg"), "");
			zipFile.AddFile(Path.Combine(_configurationSettings.SourceFolder, _configurationSettings.TitlePage), "");
			zipFile.AddFile(Path.Combine(_configurationSettings.TempFolder, "META-INF\\container.xml"), "META-INF");

			String[] fileNames = GetFiles();
			foreach (String fileName in fileNames)
			{
				zipFile.AddFile(fileName, "OEBPS");
			}

			zipFile.Save(Path.Combine(_configurationSettings.OutputFolder, _configurationSettings.OutputFileName));
		}

		private String[] GetFiles()
		{
			return Directory.GetFiles(_configurationSettings.SourceFolder, "*.html");
		}

		private String GetManifestItems()
		{
			StringBuilder builder = new StringBuilder();

			String[] files = GetFiles();
			String fileName = String.Empty;
			foreach (String file in files)
			{
				fileName = Path.GetFileName(file);

				builder.AppendLine(String.Format("    <item id=\"ch{0}\" href=\"{1}\" media-type=\"application/xhtml+xml\" />", fileName.Substring(0, 4), "OEBPS/" + fileName));
			}

			return builder.ToString();
		}

		private String GetNcxItems()
		{
			StringBuilder builder = new StringBuilder();

			builder.AppendLine(
					"    <navPoint id=\"title-page\" playOrder=\"1\">" + Environment.NewLine +
					"      <navLabel>" + Environment.NewLine +
					"        <text>Title Page</text>" + Environment.NewLine +
					"      </navLabel>" + Environment.NewLine +
					"      <content src=\"" + _configurationSettings.TitlePage + "\" />" + Environment.NewLine +
					"    </navPoint>");

			String[] files = GetFiles();
			String fileName = String.Empty;
			foreach (String file in files)
			{
				fileName = Path.GetFileName(file);

				if (!fileName.Equals(_configurationSettings.TitlePage, StringComparison.OrdinalIgnoreCase))
				{
					builder.AppendLine(String.Format(
						"    <navPoint id=\"ch{0}\" playOrder=\"{1}\">" + Environment.NewLine +
						"      <navLabel>" + Environment.NewLine +
						"        <text>{2}</text>" + Environment.NewLine +
						"      </navLabel>" + Environment.NewLine +
						"      <content src=\"OEBPS/{3}\" />" + Environment.NewLine +
						"    </navPoint>",
						fileName.Substring(0, 4),
						Convert.ToInt32(fileName.Substring(0, 4)) + 1,
						fileName.Substring(5, fileName.Length - ".html".Length - 5),
						fileName));
				}
			}

			return builder.ToString();
		}

		private String GetSpineItems()
		{
			StringBuilder builder = new StringBuilder();

			builder.AppendLine("    <itemref idref=\"title-page\" />");

			String[] files = GetFiles();
			String fileName = String.Empty;
			foreach (String file in files)
			{
				fileName = Path.GetFileName(file);

				builder.AppendLine(String.Format("    <itemref idref=\"ch{0}\" />", fileName.Substring(0, 4)));
			}

			return builder.ToString();
		}
	}
}
