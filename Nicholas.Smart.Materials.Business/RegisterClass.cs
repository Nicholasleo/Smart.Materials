using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicholas.Smart.Materials.Business
{
    public class RegisterClass
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName">以有效注册表根（如“HKEY_CURRENT_USER”）开头键的完整注册表路径</param>
        /// <param name="valueName">名称/值对的名称</param>
        /// <param name="defaultValue">当name不存在时返回的值</param>
        /// <returns></returns>
        public static Object GetValue(string keyName, string valueName, Object defaultValue)
        {
            return Registry.GetValue(keyName, valueName, defaultValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName">以有效注册表根（如“HKEY_CURRENT_USER”）开头键的完整注册表路径</param>
        /// <param name="valueName">名称/值对的名称</param>
        /// <param name="value">要存储的值</param>
        public static void SetValue(string keyName, string valueName, Object value)
        {
            Registry.SetValue(keyName, valueName, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName">以有效注册表根（如“HKEY_CURRENT_USER”）开头键的完整注册表路径</param>
        /// <param name="valueName">名称/值对的名称</param>
        /// <param name="value">要存储的值</param>
        /// <param name="valueKind">存储数据时使用的注册表数据类型</param>
        public static void SetValue(string keyName, string valueName, Object value, RegistryValueKind valueKind)
        {
            Registry.SetValue(keyName, valueName, value, valueKind);
        }
        //HKEY_LOCAL_MACHINE/SOFTWARE/Materials
        /// <summary>
        /// 
        /// </summary>
        public static void CreateSubKey()
        {
            if (!IsRegeditItemExist())
            {
                RegistryKey key = Registry.LocalMachine;
                RegistryKey materials = key.CreateSubKey("SOFTWARE\\Materials\\SoftReg");
                if (materials != null)
                {
                    //RegistryKey keyA = materials.CreateSubKey("UseTimes");
                    //登录次数
                    materials.SetValue("Nicholas", NicholasEncrypt.EncryptUTF8String("0", GetSystemInfo.EncrytionKey));
                    //是否为正式版
                    materials.SetValue("Leo", NicholasEncrypt.EncryptUTF8String("NO",GetSystemInfo.EncrytionKey)); 
                    //9TrZBvE7GbI=
                    materials.SetValue("NicholasLeo", NicholasEncrypt.EncryptUTF8String("Due",GetSystemInfo.EncrytionKey)); //是否是过期的软件

                    materials.Close();
                }
                key.Close();
            }
        }

        public static string GetItemValue(string item)
        {
            string info = "";
            RegistryKey key = Registry.LocalMachine;
            RegistryKey myKey = key.OpenSubKey("SOFTWARE\\Materials\\SoftReg");
            // myreg = Key.OpenSubKey("software\\test",true);
            if (myKey != null)
            {
                info = myKey.GetValue(item).ToString();
                myKey.Close();
            }
            return info;
        }

        public static void OpenSubKey(string subkey)
        {
            RegistryKey key = Registry.LocalMachine;
            RegistryKey software = key.OpenSubKey("SOFTWARE\\Materials", true);
        }

        public static void UpdateSubKey(string item,string value)
        {
            RegistryKey key = Registry.LocalMachine;
            RegistryKey software = key.OpenSubKey("SOFTWARE\\Materials\\SoftReg", true); //该项必须已存在
            if(software != null)
                software.SetValue(item, value);
            key.Close();
        }



        public static bool IsRegeditItemExist()
        {
            string[] subkeyNames;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("SOFTWARE");
            //RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);  
            if (software != null)
            {
                subkeyNames = software.GetSubKeyNames();
                //取得该项下所有子项的名称的序列，并传递给预定的数组中  
                foreach (string keyName in subkeyNames)
                //遍历整个数组  
                {
                    if (keyName == "Materials")
                    //判断子项的名称  
                    {
                        hkml.Close();
                        return true;
                    }
                }
            }
            
            hkml.Close();
            return false;
        }

        public static bool IsRegeditKeyExit(string key)
        {
            string[] subkeyNames;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("SOFTWARE\\Materials");
            //RegistryKey software = hkml.OpenSubKey("SOFTWARE\\test", true);
            subkeyNames = software.GetValueNames();
            //取得该项下所有键值的名称的序列，并传递给预定的数组中
            foreach (string keyName in subkeyNames)
            {
                if (keyName == key) //判断键值的名称
                {
                    hkml.Close();
                    return true;
                }

            }
            hkml.Close();
            return false;
        }
    }
}
