using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Utils
{
    //�ļ�����
    class FileUtils
    {

        //Application.dataPath  ��Ϸ����ŵ���Դ���ڵ��ļ��У���Щƽ̨������д

        //Application.persistentDataPath   ֻ��

        //Application.streamingAssetsPath  ������дֻ��
        //ͨ��WWW / WebRequst 


        //PlayerPrefs / ScriptableObject

        //PlayerPrefs.SetInt("Height", 190);
        //    PlayerPrefs.HasKey("Height");
        //    PlayerPrefs.GetInt("Height");
        //Application.temporaryCachePath Ӧ�õ���ʱ�ļ�Ŀ¼���ֻ���ж������ɾ����


        //�ж�ָ���ļ����Ƿ����
        public static bool IsDirExist(string path)
        {
            return Directory.Exists(path);
        }


        //����ָ��·���ļ���
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


        //ɾ��һ���ļ���
        public static bool DeleteDir(string path)
        {
            try
            {
                Directory.Delete(path, true);//ɾ��ָ����Ŀ¼����ɾ����Ŀ¼�е�������Ŀ¼���ļ�
            }
            catch (Exception exp)
            {
                return false;
            }

            return true;
        }


        //�ж�һ���ļ��Ƿ����
        public static bool IsFileExist(string path)
        {
            return File.Exists(path);
        }


        //ɾ��һ���ļ�
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


        //���ļ��ж�ȡ  ->��buf
        public static int ReadFromFile(string path, out byte[] buf)
        {
            buf = null;

            try
            {
                //�ļ���
                int ret = -1;
                FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read);//�ļ�����
                buf = new byte[fs.Length];
                ret = fs.Read(buf, 0, (int)fs.Length);
                fs.Close();
                return ret;//���뻺�����е����ֽ���
            }
            catch (Exception e)
            {
                return -1;
            }

            return -1;
        }


        //д���ļ�
        public static int WriteToFile(string path, byte[] buf)
        {
            if (buf != null)
            {
                try
                {
                    FileStream fs = File.Open(path, FileMode.Create, FileAccess.Write);
                    fs.Write(buf, 0, buf.Length);//Ҫд��λ�� ��ʲôλ�ÿ�ʼд д�೤ 
                    fs.Close();
                }
                catch (Exception e)
                {
                    return -1;
                }
            }

            return -1;
        }

        //�õ��ʲ���  �������ַ���·���ϳ�һ��·��
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

            return new Uri(Path.Combine(Application.streamingAssetsPath, path));//��һ���ļ�����unity�ļ��� �������ַ���·���ϳ�һ��·��

        }
    }
}
