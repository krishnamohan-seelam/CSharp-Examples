using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Unpacked
{
    class UnpackedMain
    {
        static void Main(string[] args)
        {
            Encoding ebcdic = Encoding.GetEncoding(37);

            byte[] dataChunk = new byte[80];
            StringBuilder dataBuilder = new StringBuilder();

            string fileName = @"F:\C#_Projects\zoned_packed\decdata.bin ";
            using (BinaryReader inputReader = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read),ebcdic))
            {
                inputReader.BaseStream.Seek(0, SeekOrigin.Begin);
                
                
                //Console.WriteLine("Source {0}", ebcdic.GetString(dataChunk));
                //Console.WriteLine("Converted {0}", Encoding.ASCII.GetString(convertedByte));
                //File Length was 320 = 80 *4
                int length = (int)inputReader.BaseStream.Length;
                Console.WriteLine("FileLength {0}", length);
                dataChunk = inputReader.ReadBytes(80);
                while (dataChunk.Length>0)
                {
                   
                    //ASCII conversion failed...lets us read as EBCDIC hex and check the valuess
                    //byte[] convertedByte = Encoding.Convert(ebcdic, Encoding.ASCII, dataChunk);
                    foreach (byte b in dataChunk)
                    {
                        dataBuilder.AppendFormat("{0:x2}", b);
                    }

                    Console.WriteLine("Hex String {0}", dataBuilder.ToString());
                    dataChunk = inputReader.ReadBytes(80);
                    dataBuilder.Clear();
                }
            }
            Console.ReadKey();
        }
    }
}
