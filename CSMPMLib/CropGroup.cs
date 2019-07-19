//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSMPMLib
{
    /// <summary>
    /// Группа сельскохозяйственных культур
    /// </summary>
    public class CropGroup
    {
        /// <summary>
        /// УИД группы с/х культур
        /// </summary>
        public int CropGroupId { get; set; }

        /// <summary>
        /// Наименование группы с/х культур
        /// </summary>        
        public string CropGroupName { get; set; }

        /// <summary>
        /// Список с/х культур
        /// </summary>
        public List<Crop> Crops { get; set; } = new List<Crop>();

        /// <summary>
        /// Преобразовывает json-строку в объект List<CropGroup>
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        //public static List<CropGroup> DeserializeJsonList(string jsonString)
        //{
        //    var cropGroups = JsonConvert.DeserializeObject<List<CropGroup>>(jsonString);
        //    return cropGroups;
        //}

        /// <summary>
        /// Преобразовывает json-строку в объект CropGroup
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        //public static CropGroup DeserializeJson(string jsonString)
        //{
        //    var cropGroup = JsonConvert.DeserializeObject<CropGroup>(jsonString);
        //    return cropGroup;
        //}
    }
}
