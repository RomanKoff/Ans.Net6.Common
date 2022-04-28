using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace Ans.Net6.Common
{

	// string GetDebugXmlHtml(object obj)
	// string GetXmlStringFromObject(object obj)
	// XmlDocument GetXmlDocumentFromObject(object obj)
	// T GetObjectFromXml<T>(string source, string defaultNamespace = null)
	// T GetObjectFromXml<T>(XmlDocument source, string defaultNamespace = null)
	// T GetObjectFromXml<T>(Stream stream, string defaultNamespace = null)
	// T GetObjectFromXmlFile<T>(string filename, string defaultNamespace = null)
	// void SaveObjectToXmlFile(object obj, string filename)
	// string MakeFromXml(string xmlPath, string xsltPath, List<KeyValuePair<string, string>> parameters = null)

	public static class SuppXml
	{

		public static string GetDebugXmlHtml(
			object obj)
		{
			var sb = new StringBuilder();
			string s1 = GetXmlStringFromObject(obj);
			sb.AppendLine($"<h4>{obj.GetType().FullName}</h4>");
			sb.AppendLine("<pre><code class=\"language-html line-numbers\">");
			sb.AppendLine(SuppHtml.EscapeHtml(SuppHtml.MakeIndents(s1)));
			sb.AppendLine("</code></pre>");
			return sb.ToString();
		}


		public static string GetXmlStringFromObject(
			object obj)
		{
			if (obj == null)
				return string.Empty;
			var serializer = new XmlSerializer(obj.GetType()); // SerializerCache.GetSerializer(type)
			var ns = new XmlSerializerNamespaces(
				new XmlQualifiedName[] { new XmlQualifiedName(string.Empty) });
			var sb = new StringBuilder();
			using var writer = new StringWriter(sb, CultureInfo.InvariantCulture);
			serializer.Serialize(writer, obj, ns);
			return sb.ToString();
		}


		public static XmlDocument GetXmlDocumentFromObject(
			object obj)
		{
			if (obj == null)
				return null;
			var xml = new XmlDocument();
			xml.LoadXml(GetXmlStringFromObject(obj));
			return xml;
		}


		public static T GetObjectFromXml<T>(
			string source,
			string defaultNamespace = null)
		{
			Type t1 = typeof(T);
			var serializer = new XmlSerializer(t1, defaultNamespace); // SerializerCache.GetSerializer(type)
			using var reader = new StringReader(source);
			return (T)serializer.Deserialize(reader);
		}


		public static T GetObjectFromXml<T>(
			XmlDocument source,
			string defaultNamespace = null)
		{
			return GetObjectFromXml<T>(
				source.InnerXml, defaultNamespace);
		}


		public static T GetObjectFromXml<T>(
			Stream stream,
			string defaultNamespace = null)
		{
			Type t1 = typeof(T);
			var serializer = new XmlSerializer(t1, defaultNamespace); // SerializerCache.GetSerializer(type)
			var obj = (T)serializer.Deserialize(stream);
			return obj;
		}


		public static T GetObjectFromXmlFile<T>(
			string filename,
			string defaultNamespace = null)
		{
			using var stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
			return GetObjectFromXml<T>(stream, defaultNamespace);
		}


		public static void SaveObjectToXmlFile(
			object obj,
			string filename)
		{
			if (obj != null)
			{
				var serializer = new XmlSerializer(obj.GetType()); // SerializerCache.GetSerializer(type)
				var ns = new XmlSerializerNamespaces(
					new XmlQualifiedName[] { new XmlQualifiedName(string.Empty) });
				using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
				serializer.Serialize(stream, obj, ns);
			}
		}


		public static string MakeFromXml(
			string xmlPath,
			string xsltPath,
			List<KeyValuePair<string, string>> parameters = null)
		{
			string s1;
			try
			{
				var xmlSettings = new XmlReaderSettings
				{
					XmlResolver = null,
					IgnoreComments = true,
					DtdProcessing = DtdProcessing.Ignore,
					ValidationType = ValidationType.None
				};
				var xsltSettings = new XmlReaderSettings
				{
					XmlResolver = null,
					DtdProcessing = DtdProcessing.Ignore,
					ValidationType = ValidationType.None
				};
#if DEBUG
				xmlSettings.ValidationEventHandler += (sender, e) =>
				{
					Debug.WriteLine($"{e.Exception.SourceUri}({e.Exception.LineNumber},{e.Exception.LinePosition}): {e.Severity} — {e.Message}");
				};
				xsltSettings.ValidationEventHandler += (sender, e) =>
				{
					Debug.WriteLine($"{e.Exception.SourceUri}({e.Exception.LineNumber},{e.Exception.LinePosition}): {e.Severity} — {e.Message}");
				};
#endif
				var args = new XsltArgumentList();
				if (parameters != null)
					foreach (KeyValuePair<string, string> param in parameters)
						args.AddParam(param.Key, string.Empty, param.Value);
				using var xmlReader = XmlReader.Create(xmlPath, xmlSettings);
				using var xsltReader = XmlReader.Create(xsltPath, xsltSettings);
				var t1 = new XslCompiledTransform();
				t1.Load(xsltReader, new XsltSettings(true, true), new XmlUrlResolver());
				using var writer = new StringWriter();
				var writerSettings = new XmlWriterSettings
				{
					Encoding = Encoding.UTF8,
					OmitXmlDeclaration = true
				};
				var xmlWriter = XmlWriter.Create(writer, writerSettings);
				t1.Transform(xmlReader, args, writer);
				s1 = writer.ToString();
			}
			catch
			{
				s1 = $"{{{_ResErrors.Text_XmlXslt_TransformationFail}}}";
			}
			return s1;
		}

	}

}
