using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Extensions
{
    public static class HtmlImageExtensions
    {
        public static string ToBase64Image(this IHtmlHelper htmlHelper, byte[] data, string fileName)
        {
            string base64String = Convert.ToBase64String(data);
            string imageType = fileName.Substring(fileName.LastIndexOf('.'));
            //<img alt="Embedded Image" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADIA..." />
            return $"data:image/{imageType};base64,{base64String}";
        }
    }
}
