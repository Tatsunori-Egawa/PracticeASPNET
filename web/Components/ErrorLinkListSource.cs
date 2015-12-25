using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Components {
    public class ErrorLinkListSource {
        public string message { get; set; }
        public string Id { get; set; }
        public string clientId { get; set; }
        /// <summary>
        /// エラーでなく警告扱いにするかどうか。
        /// </summary>
        public bool IsWarning { get; set; }
    }
}