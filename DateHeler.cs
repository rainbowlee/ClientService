using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProtoBuf;
using ComponentAce.Compression.Libs.zlib;
namespace ClientService
{
  /// <summary>
  /// 数据操作辅助
  /// </summary>
  public class DataHelper
  {
    /// <summary>
    /// 字节数据拷贝
    /// </summary>
    /// <param name="copyTo">目标字节数组</param>
    /// <param name="offsetTo">目标字节数组的拷贝偏移量</param>
    /// <param name="copyFrom">源字节数组</param>
    /// <param name="offsetFrom">源字节数组的拷贝偏移量</param>
    /// <param name="count">拷贝的字节个数</param>
    public static void CopyBytes(byte[] copyTo, int offsetTo, byte[] copyFrom, int offsetFrom, int count)
    {
      /*for (int i = 0; i < count; i++)
      {
          copyTo[offsetTo + i] = copyFrom[offsetFrom + i];
      }*/
      Array.Copy(copyFrom, offsetFrom, copyTo, offsetTo, count);
    }

    /// <summary>
    /// 字节数据排序
    /// </summary>
    /// <param name="copyTo"></param>
    /// <param name="offsetTo"></param>
    /// <param name="count"></param>
    public static void SortBytes(byte[] bytesData, int offsetTo, int count)
    {
      byte temp = 0;
      byte[] keyBytes = BitConverter.GetBytes((int)30336092);
      for (int i = 0; i < keyBytes.Length; i++)
      {
        temp += keyBytes[i];
      }

      for (int x = offsetTo; x < (offsetTo + count); x++)
      {
        bytesData[x] ^= temp;
      }
    }

    /// <summary>
    /// 比较两个字节数组是否相同
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool CompBytes(byte[] left, byte[] right)
    {
      if (left.Length != right.Length)
      {
        return false;
      }

      bool ret = true;
      for (int i = 0; i < left.Length; i++)
      {
        if (left[i] != right[i])
        {
          ret = false;
          break;
        }
      }

      return ret;
    }

    /// <summary>
    /// 产生并填充随机数
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="offset"></param>
    /// <param name="count"></param>
    public static void RandBytes(byte[] buffer, int offset, int count)
    {
      long tick = DateTime.Now.Ticks;
      Random rnd = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
      for (int i = 0; i < count; i++)
      {
        buffer[offset + i] = (byte)rnd.Next(0, 0xFF);
      }
    }

    /// <summary>
    /// 将字节流转换为Hex编码的字符串(无分隔符号)
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    public static string Bytes2HexString(byte[] b)
    {
      int ch = 0;
      string ret = "";
      for (int i = 0; i < b.Length; i++)
      {
        ch = (b[i] & 0xFF);
        ret += ch.ToString("X2").ToUpper();
      }

      return ret;
    }

    /// <summary>
    /// 将Hex编码的字符串转换为字节流(无分隔符号)
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static byte[] HexString2Bytes(string s)
    {
      if (s.Length % 2 != 0) //非法的字符串
      {
        return null;
      }

      int b = 0;
      string hexstr = "";
      byte[] bytesData = new byte[s.Length / 2];
      for (int i = 0; i < s.Length / 2; i++)
      {
        hexstr = s.Substring(i * 2, 2);
        b = Int32.Parse(hexstr, System.Globalization.NumberStyles.HexNumber) & 0xFF;
        bytesData[i] = (byte)b;
      }

      return bytesData;
    }

    /// <summary>
    /// 将字节数据转为对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="bytesData"></param>
    /// <returns></returns>
    public static T BytesToObject<T>(byte[] bytesData, int offset, int length)
    {
      if (bytesData.Length == 0) return default(T);

      try
      {
        //zlib解压缩算法
        byte[] copyData = new byte[length];
        DataHelper.CopyBytes(copyData, 0, bytesData, offset, length);
        copyData = DataHelper.Uncompress(copyData);

        MemoryStream ms = new MemoryStream();
        ms.Write(copyData, 0, copyData.Length);
        ms.Position = 0;
        T t = Serializer.Deserialize<T>(ms);
        ms.Dispose();
        ms = null;
        return t;
      }
      catch (Exception ex)
      {
       // WriteExceptionLogEx(ex, "将字节数据转为对象发生异常:");
      }

      return default(T);
    }

    /// <summary>
    /// zlib 压缩算法
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static byte[] Compress(byte[] bytes)
    {
      using (var ms = new MemoryStream())
      {
        using (ZOutputStream outZStream = new ZOutputStream(ms, zlibConst.Z_BEST_SPEED))
        {
          outZStream.Write(bytes, 0, bytes.Length);
          outZStream.Flush();
        }

        return ms.ToArray();
      }
    }

    /// <summary>
    /// zlib 解压缩算法
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static byte[] Uncompress(byte[] bytes)
    {
      //小于2个字节肯定是非压缩的
      if (bytes.Length < 2)
      {
        return bytes;
      }

      //判断是否是压缩数据，是才执行解开压缩操作
      if (0x78 != bytes[0])
      {
        return bytes;
      }

      if (0x9C != bytes[1] && 0xDA != bytes[1])
      {
        return bytes;
      }

      using (var ms = new MemoryStream())
      {
        using (ZOutputStream outZStream = new ZOutputStream(ms))
        {
          outZStream.Write(bytes, 0, bytes.Length);
          outZStream.Flush();
        }

        return ms.ToArray();
      }
    }
  }
}
