using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Services;

namespace Settings.WorkingYear
{
    public class WorkingYear
    {
        private string _filePath = Path.Combine(Application.StartupPath, "db");


        public Guid Guid { get; set; }
        public string DbName { get; set; }
        public string ConnectionString { get; set; }
        public string InitialCatalog { get; set; }


        public WorkingYear() { }
        public WorkingYear(string fileName, string rootPath = "")
        {
            Guid = Guid.Parse(fileName);
            DbName = GetDbName();
            ConnectionString = GetConnectionString();
            InitialCatalog = GetInitialCatalog();
        }

        private string GetDbName()
        {
            try
            {
                if (string.IsNullOrEmpty(_filePath)) return "";
                var contentPath = Path.Combine(_filePath, Guid.ToString());
                contentPath = Path.Combine(contentPath, "dbn.txt");
                return File.Exists(contentPath) ? File.ReadAllText(contentPath).Trim() : "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        private string GetConnectionString()
        {
            try
            {
                if (string.IsNullOrEmpty(_filePath)) return "";
                var contentPath = Path.Combine(_filePath, Guid.ToString());
                contentPath = Path.Combine(contentPath, "cn.txt");
                return File.Exists(contentPath) ? File.ReadAllText(contentPath).Trim() : "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        private string GetInitialCatalog()
        {
            try
            {
                if (string.IsNullOrEmpty(_filePath)) return "";
                var contentPath = Path.Combine(_filePath, Guid.ToString());
                contentPath = Path.Combine(contentPath, "in.txt");
                return File.Exists(contentPath) ? File.ReadAllText(contentPath).Trim() : "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }

        public static List<WorkingYear> GetAll(string rootPath = "")
        {
            var list = new List<WorkingYear>();
            try
            {
                if (string.IsNullOrEmpty(rootPath)) rootPath = Path.Combine(Application.StartupPath, "db");
                if (!Directory.Exists(rootPath)) return list;

                var list_ = Directory.GetDirectories(rootPath);
                foreach (var dir in list_)
                {
                    string lastFolderName = Path.GetFileName(dir);
                    var newAdv = new WorkingYear(lastFolderName, rootPath);
                    list.Add(newAdv);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public ReturnedSaveFuncInfo Save()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (!Directory.Exists(_filePath)) Directory.CreateDirectory(_filePath);

                var path = Path.Combine(_filePath, Guid.ToString());
                Directory.CreateDirectory(path);

                var namePath = Path.Combine(path, "dbn.txt");
                File.WriteAllText(namePath, DbName);

                var cnPath = Path.Combine(path, "cn.txt");
                File.WriteAllText(cnPath, ConnectionString);

                var inPath = Path.Combine(path, "in.txt");
                File.WriteAllText(inPath, InitialCatalog);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static WorkingYear Get(Guid guid, string rootPath = "")
        {
            try
            {
                if (string.IsNullOrEmpty(rootPath)) rootPath = Path.Combine(Application.StartupPath, "db");

                if (string.IsNullOrEmpty(rootPath) || !Directory.Exists(Path.Combine(rootPath, guid.ToString())))
                    return null;
                var resultAdv = new WorkingYear(guid.ToString());
                return resultAdv;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static ReturnedSaveFuncInfo Delete(Guid guid, string rootPath = "")
        {
            var ret = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrEmpty(rootPath))
                    rootPath = Path.Combine(Application.StartupPath, "db");

                var deletePath = Path.Combine(rootPath, guid.ToString());
                if (!Directory.Exists(deletePath))
                {
                    ret.AddReturnedValue(ReturnedState.Warning, "سال کاری مورد نظر برای حذف، وجود ندارد");
                    return ret;
                }

                Directory.Delete(deletePath, true);

                return ret;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                ret.AddReturnedValue(ex);
            }
            return ret;
        }
    }
}
