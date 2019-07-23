using System;
using System.Collections.Generic;
using System.Text;

namespace CSMPMLib
{
    /// <summary>
    /// Способы загрузки иерархических данных
    /// </summary>
    public enum HierarchyLoadModesEnum
    {        
        /// <summary>
        /// Загружаются только корневые объекты
        /// </summary>
        RootElements,
        /// <summary>
        /// Загружается вся иерархия
        /// </summary>
        FullHierarchy
    }
}
