using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Web;

namespace TaloWeb.Utilities
{
    public static class WebUtilities
    {
        public static string ReadToEnd(this Stream Stream)

        {
            int lenght = (int )Stream.Length;
            byte[] buffer = new byte[lenght];
            int bytesRead = Stream.Read(buffer, 0, lenght);
            string data = Encoding.UTF8.GetString(buffer, 0 ,bytesRead);
            return data;

        }
    }
}