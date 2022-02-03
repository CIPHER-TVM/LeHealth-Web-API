using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LeHealth.Common
{
    public static class Common
    {
        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }
        public static byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }
        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
        public static List<T> ToListOfObject<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = ToObject<T>(row);
                data.Add(item);
            }
            return data;
        }

        public static T ToObject<T>(this DataRow dr)
        {
            bool b = true;
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {

                    if (pro.Name == column.ColumnName)
                    {
                        try
                        {
                            if (pro.PropertyType.Name.Equals("Boolean"))
                            {
                                pro.SetValue(obj, Convert.ToBoolean(dr[column.ColumnName]), null);
                            }

                            else
                                pro.SetValue(obj, (dr[column.ColumnName] == DBNull.Value ? null : dr[column.ColumnName]), null);
                        }
                        catch (Exception ex)
                        {
                            pro.SetValue(obj, (dr[column.ColumnName] == DBNull.Value ? null : dr[column.ColumnName]), null);
                        }
                    }
                    else
                        continue;
                }
            }
            return obj;
        }

        public static T ToObject<T>(this DataTable dt)
        {

            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dt.Rows[0].Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dt.Rows[0][column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public static T ToObject<T>(this DataSet ds)
        {

            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in ds.Tables[0].Rows[0].Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, ds.Tables[0].Rows[0][column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        public static int GetLastInsertId(this System.Data.DataSet ds)
        {
            int LASTINSERTID = 0;
            try
            {
                if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        LASTINSERTID = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString().Trim());

                    }

                }

                return LASTINSERTID;
            }
            catch (Exception Ex) { return LASTINSERTID; }


        }
        public static int GetRowCount(this System.Data.DataTable dt)
        {
            int RowCount = 0;
            try
            {
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    RowCount = Convert.ToInt32(dt.Rows[0][0].ToString().Trim());

                }

                return RowCount;
            }
            catch (Exception Ex) { return RowCount; }


        }
        public static string Trimspace(this string str)
        {
            string retString = string.Empty;
            try
            {
                if (str != null)
                {
                    retString = string.Concat(str.Where(c => !char.IsWhiteSpace(c)));
                }

                return retString;
            }
            catch (Exception Ex) { return retString; }


        }
        public static string TrimObject(this string str)
        {
            string retString = string.Empty;
            try
            {
                if (str != null)
                {
                    retString = str.Trim();
                }

                return retString;
            }
            catch (Exception Ex) { return retString; }


        }
        public static Int64 ToInt64(this Int64? str)
        {
            Int64 retString = 0;
            try
            {
                if (str != null)
                {
                    retString = str.Value;
                }

                return retString;
            }
            catch (Exception Ex) { return retString; }


        }
        public static string ToRound(this decimal? decimalValue)
        {
            string retdecimalValue = "000.000";
            try
            {
                if (decimalValue.HasValue)
                {
                    retdecimalValue = decimalValue.Value.ToString("000.000");
                }
                return retdecimalValue;
            }
            catch (Exception Ex) { return retdecimalValue; }

        }
        public static string ToRound(this decimal? decimalValue, string format)
        {
            string retdecimalValue = format;
            try
            {
                if (decimalValue.HasValue)
                {
                    retdecimalValue = decimalValue.Value.ToString(format);
                }
                return retdecimalValue;
            }
            catch (Exception Ex) { return retdecimalValue; }

        }
        public static string ToDecimalRound(this decimal? decimalValue, int integerLength, int decimalLength)
        {
            try
            {
                string integerVal = "";
                string decimalVal = "";
                if (decimalValue.HasValue)
                {
                    var decimalArray = decimalValue.Value.ToString().Split('.');
                    if (decimalArray.Length == 1)
                    {
                        integerVal = decimalArray[0].PadLeft(integerLength, '0');
                        decimalVal = decimalVal.PadRight(decimalLength, '0');
                    }
                    else
                    {
                        integerVal = decimalArray[0].PadLeft(integerLength, '0');
                        decimalVal = decimalArray[1].PadRight(decimalLength, '0');
                    }

                }
                else
                {
                    integerVal = integerVal.PadLeft(integerLength, '0');
                    decimalVal = decimalVal.PadRight(decimalLength, '0');
                }
                return $"{integerVal}.{decimalVal}";
            }
            catch (Exception Ex)
            {
                return "";
            }

        }
        public static string ToIntegerRoundFormat(this int? intVal, int integerLength)
        {
            try
            {
                string integerVal = "";
                if (intVal.HasValue)
                {
                    integerVal = intVal.ToString().PadLeft(integerLength, '0');
                }
                else
                {
                    integerVal = intVal.ToString().PadLeft(integerLength, '0');
                }
                return $"{integerVal}";
            }
            catch (Exception Ex)
            {
                return "";
            }

        }
        public static decimal ToDecimal(this string str)
        {
            string retString = "0.00";
            try
            {
                if (str != null)
                {
                    if (str.Trim() != "")
                    {
                        retString = str.Trim();
                    }
                }

                return Convert.ToDecimal(retString);
            }
            catch (Exception Ex) { return Convert.ToDecimal(retString); }


        }

        public static long ToInt64(this string str)
        {
            string retString = "0";
            try
            {
                if (!String.IsNullOrEmpty(str))
                {
                    retString = str.Trim();
                }

                return Convert.ToInt64(retString);
            }
            catch (Exception Ex) { return Convert.ToInt64(retString); }


        }
        public static string Int64ToString(this Int64? intValue, int totalLength, char padChar)
        {
            string retString = "";
            try
            {
                if (intValue.HasValue)
                {
                    retString = intValue.Value.ToString().PadRight(totalLength, padChar);
                }
                else
                {
                    retString = retString.PadRight(totalLength, padChar);
                }
                return retString;
            }
            catch (Exception Ex) { return retString; }


        }
        public static string Int32ToString(this Int32? intValue, int totalLength, char padChar)
        {
            string retString = "";
            try
            {
                if (intValue.HasValue)
                {
                    retString = intValue.Value.ToString().PadRight(totalLength, padChar);
                }
                else
                {
                    retString = retString.PadRight(totalLength, padChar);
                }
                return retString;
            }
            catch (Exception Ex) { return retString; }


        }
        public static string DecimalToString(this decimal? decValue, int totalLength, char padChar)
        {
            string retString = "";
            try
            {
                if (decValue.HasValue)
                {
                    retString = decValue.Value.ToString().PadRight(totalLength, padChar);
                }
                else
                {
                    retString = retString.PadRight(totalLength, padChar);
                }
                return retString;
            }
            catch (Exception Ex) { return retString; }


        }
        public static string DecimalToStringWithPadRight(this decimal decValue, int totalLength, char padChar)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                string decimalValue = decValue.ToString();
                if (!decimalValue.Contains("."))
                    decimalValue = decimalValue + ".0";
                decimalValue = decimalValue.ToString().PadRight(totalLength, padChar);
                char[] arr = decimalValue.ToCharArray();
                for (int i = 0; i < totalLength; i++)
                {
                    sb.Append(arr[i]);
                }
                return sb.ToString();
            }
            catch (Exception Ex)
            {
                return sb.ToString();
            }


        }

        public static string SubstringAndPadRight(this string val, int totalLength, char padChar)
        {
            string retString = "";
            try
            {
                if (val.Length <= totalLength)
                {
                    retString = val.PadRight(totalLength, padChar);
                }
                else
                {
                    retString = val.Substring(0, totalLength);
                }
                return retString;
            }
            catch (Exception Ex) { return retString; }


        }
        public static string ReplaceSingleQuots(this string str)
        {
            string retString = string.Empty;
            try
            {
                if (str != null)
                {
                    retString = str.Trim().Replace("'", "€");
                    retString = retString.Replace('€', '"');
                }

                return retString;
            }
            catch (Exception Ex) { return retString; }


        }
        public static bool ValidCell(this string str)
        {
            bool isValid = false;
            try
            {
                if (str != null)
                {
                    if (str.TrimObject().Length == 1)
                    {
                        Regex rgx = new Regex("[^A-Za-z0-9]");
                        bool containsSpecialCharacter = rgx.IsMatch(str);
                        if (!containsSpecialCharacter)
                            isValid = true;
                    }
                    else
                        isValid = true;
                    return isValid;
                }

                return isValid;
            }
            catch (Exception Ex) { return isValid; }


        }


        public static string ToXML(this object obj)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(stringwriter, obj);
            return stringwriter.ToString();
        }



        public static void LogEntry(string module, string function, string message)
        {
            try
            {
                var logEntry = ConfigurationManager.AppSettings["logEntry"].ToString() == "OFF" ? false : true;

            }
            catch (Exception ex)
            {

            }
        }

        public static string DecimalCheck(this decimal Number)
        {
            string retval = Number.ToString();
            decimal result = Number - Math.Truncate(Number);
            if (result == 0)
            {
                retval = Math.Truncate(Number).ToString();
            }

            return retval;
        }
        public static string Convert_ImageTo_Base64(string path)
        {
            try
            {
                string filename = path;
                FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                int size = (int)f.Length;
                byte[] MyData = new byte[f.Length + 1];
                f.Read(MyData, 0, size);
                f.Close();
                return Convert.ToBase64String(MyData);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }


}
