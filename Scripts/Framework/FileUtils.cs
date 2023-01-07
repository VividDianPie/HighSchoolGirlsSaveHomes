using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Utils
{
    //文件工具
    class FileUtils
    {

        //Application.dataPath  游戏打包号的资源所在的文件夹，有些平台不允许写

        //Application.persistentDataPath   只读

        //Application.streamingAssetsPath  不允许写只读
        //通过WWW / WebRequst 


        //PlayerPrefs / ScriptableObject

        //PlayerPrefs.SetInt("Height", 190);
        //    PlayerPrefs.HasKey("Height");
        //    PlayerPrefs.GetInt("Height");
        //Application.temporaryCachePath 应用的零时文件目录（手机上卸载数据删除）


        //判断指定文件夹是否存在
        public static bool IsDirExist(string path)
        {
            return Directory.Exists(path);
        }


        //创建指定路径文件夹
        public static bool CreateDir(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception exp)
            {
                return false;
            }

            return true;
        }


        //删除一个文件夹
        public static bool DeleteDir(string path)
        {
            try
            {
                Directory.Delete(path, true);//删除指定的目录，并删除该目录中的所有子目录和文件
            }
            catch (Exception exp)
            {
                return false;
            }

            return true;
        }


        //判断一个文件是否存在
        public static bool IsFileExist(string path)
        {
            return File.Exists(path);
        }


        //删除一个文件
        public static bool DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exp)
            {
                return false;
            }

            return true;
        }


        //从文件中读取  ->至buf
        public static int ReadFromFile(string path, out byte[] buf)
        {
            buf = null;

            try
            {
                //文件流
                int ret = -1;
                FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read);//文件访问
                buf = new byte[fs.Length];
                ret = fs.Read(buf, 0, (int)fs.Length);
                fs.Close();
                return ret;//读入缓冲区中的总字节数
            }
            catch (Exception e)
            {
                return -1;
            }

            return -1;
        }


        //写入文件
        public static int WriteToFile(string path, byte[] buf)
        {
            if (buf != null)
            {
                try
                {
                    FileStream fs = File.Open(path, FileMode.Create, FileAccess.Write);
                    fs.Write(buf, 0, buf.Length);//要写的位置 从什么位置开始写 写多长 
                    fs.Close();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }

            return -1;
        }

        //得到资产流  将两个字符串路径合成一个路径
        public static Uri GetStreamingAssets(string path)
        {

            /*
     string filePath = "";

#if UNITY_STANDALONE
     filePath = "file:///" + Application.streamingAssetsPath + "/" + path;

#elif UNITY_ANDROID
     filePath = Application.streamingAssetsPath + "/" +  path;

#elif UNITY_IOS
     filePath = "file://" + Application.streamingAssetsPath + "/" + path;

#elif UNITY_WEBGL
            filePath = "file://" + Application.streamingAssetsPath + "/" + path;

#endif
     return filePath;

            return filePath;
            */

            return new Uri(Path.Combine(Application.streamingAssetsPath, path));//第一个文件夹是unity文件夹 将两个字符串路径合成一个路径

        }
    }
}
