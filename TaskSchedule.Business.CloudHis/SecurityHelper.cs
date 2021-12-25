using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TaskSchedule.Business.CloudHis
{
	public class SecurityHelper
	{
		// Token: 0x06000182 RID: 386 RVA: 0x0000B6DC File Offset: 0x000098DC
		public static string Encrypt(string original)
		{
			return SecurityHelper.Encrypt(original, "YangXiangYuan");
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000B6FC File Offset: 0x000098FC
		public static string Decrypt(string original)
		{
			return SecurityHelper.Decrypt(original, "YangXiangYuan", Encoding.Default);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000B720 File Offset: 0x00009920
		public static string Decrypt(string original, string key)
		{
			return SecurityHelper.Decrypt(original, key, Encoding.Default);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000B740 File Offset: 0x00009940
		public static string Decrypt(string original, Encoding encoding)
		{
			return SecurityHelper.Decrypt(original, "YangXiangYuan", encoding);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000B760 File Offset: 0x00009960
		public static string Encrypt(string original, string key)
		{
			byte[] bytes = Encoding.Default.GetBytes(original);
			byte[] bytes2 = Encoding.Default.GetBytes(key);
			return Convert.ToBase64String(SecurityHelper.Encrypt(bytes, bytes2));
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000B798 File Offset: 0x00009998
		public static string Decrypt(string encrypted, string key, Encoding encoding)
		{
			byte[] encrypted2 = Convert.FromBase64String(encrypted);
			byte[] bytes = Encoding.Default.GetBytes(key);
			byte[] array = SecurityHelper.Decrypt(encrypted2, bytes);
			return encoding.GetString(array, 0, array.Length);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000B7D0 File Offset: 0x000099D0
		public static byte[] MakeMD5(byte[] original)
		{
			MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			return md5CryptoServiceProvider.ComputeHash(original);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000B7F4 File Offset: 0x000099F4
		public static string GetMD5(string password)
		{
			MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] bytes = Encoding.UTF8.GetBytes(password);
			byte[] array = SecurityHelper.MakeMD5(bytes);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in array)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000B868 File Offset: 0x00009A68
		public static string GetSHA256(string Source)
		{
			SHA256Managed sha256Managed = new SHA256Managed();
			byte[] bytes = Encoding.UTF8.GetBytes(Source);
			byte[] inArray = sha256Managed.ComputeHash(bytes);
			return Convert.ToBase64String(inArray);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000B89C File Offset: 0x00009A9C
		public static byte[] Encrypt(byte[] original, byte[] key)
		{
			return new TripleDESCryptoServiceProvider
			{
				Key = SecurityHelper.MakeMD5(key),
				Mode = CipherMode.ECB
			}.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000B8DC File Offset: 0x00009ADC
		public static byte[] Decrypt(byte[] encrypted, byte[] key)
		{
			byte[] result = new byte[0];
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			tripleDESCryptoServiceProvider.Key = SecurityHelper.MakeMD5(key);
			tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
			try
			{
				result = tripleDESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000B93C File Offset: 0x00009B3C
		public static byte[] Encrypt(byte[] original)
		{
			byte[] bytes = Encoding.Default.GetBytes("YangXiangYuan");
			return SecurityHelper.Encrypt(original, bytes);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000B968 File Offset: 0x00009B68
		public static byte[] Decrypt(byte[] encrypted)
		{
			byte[] bytes = Encoding.Default.GetBytes("YangXiangYuan");
			return SecurityHelper.Decrypt(encrypted, bytes);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000B994 File Offset: 0x00009B94
		public static string DESEnCode(string pToEncrypt)
		{
			string s = "35fd0ec3";
			DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(pToEncrypt);
			descryptoServiceProvider.Key = Encoding.ASCII.GetBytes(s);
			descryptoServiceProvider.IV = Encoding.ASCII.GetBytes(s);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in memoryStream.ToArray())
			{
				stringBuilder.AppendFormat("{0:X2}", b);
			}
			stringBuilder.ToString();
			return stringBuilder.ToString();
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000BA68 File Offset: 0x00009C68
		public static string DESDeCode(string pToDecrypt)
		{
			string s = "35fd0ec3";
			DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] array = new byte[pToDecrypt.Length / 2];
			for (int i = 0; i < pToDecrypt.Length / 2; i++)
			{
				int num = Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 16);
				array[i] = (byte)num;
			}
			descryptoServiceProvider.Key = Encoding.ASCII.GetBytes(s);
			descryptoServiceProvider.IV = Encoding.ASCII.GetBytes(s);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			StringBuilder stringBuilder = new StringBuilder();
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000BB34 File Offset: 0x00009D34
		public static string DESEnCode(string pToEncrypt, string sKey)
		{
			DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(pToEncrypt);
			descryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
			descryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in memoryStream.ToArray())
			{
				stringBuilder.AppendFormat("{0:X2}", b);
			}
			stringBuilder.ToString();
			return stringBuilder.ToString();
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000BC00 File Offset: 0x00009E00
		public static string DESDeCode(string pToDecrypt, string sKey)
		{
			DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] array = new byte[pToDecrypt.Length / 2];
			for (int i = 0; i < pToDecrypt.Length / 2; i++)
			{
				int num = Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 16);
				array[i] = (byte)num;
			}
			descryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
			descryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			StringBuilder stringBuilder = new StringBuilder();
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}

		// Token: 0x04000093 RID: 147
		private const string _Key = "YangXiangYuan";
	}
}
