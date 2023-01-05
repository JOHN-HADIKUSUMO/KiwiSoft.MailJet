using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiwiSoft.MailJet.Constants
{
    public static class FileTypes
    {
        public static string Text {

            get => "text/plain";
        }

        public static string Executable
        {

            get => "application/x-msdownload";
        }
        public static string Jpeg
        {

            get => "image/jpeg";
        }

        public static string Png
        {

            get => "image/png";
        }

        public static string Gif
        {

            get => "image/gif";
        }

        public static string Json
        {

            get => "text/json";
        }

        public static string CSV 
        {

            get => "text/csv";
        }

        public static string Pdf
        {

            get => "application/pdf";
        }

        public static string MSWord
        {

            get => "application/msword";
        }

        public static string MSExcel
        {

            get => "application/vnd.ms-excel";
        }

        public static string MSAccess
        {

            get => "application/x-msaccess";
        }

        public static string Zip
        {

            get => "application/zip";
        }


    }
}
