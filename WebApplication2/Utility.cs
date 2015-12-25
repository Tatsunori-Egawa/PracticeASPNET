using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2 {
    public static class Utility {
        public static string AddCssClass(string currentClasses, string addClass) {
            return (currentClasses.IndexOf(addClass, StringComparison.OrdinalIgnoreCase) < 0 ? currentClasses + " " + addClass : currentClasses).Trim();
        }

        public static string RemoveCssClass(string currentClasses, string removeClass) {
            // 見つかったらその部分を除去した前後の文字列を結合する。
            int idx = currentClasses.IndexOf(removeClass, StringComparison.OrdinalIgnoreCase);
            return (idx > -1 ? currentClasses.Substring(0, idx) + currentClasses.Substring(idx + removeClass.Length) : currentClasses).Trim();
        }

        public static string CreateNewId() {
            return Guid.NewGuid().ToString();
        }
    }
}