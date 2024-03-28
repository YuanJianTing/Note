using System.Reflection;
using System.Xml;

namespace NoteClient
{
    public class SharedPreference
    {
        private const string folderName = "shared_prefs";//配置文件夹名称
        private string fileName;
        private string path;//配置文件路径


        public static void RemovePreference(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = "shaerd.xml";
            }
            if (fileName.LastIndexOf(".xml") == -1)
            {
                fileName += ".xml";
            }
            string appdata = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            Assembly a = Assembly.GetEntryAssembly();
            string path = Path.Combine(appdata, a.GetName().Name);
            if (!Directory.Exists(path))
            {
                return;
            }

            path = Path.Combine(path, folderName);
            if (!Directory.Exists(path))
            {
                return;
            }
            path = Path.Combine(path, fileName);
            if (!File.Exists(path))
            {
                return;
            }
            File.Delete(path);
        }




        public SharedPreference(string fileName = "shaerd.xml")
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = "shaerd.xml";
            }
            if (fileName.LastIndexOf(".xml") == -1)
            {
                fileName += ".xml";
            }
            this.fileName = fileName;
            Init();
        }

        private void Init()
        {
            string appdata = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            Assembly a = Assembly.GetEntryAssembly();
            if (a == null)
                a = typeof(SharedPreference).Assembly;
            path = Path.Combine(appdata, a.GetName().Name);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, fileName);
            if (!File.Exists(path))
            {
                CreateXML();
            }
        }

        #region 添加
        /// <summary>
        /// 添加键值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, bool value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            if (Exists("Boolean", key))
            {
                //存在
                UpdateTagAttr("Boolean", key, value);
            }
            else
            {
                CreateTagAttr("Boolean", key, value);
            }
        }


        public void Add(string key, string[] array)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            if (array == null || array.Length == 0)
                return;
            if (Exists("arrayString", key))
            {
                //存在
                UpdateTagAttr("arrayString", key, "string", array);
            }
            else
            {
                CreateTagAttr("arrayString", key, "string", array);
            }
        }

        /// <summary>
        /// 添加键值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            if (string.IsNullOrWhiteSpace(value))
                value = "";
            if (Exists("string", key))
            {
                //存在
                UpdateTagAttr("string", key, value);
            }
            else
            {
                CreateTagAttr("string", key, value);
            }
        }
        /// <summary>
        /// 添加键值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, int[] array)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            if (array == null || array.Length == 0)
                return;
            if (Exists("arrayInt", key))
            {
                //存在
                UpdateTagAttr("arrayInt", key, "int", Array.ConvertAll<int, string>(array, n => n.ToString()));
            }
            else
            {
                CreateTagAttr("arrayInt", key, "int", Array.ConvertAll<int, string>(array, n => n.ToString()));
            }
        }

        /// <summary>
        /// 添加键值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, int value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            if (Exists("int", key))
            {
                //存在
                UpdateTagAttr("int", key, value);
            }
            else
            {
                CreateTagAttr("int", key, value);
            }
        }
        /// <summary>
        /// 添加键值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, DateTime value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            if (Exists("DateTime", key))
            {
                //存在
                UpdateTagAttr("DateTime", key, value);
            }
            else
            {
                CreateTagAttr("DateTime", key, value);
            }
        }
        /// <summary>
        /// 添加键值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, double value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            if (Exists("double", key))
            {
                //存在
                UpdateTagAttr("double", key, value);
            }
            else
            {
                CreateTagAttr("double", key, value);
            }
        }
        /// <summary>
        /// 添加键值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, float value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            if (Exists("float", key))
            {
                //存在
                UpdateTagAttr("float", key, value);
            }
            else
            {
                CreateTagAttr("float", key, value);
            }
        }
        /// <summary>
        /// 添加键值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, long value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            if (Exists("long", key))
            {
                //存在
                UpdateTagAttr("long", key, value);
            }
            else
            {
                CreateTagAttr("long", key, value);
            }
        }
        #endregion

        #region 获取值
        public bool GetBooleanValue(string key)
        {
            bool result = false;
            bool.TryParse(ReadByKey("Boolean", key), out result);
            return result;
        }
        public string[] GetArrayStringValue(string key)
        {
            return ReadArrayByKey("arrayString", key);
        }
        public string GetStringValue(string key)
        {
            return ReadByKey("string", key);
        }
        public string GetStringValue(string key, string defaultValue)
        {
            string result = ReadByKey("string", key);

            return (string.IsNullOrEmpty(result)) ? defaultValue : result;
        }
        public int[] GetArrayIntValue(string key)
        {
            string[] array = ReadArrayByKey("arrayInt", key);
            try
            {
                return Array.ConvertAll<string, int>(array, n => int.Parse(n));
            }
            catch (Exception)
            {
            }
            return null;
        }
        public int GetIntValue(string key)
        {
            return GetIntValue(key, 0);
        }
        public int GetIntValue(string key, int defaultValue)
        {
            int result = 0;
            if (!int.TryParse(ReadByKey("int", key), out result))
                return defaultValue;
            return result;
        }

        public DateTime GetDateTimeValue(string key)
        {
            DateTime result;
            DateTime.TryParse(ReadByKey("DateTime", key), out result);
            return result;
        }
        public double GetDoubleValue(string key)
        {
            double result = 0;
            double.TryParse(ReadByKey("double", key), out result);
            return result;
        }
        public double GetDoubleValue(string key,double defaultValue)
        {
            double result = 0;
            if(double.TryParse(ReadByKey("double", key), out result))
                return result;
            return defaultValue;
        }
        public float GetFloatValue(string key)
        {
            float result = 0;
            float.TryParse(ReadByKey("float", key), out result);
            return result;
        }
        public long GetLongValue(string key)
        {
            long result = 0;
            long.TryParse(ReadByKey("long", key), out result);
            return result;
        }
        #endregion

        public void RemovePreference()
        {
            if (!File.Exists(path))
                return;
            File.Delete(path);
        }


        /// <summary>
        /// 添加属性节点
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void CreateTagAttr(string tag, string key, string childName, string[] param)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            AddXmlNode(doc, root, tag, key, childName, param);
            doc.Save(path);
        }

        /// <summary>
        /// 添加属性节点
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void CreateTagAttr(string tag, string key, object value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            AddXmlNode(doc, root, tag, key, value);
            doc.Save(path);
        }

        /// <summary>
        /// 更新节点属性值
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void UpdateTagAttr(string tag, string key, string childName, string[] value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlNodeList list = root.GetElementsByTagName(tag);
            foreach (XmlElement item in list)
            {
                string name = item.GetAttribute("name");
                if (name == key)
                {
                    item.InnerXml = string.Empty;
                    foreach (var ChildItem in value)
                    {
                        XmlElement childNode = doc.CreateElement(childName);
                        childNode.InnerText = ChildItem;
                        item.AppendChild(childNode);
                    }
                    doc.Save(path);
                    break;
                }
            }
        }


        /// <summary>
        /// 更新节点属性值
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void UpdateTagAttr(string tag, string key, object value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlNodeList list = root.GetElementsByTagName(tag);
            foreach (XmlElement item in list)
            {
                string name = item.GetAttribute("name");
                if (name == key)
                {
                    item.InnerText = value.ToString();
                    doc.Save(path);
                    break;
                }
            }
        }


        private string[] ReadArrayByKey(string tag, string key)
        {
            List<string> result = new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlNodeList list = root.GetElementsByTagName(tag);
            foreach (XmlElement item in list)
            {
                string name = item.GetAttribute("name");
                if (name == key)
                {
                    foreach (XmlNode childItem in item.ChildNodes)
                    {
                        result.Add(childItem.InnerText);
                    }
                    break;
                }
            }
            return result.ToArray();
        }


        private string ReadByKey(string tag, string key)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlNodeList list = root.GetElementsByTagName(tag);
            foreach (XmlElement item in list)
            {
                string name = item.GetAttribute("name");
                if (name == key)
                {
                    return item.InnerText;
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// 判断是否存在某个节点
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool Exists(string tag, string key)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlNodeList list = root.GetElementsByTagName(tag);
            foreach (XmlElement item in list)
            {
                string name = item.GetAttribute("name");
                if (name == key)
                {
                    return true;
                }
            }
            return false;
        }

        private void AddXmlNode(XmlDocument doc, XmlElement parent, string tag, string name, string childName, string[] value)
        {
            //创建节点（二级）
            XmlElement node = doc.CreateElement(tag);
            node.SetAttribute("name", name);
            foreach (var item in value)
            {
                XmlElement childNode = doc.CreateElement(childName);
                childNode.InnerText = item;
                node.AppendChild(childNode);
            }
            parent.AppendChild(node);
        }

        private void AddXmlNode(XmlDocument doc, XmlElement parent, string tag, string name, object value)
        {
            //创建节点（二级）
            XmlElement node = doc.CreateElement(tag);
            node.SetAttribute("name", name);
            node.InnerText = value.ToString();
            parent.AppendChild(node);
        }

        private void CreateXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                doc.AppendChild(dec);
                //创建一个根节点（一级）
                XmlElement root = doc.CreateElement("map");
                doc.AppendChild(root);
                doc.Save(path);
            }
            catch (System.UnauthorizedAccessException e)
            {
                throw;
            }
        }



    }
}