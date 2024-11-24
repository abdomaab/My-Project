using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Extensions
{
    public static class ImageHandler
    {
        public static async Task<byte[]> ImageConverterAsync(IFormFile image)
        {
            if (image == null)
                return null;

            using var dataStream = new MemoryStream();
            await image.CopyToAsync(dataStream);
            return dataStream.ToArray();
        }
    }
}
