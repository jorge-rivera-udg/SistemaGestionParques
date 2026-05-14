using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDemo.utils
{
    public class ImagenUtils
    {
        private static object bytes;

        public static Image ConvertirBlobAImagen(byte[] blob)
        {
            if (blob.Length == 0) return null;
            try
            {
                using (MemoryStream ms = new MemoryStream(blob))
                {
                    ms.Position = 0;
                    return Image.FromStream(ms);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid parameter: {ex.Message}");
                return null;
            }
        }

        public static Image ConvertirByteArrayAImage(byte[] bytes)
        {
            if (bytes.Length == 0) return null;
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid parameter: {ex.Message}");
                return null;
            }
        }


        public static byte[] ConvertirImagenABlob(Image imagen)
        {
            if (imagen == null) return new byte[0];
            using (MemoryStream ms = new MemoryStream())
            {
                imagen.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static string normalizeBase64String(string base64String)
        {
            while (base64String.Length % 4 != 0)
            {
                base64String += "="; // Add padding
            }
            return base64String;
        }


    }
}
