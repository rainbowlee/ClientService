using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
  class NewCrypt
  {

    //private static readonly ILog log = log4net.LogManager.GetLogger (typeof(NewCrypt));

    private static NewCrypt Instance = new NewCrypt("12345678JKL#%$^&@*&^%");
    public static NewCrypt getInstance()
    {
      return Instance;
    }
    BlowfishEngine _crypt;
    BlowfishEngine _decrypt;

    public NewCrypt(byte[] blowfishKey)
    {
      _crypt = new BlowfishEngine();
      _crypt.init(true, blowfishKey);
      _decrypt = new BlowfishEngine();
      _decrypt.init(false, blowfishKey);
    }

    public NewCrypt(String key) : this(System.Text.Encoding.UTF8.GetBytes(key))
    {
    }
    //计算一个数据长度，填充数据后的长度。
    public static int getAfterPaddingLength(int count)
    {
      return count + (8 - (count % 8));
    }

    public static bool verifyChecksum(byte[] raw)
    {
      return NewCrypt.verifyChecksum(raw, 0, raw.Length);
    }

    public static bool verifyChecksum(byte[] raw, int offset, int size)
    {
      // check if size is multiple of 4 and if there is more then only the checksum
      if (((size & 3) != 0) || (size <= 4))
      {
        return false;
      }

      long chksum = 0;
      int count = size - 4;
      long check = -1;
      int i;

      for (i = offset; i < count; i += 4)
      {
        check = raw[i] & 0xff;
        check |= (raw[i + 1] << 8) & 0xff00;
        check |= (raw[i + 2] << 0x10) & 0xff0000;
        check |= (raw[i + 3] << 0x18) & 0xff000000;

        chksum ^= check;
      }

      check = raw[i] & 0xff;
      check |= (raw[i + 1] << 8) & 0xff00;
      check |= (raw[i + 2] << 0x10) & 0xff0000;
      check |= (raw[i + 3] << 0x18) & 0xff000000;

      return check == chksum;
    }

    public static void appendChecksum(byte[] raw)
    {
      NewCrypt.appendChecksum(raw, 0, raw.Length);
    }

    public static void appendChecksum(byte[] raw, int offset, int size)
    {
      long chksum = 0;
      int count = size - 4;
      long ecx;
      int i;

      for (i = offset; i < count; i += 4)
      {
        ecx = raw[i] & 0xff;
        ecx |= (raw[i + 1] << 8) & 0xff00;
        ecx |= (raw[i + 2] << 0x10) & 0xff0000;
        ecx |= (raw[i + 3] << 0x18) & 0xff000000;

        chksum ^= ecx;
      }

      ecx = raw[i] & 0xff;
      ecx |= (raw[i + 1] << 8) & 0xff00;
      ecx |= (raw[i + 2] << 0x10) & 0xff0000;
      ecx |= (raw[i + 3] << 0x18) & 0xff000000;

      raw[i] = (byte)(chksum & 0xff);
      raw[i + 1] = (byte)((chksum >> 0x08) & 0xff);
      raw[i + 2] = (byte)((chksum >> 0x10) & 0xff);
      raw[i + 3] = (byte)((chksum >> 0x18) & 0xff);
    }

    /**
     * Packet is first XOR encoded with <code>key</code> Then, the last 4 bytes are overwritten with the the XOR "key". Thus this assume that there is enough room for the key to fit without overwriting data.
     * @param raw The raw bytes to be encrypted
     * @param key The 4 bytes (int) XOR key
     */
    public static void encXORPass(byte[] raw, int key)
    {
      NewCrypt.encXORPass(raw, 0, raw.Length, key);
    }

    /**
     * Packet is first XOR encoded with <code>key</code> Then, the last 4 bytes are overwritten with the the XOR "key". Thus this assume that there is enough room for the key to fit without overwriting data.
     * @param raw The raw bytes to be encrypted
     * @param offset The begining of the data to be encrypted
     * @param size Length of the data to be encrypted
     * @param key The 4 bytes (int) XOR key
     */
    public static void encXORPass(byte[] raw, int offset, int size, int key)
    {
      int stop = size - 8;
      int pos = 4 + offset;
      int edx;
      int ecx = key; // Initial xor key

      while (pos < stop)
      {
        edx = (raw[pos] & 0xFF);
        edx |= (raw[pos + 1] & 0xFF) << 8;
        edx |= (raw[pos + 2] & 0xFF) << 16;
        edx |= (raw[pos + 3] & 0xFF) << 24;

        ecx += edx;

        edx ^= ecx;

        raw[pos++] = (byte)(edx & 0xFF);
        raw[pos++] = (byte)((edx >> 8) & 0xFF);
        raw[pos++] = (byte)((edx >> 16) & 0xFF);
        raw[pos++] = (byte)((edx >> 24) & 0xFF);
      }

      raw[pos++] = (byte)(ecx & 0xFF);
      raw[pos++] = (byte)((ecx >> 8) & 0xFF);
      raw[pos++] = (byte)((ecx >> 16) & 0xFF);
      raw[pos++] = (byte)((ecx >> 24) & 0xFF);
    }

    public byte[] decrypt(byte[] raw)
    {
      byte[] result = new byte[raw.Length];
      int count = raw.Length / 8;

      for (int i = 0; i < count; i++)
      {
        _decrypt.processBlock(raw, i * 8, result, i * 8);
      }

      return result;
    }

    public void decrypt(byte[] raw, int offset, int size)
    {
      byte[] result = new byte[size];
      int count = size / 8;

      for (int i = 0; i < count; i++)
      {
        _decrypt.processBlock(raw, offset + (i * 8), result, i * 8);
      }

      Array.Copy(result, 0, raw, offset, size);
    }

    // pkcs5padding

    public static int Padding(byte[] raw, int rawBeginIndex, int count)
    {
      byte nPadding = (byte)(8 - (count % 8));

      if (raw.Length < rawBeginIndex + count + nPadding)
      {
        return -1;
      }

      for (int i = rawBeginIndex + count; i < rawBeginIndex + count + nPadding; i++)
      {
        raw[i] = nPadding;
      }
      return count + nPadding;
    }


    public byte[] crypt(byte[] raw)
    {

      int count = raw.Length / 8;
      byte[] result = new byte[raw.Length];

      for (int i = 0; i < count; i++)
      {
        _crypt.processBlock(raw, i * 8, result, i * 8);
      }

      return result;
    }

    public void crypt(byte[] raw, int offset, int size)
    {
      int count = size / 8;
      byte[] result = new byte[size];

      for (int i = 0; i < count; i++)
      {
        _crypt.processBlock(raw, offset + (i * 8), result, i * 8);
      }

      Array.Copy(result, 0, raw, offset, size);
    }

  }
}
