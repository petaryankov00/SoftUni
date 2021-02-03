using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"C:\Users\Admin\Desktop\ZipDemo", @"D:\ZipDemo1\myZipFile.zip");
            ZipFile.ExtractToDirectory(@"D:\ZipDemo1\myZipFile.zip", @"D:\ZipDemoResult");
        }
    }
}
