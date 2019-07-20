using System;
using System.Collections.Generic;
using System.Text;

namespace CSMPMLib
{
    /// <summary>
    /// Статический класс с данными для инициализации
    /// </summary>
    public static class InitData
    {
        /// <summary>
        /// Возвращает список групп с/х культур с УИД
        /// </summary>
        public static List<CropGroup> GetCropGroups_Crops()
        {
            var data = new List<CropGroup>();
            // Зерновая группа
            var zernGroup = new CropGroup { CropGroupId = 1, CropGroupName = "Зерновая группа" };
            data.Add(zernGroup);

            var CropsZernGroup = new List<Crop>
            {
                new Crop { CropId=1,  CropName="Озимая пшеница",       WateringRate=800, IrrigationRate=2000, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=2,  CropName="Озимая рожь",          WateringRate=500, IrrigationRate=2500, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=3,  CropName="Озимый ячмень",        WateringRate=500, IrrigationRate=2500, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=4,  CropName="Яровая пшеница",       WateringRate=800, IrrigationRate=2100, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=5,  CropName="Овес",                 WateringRate=500, IrrigationRate=1500, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=6,  CropName="Ячмень",               WateringRate=600, IrrigationRate=2400, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=7,  CropName="Кукуруза  на зерно",   WateringRate=800, IrrigationRate=3400, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=8,  CropName="Просо",                WateringRate=800, IrrigationRate=1600, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=9,  CropName="Сорго",                WateringRate=600, IrrigationRate=3000, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=10, CropName="Рис",                  WateringRate=800, IrrigationRate=8000, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=11, CropName="Гречиха",              WateringRate=500, IrrigationRate=2500, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=12, CropName="Чечевица",             WateringRate=600, IrrigationRate=1800, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=13, CropName="Фасоль",               WateringRate=600, IrrigationRate=1800, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=14, CropName="Горох",                WateringRate=600, IrrigationRate=1800, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=15, CropName="Бобы",                 WateringRate=700, IrrigationRate=1600, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=16, CropName="Яровой ячмень",        WateringRate=700, IrrigationRate=1900, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=17, CropName="Прочие зерновые",      WateringRate=700, IrrigationRate=1600, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=18, CropName="Овес зерновой",        WateringRate=200, IrrigationRate=400,  CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropId=19, CropName="Зерновая рожь",        WateringRate=0,   IrrigationRate=0,    CropGroupId=1, CropGroup=zernGroup}
            };
            zernGroup.Crops = CropsZernGroup;

            // Овощная группа
            var ovoshnGroup = new CropGroup { CropGroupId = 2, CropGroupName = "Овощная группа" };
            data.Add(ovoshnGroup);

            var CropsOvoshnGroup = new List<Crop>
            {
                new Crop { CropId=20, CropName="Капуста",           WateringRate=600, IrrigationRate=6000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropId=21, CropName="Помидоры",          WateringRate=500, IrrigationRate=4000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropId=22, CropName="Баклажаны",         WateringRate=500, IrrigationRate=5000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropId=23, CropName="Перец",             WateringRate=500, IrrigationRate=5000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropId=24, CropName="Огурцы",            WateringRate=500, IrrigationRate=4000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropId=25, CropName="Лук",               WateringRate=500, IrrigationRate=3000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropId=26, CropName="Свекла столовая",   WateringRate=600, IrrigationRate=3600, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropId=27, CropName="Морковь столовая",  WateringRate=600, IrrigationRate=3600, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropId=28, CropName="Петрушка",          WateringRate=600, IrrigationRate=3600, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropId=29, CropName="Пастернак",         WateringRate=600, IrrigationRate=3600, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropId=30, CropName="Картофель",         WateringRate=700, IrrigationRate=2400, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropId=31, CropName="Овощи",             WateringRate=600, IrrigationRate=4000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropId=32, CropName="Прочие овощные",    WateringRate=600, IrrigationRate=4000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropId=33, CropName="Картофель поздний", WateringRate=600, IrrigationRate=4000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropId=34, CropName="Бахча",             WateringRate=600, IrrigationRate=4000, CropGroupId=2, CropGroup=ovoshnGroup}
            };
            ovoshnGroup.Crops = CropsOvoshnGroup;

            // Техническая группа
            var technGroup = new CropGroup { CropGroupId = 3, CropGroupName = "Техническая группа" };
            data.Add(technGroup);

            var CropsTechGroup = new List<Crop>
            {
                new Crop { CropId=35, CropName="Подсолнечник",        WateringRate=800, IrrigationRate=2400, CropGroupId=3, CropGroup=technGroup},
                new Crop { CropId=36, CropName="Соя",                 WateringRate=700, IrrigationRate=2800, CropGroupId=3, CropGroup=technGroup},
                new Crop { CropId=37, CropName="Озимый рапс",         WateringRate=500, IrrigationRate=1500, CropGroupId=3, CropGroup=technGroup},
                new Crop { CropId=38, CropName="Сахарная свекла",     WateringRate=600, IrrigationRate=3600, CropGroupId=3, CropGroup=technGroup},
                new Crop { CropId=39, CropName="Кориандр",            WateringRate=500, IrrigationRate=1000, CropGroupId=3, CropGroup=technGroup},
                new Crop { CropId=40, CropName="Цветы",               WateringRate=500, IrrigationRate=1000, CropGroupId=3, CropGroup=technGroup},
                new Crop { CropId=41, CropName="Прочие технические",  WateringRate=600, IrrigationRate=2400, CropGroupId=3, CropGroup=technGroup}
            };
            technGroup.Crops = CropsTechGroup;


            // Кормовая группа
            var kormGroup = new CropGroup { CropGroupId = 4, CropGroupName = "Кормовая группа" };
            data.Add(kormGroup);

            var CropsKormGroup = new List<Crop>
            {
                new Crop { CropId=42, CropName="Свекла",                        WateringRate=600, IrrigationRate=3600, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=43, CropName="Морковь",                       WateringRate=600, IrrigationRate=2400, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=44, CropName="Кукуруза на силос",             WateringRate=800, IrrigationRate=2600, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=45, CropName="Подсолнечник на силос",         WateringRate=500, IrrigationRate=1500, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=46, CropName="Сорго",                         WateringRate=500, IrrigationRate=2500, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=47, CropName="Люцерна",                       WateringRate=700, IrrigationRate=4700, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=48, CropName="Эспарцет",                      WateringRate=600, IrrigationRate=3000, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=49, CropName="Донник",                        WateringRate=700, IrrigationRate=3500, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=50, CropName="Суданская трава",               WateringRate=500, IrrigationRate=2500, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=51, CropName="Рожь на зеленый корм",          WateringRate=500, IrrigationRate=1500, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=52, CropName="Тыква",                         WateringRate=400, IrrigationRate=400,  CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=53, CropName="Дыня",                          WateringRate=400, IrrigationRate=400,  CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=54, CropName="Арбуз",                         WateringRate=400, IrrigationRate=400,  CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=55, CropName="Брюква",                        WateringRate=600, IrrigationRate=3600, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=56, CropName="Турнепс",                       WateringRate=500, IrrigationRate=3000, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=57, CropName="Клевер",                        WateringRate=500, IrrigationRate=4000, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=58, CropName="Многолетние травы",             WateringRate=900, IrrigationRate=4200, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=59, CropName="Однолетние травы",              WateringRate=900, IrrigationRate=4200, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=60, CropName="Прочие кормовые",               WateringRate=900, IrrigationRate=3600, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=61, CropName="Многолетние травы на зел корм", WateringRate=900, IrrigationRate=4200, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=62, CropName="Однолетние травы на зел корм",  WateringRate=900, IrrigationRate=4200, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=63, CropName="Однолетние травы на сено",      WateringRate=900, IrrigationRate=3000, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=64, CropName="Многлетние травы на сено",      WateringRate=900, IrrigationRate=4000, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=65, CropName="Кормовые корнеплоды",           WateringRate=600, IrrigationRate=3600, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropId=66, CropName="Многолетние травы на семена",   WateringRate=500, IrrigationRate=4000, CropGroupId=4, CropGroup=kormGroup}
            };
            kormGroup.Crops = CropsKormGroup;

            //Прочие
            var prochieGroup = new CropGroup { CropGroupId = 5, CropGroupName = "Прочие" };
            data.Add(prochieGroup);            

            var CropsProchieGroup = new List<Crop>
            {                
                new Crop { CropId=68, CropName="Многолетние насаждения",       WateringRate=800,  IrrigationRate=1800, CropGroupId=5, CropGroup=prochieGroup},
                new Crop { CropId=69, CropName="Приусадебные огороды",         WateringRate=600,  IrrigationRate=4800, CropGroupId=5, CropGroup=prochieGroup},
                new Crop { CropId=70, CropName="Администрация",                WateringRate=700,  IrrigationRate=700,  CropGroupId=5, CropGroup=prochieGroup},
                new Crop { CropId=71, CropName="Другие (фермеры)",             WateringRate=700,  IrrigationRate=700,  CropGroupId=5, CropGroup=prochieGroup},
                new Crop { CropId=72, CropName="Пары",                         WateringRate=1000, IrrigationRate=1000, CropGroupId=5, CropGroup=prochieGroup},
                new Crop { CropId=73, CropName="Прочие",                       WateringRate=1200, IrrigationRate=2500, CropGroupId=5, CropGroup=prochieGroup}
            };
            prochieGroup.Crops = CropsProchieGroup;

            return data;
        }

        /// <summary>
        /// Возвращает список групп с/х культур без УИД
        /// </summary>
        public static List<CropGroup> GetCropGroups_Crops_WithoutIds()
        {
            var data = new List<CropGroup>();
            // Зерновая группа
            var zernGroup = new CropGroup { CropGroupName = "Зерновая группа" };
            data.Add(zernGroup);

            var CropsZernGroup = new List<Crop>
            {
                new Crop { CropName="Озимая пшеница",       WateringRate=800, IrrigationRate=2000, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Озимая рожь",          WateringRate=500, IrrigationRate=2500, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Озимый ячмень",        WateringRate=500, IrrigationRate=2500, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Яровая пшеница",       WateringRate=800, IrrigationRate=2100, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Овес",                 WateringRate=500, IrrigationRate=1500, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Ячмень",               WateringRate=600, IrrigationRate=2400, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Кукуруза  на зерно",   WateringRate=800, IrrigationRate=3400, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Просо",                WateringRate=800, IrrigationRate=1600, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Сорго",                WateringRate=600, IrrigationRate=3000, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Рис",                  WateringRate=800, IrrigationRate=8000, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Гречиха",              WateringRate=500, IrrigationRate=2500, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Чечевица",             WateringRate=600, IrrigationRate=1800, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Фасоль",               WateringRate=600, IrrigationRate=1800, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Горох",                WateringRate=600, IrrigationRate=1800, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Бобы",                 WateringRate=700, IrrigationRate=1600, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Яровой ячмень",        WateringRate=700, IrrigationRate=1900, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Прочие зерновые",      WateringRate=700, IrrigationRate=1600, CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Овес зерновой",        WateringRate=200, IrrigationRate=400,  CropGroupId=1, CropGroup=zernGroup},
                new Crop { CropName="Зерновая рожь",        WateringRate=0,   IrrigationRate=0,    CropGroupId=1, CropGroup=zernGroup}
            };
            zernGroup.Crops = CropsZernGroup;
                        
            // Овощная группа
            var ovoshnGroup = new CropGroup { CropGroupName = "Овощная группа" };
            data.Add(ovoshnGroup);

            var CropsOvoshnGroup = new List<Crop>
            {
                new Crop { CropName="Капуста",           WateringRate=600, IrrigationRate=6000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropName="Помидоры",          WateringRate=500, IrrigationRate=4000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropName="Баклажаны",         WateringRate=500, IrrigationRate=5000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropName="Перец",             WateringRate=500, IrrigationRate=5000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropName="Огурцы",            WateringRate=500, IrrigationRate=4000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropName="Лук",               WateringRate=500, IrrigationRate=3000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropName="Свекла столовая",   WateringRate=600, IrrigationRate=3600, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropName="Морковь столовая",  WateringRate=600, IrrigationRate=3600, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropName="Петрушка",          WateringRate=600, IrrigationRate=3600, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropName="Пастернак",         WateringRate=600, IrrigationRate=3600, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropName="Картофель",         WateringRate=700, IrrigationRate=2400, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropName="Овощи",             WateringRate=600, IrrigationRate=4000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropName="Прочие овощные",    WateringRate=600, IrrigationRate=4000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropName="Картофель поздний", WateringRate=600, IrrigationRate=4000, CropGroupId=2, CropGroup=ovoshnGroup},
                new Crop { CropName="Бахча",             WateringRate=600, IrrigationRate=4000, CropGroupId=2, CropGroup=ovoshnGroup}
            };
            ovoshnGroup.Crops = CropsOvoshnGroup;

            // Техническая группа
            var technGroup = new CropGroup { CropGroupName = "Техническая группа" };
            data.Add(technGroup);

            var CropsTechGroup = new List<Crop>
            {
                new Crop { CropName="Подсолнечник",        WateringRate=800, IrrigationRate=2400, CropGroupId=3, CropGroup=technGroup},
                new Crop { CropName="Соя",                 WateringRate=700, IrrigationRate=2800, CropGroupId=3, CropGroup=technGroup},
                new Crop { CropName="Озимый рапс",         WateringRate=500, IrrigationRate=1500, CropGroupId=3, CropGroup=technGroup},
                new Crop { CropName="Сахарная свекла",     WateringRate=600, IrrigationRate=3600, CropGroupId=3, CropGroup=technGroup},
                new Crop { CropName="Кориандр",            WateringRate=500, IrrigationRate=1000, CropGroupId=3, CropGroup=technGroup},
                new Crop { CropName="Цветы",               WateringRate=500, IrrigationRate=1000, CropGroupId=3, CropGroup=technGroup},
                new Crop { CropName="Прочие технические",  WateringRate=600, IrrigationRate=2400, CropGroupId=3, CropGroup=technGroup}
            };
            technGroup.Crops = CropsTechGroup;


            // Кормовая группа
            var kormGroup = new CropGroup { CropGroupName = "Кормовая группа" };
            data.Add(kormGroup);

            var CropsKormGroup = new List<Crop>
            {
                new Crop { CropName="Свекла",                        WateringRate=600, IrrigationRate=3600, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Морковь",                       WateringRate=600, IrrigationRate=2400, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Кукуруза на силос",             WateringRate=800, IrrigationRate=2600, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Подсолнечник на силос",         WateringRate=500, IrrigationRate=1500, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Сорго",                         WateringRate=500, IrrigationRate=2500, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Люцерна",                       WateringRate=700, IrrigationRate=4700, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Эспарцет",                      WateringRate=600, IrrigationRate=3000, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Донник",                        WateringRate=700, IrrigationRate=3500, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Суданская трава",               WateringRate=500, IrrigationRate=2500, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Рожь на зеленый корм",          WateringRate=500, IrrigationRate=1500, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Тыква",                         WateringRate=400, IrrigationRate=400,  CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Дыня",                          WateringRate=400, IrrigationRate=400,  CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Арбуз",                         WateringRate=400, IrrigationRate=400,  CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Брюква",                        WateringRate=600, IrrigationRate=3600, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Турнепс",                       WateringRate=500, IrrigationRate=3000, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Клевер",                        WateringRate=500, IrrigationRate=4000, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Многолетние травы",             WateringRate=900, IrrigationRate=4200, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Однолетние травы",              WateringRate=900, IrrigationRate=4200, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Прочие кормовые",               WateringRate=900, IrrigationRate=3600, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Многолетние травы на зел корм", WateringRate=900, IrrigationRate=4200, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Однолетние травы на зел корм",  WateringRate=900, IrrigationRate=4200, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Однолетние травы на сено",      WateringRate=900, IrrigationRate=3000, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Многлетние травы на сено",      WateringRate=900, IrrigationRate=4000, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Кормовые корнеплоды",           WateringRate=600, IrrigationRate=3600, CropGroupId=4, CropGroup=kormGroup},
                new Crop { CropName="Многолетние травы на семена",   WateringRate=500, IrrigationRate=4000, CropGroupId=4, CropGroup=kormGroup}
            };
            kormGroup.Crops = CropsKormGroup;

            //Прочие
            var prochieGroup = new CropGroup { CropGroupName = "Прочие" };
            data.Add(prochieGroup);

            var CropsProchieGroup = new List<Crop>
            {
                new Crop { CropName="Многолетние насаждения",       WateringRate=800,  IrrigationRate=1800, CropGroupId=5, CropGroup=prochieGroup},
                new Crop { CropName="Приусадебные огороды",         WateringRate=600,  IrrigationRate=4800, CropGroupId=5, CropGroup=prochieGroup},
                new Crop { CropName="Администрация",                WateringRate=700,  IrrigationRate=700,  CropGroupId=5, CropGroup=prochieGroup},
                new Crop { CropName="Другие (фермеры)",             WateringRate=700,  IrrigationRate=700,  CropGroupId=5, CropGroup=prochieGroup},
                new Crop { CropName="Пары",                         WateringRate=1000, IrrigationRate=1000, CropGroupId=5, CropGroup=prochieGroup},
                new Crop { CropName="Прочие",                       WateringRate=1200, IrrigationRate=2500, CropGroupId=5, CropGroup=prochieGroup}
            };
            prochieGroup.Crops = CropsProchieGroup;

            return data;
        }
    }
}
