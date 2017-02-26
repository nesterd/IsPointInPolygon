using BusinessLogic.Helpers.Painters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PointInPolygon.Models
{
    public class PointViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage ="Необходимо задать координату Х")]
        [Range(0, 310, ErrorMessage = "Значение не должно быть больше 310")]
        public int X { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Необходимо задать координату Y")]
        [Range(0, 230, ErrorMessage = "Значение не должно быть больше 230")]
        public int Y { get; set; }
    }
}