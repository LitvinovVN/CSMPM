﻿using System;
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
        /// Возвращает справочник видов деятельности
        /// </summary>
        /// <returns></returns>
        public static List<TypeOfActivity> GetTypeOfActivities()
        {
            var types = new List<TypeOfActivity>();

            types.Add(new TypeOfActivity { TypeOfActivityId = 1, TypeOfActivityName = "Мелиорация", RootTypeOfActivityId = null });
            types.Add(new TypeOfActivity { TypeOfActivityId = 2, TypeOfActivityName = "Использование оросительных систем", RootTypeOfActivityId = 1 });
            types.Add(new TypeOfActivity { TypeOfActivityId = 3, TypeOfActivityName = "Обслуживание оросительных систем", RootTypeOfActivityId = 1 });

            return types;
        }

        /// <summary>
        /// Возвращает список причин невыполнения чего-либо
        /// </summary>
        /// <returns></returns>
        public static List<Reason> GetReasons()
        {
            var reasons = new List<Reason>();

            reasons.Add(new Reason { ReasonId = 1, ReasonName = "Реконструкция" } );
            reasons.Add(new Reason { ReasonId = 2, ReasonName = "Мелиополя" });
            reasons.Add(new Reason { ReasonId = 3, ReasonName = "Близкий УГВ" });
            reasons.Add(new Reason { ReasonId = 4, ReasonName = "Залежи" });
            reasons.Add(new Reason { ReasonId = 5, ReasonName = "Пары" });
            reasons.Add(new Reason { ReasonId = 6, ReasonName = "Раскорчевка" });
            reasons.Add(new Reason { ReasonId = 7, ReasonName = "Неиспр. в/х сети" });
            reasons.Add(new Reason { ReasonId = 8, ReasonName = "Другие причины" });
            reasons.Add(new Reason { ReasonId = 9, ReasonName = "Капит. планиров." });
            reasons.Add(new Reason { ReasonId = 10, ReasonName = "Неисправ НС" });
            reasons.Add(new Reason { ReasonId = 11, ReasonName = "Недостат. воды в источнике" });
            reasons.Add(new Reason { ReasonId = 12, ReasonName = "Отсуствие исправн.  ДМ" });            

            return reasons;
        }


        /// <summary>
        /// Возвращает список организаций
        /// </summary>
        /// <returns></returns>
        public static List<Organization> GetOrganizations()
        {
            var organizations = new List<Organization>();
            organizations.Add(new Organization { OrganizationId = 1,
                OrganizationName = "ФГБУ «Ростовмелиоводхоз»",
                ParentOrganizationId = null,
                OrganizationToTypeOfActivities = new List<OrganizationToTypeOfActivity> { new OrganizationToTypeOfActivity { TypeOfActivityId = 3 } },
                //OrganizationToIrrigationSystems = new List<OrganizationToIrrigationSystem>
                //{
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 1, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 2, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 3, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 4, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 5, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 6, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 7, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 8, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 9, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 10, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 11, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 12, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 13, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 14, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 15, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 16, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 17, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 18, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 19, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 20, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 21, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 22, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 23, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 24, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 25, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 26, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 27, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 28, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 29, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 30, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 31, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 32, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 33, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 34, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 35, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 36, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 37, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 38, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 39, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 40, OrganizationToTypeOfActivityId = 1 }
                //},
                OrganizationDocumentation = new List<OrganizationDocumentationItem>
                {
                    new OrganizationDocumentationItem
                    {
                        OrganizationDocumentationItemName = "Документация по мелиорации",
                        OrganizationDocumentationPlans = new List<OrganizationDocumentationPlans>
                        {
                            new OrganizationDocumentationPlans
                            {
                                OrganizationDocumentationPlansName = "Планы поливов",
                                IrrigationPlans = new List<IrrigationPlan>
                                {
                                    new IrrigationPlan
                                    {
                                        Year = 2019,
                                        IrrigationPlanItems = new List<IrrigationPlanItem>
                                        {
                                            new IrrigationPlanItem
                                            {
                                                IrrigationSystemId = 12,
                                                LandAreaOnBeginningOfYear = 1000,
                                                LandAreaAgriculturalUse = 950,
                                                LandAreaIncludedInIrrigationPlan = 500,
                                                LandAreaSowing =750,
                                                IrrigationPlanItem_CropSowingAndIrrigations = new List<IrrigationPlanItem_CropSowingAndIrrigation>
                                                {
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 2, Sowing = 150, Irrigation = 100 },
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 3, Sowing = 250, Irrigation = 220 }
                                                },
                                                IrrigationPlanItem_LandAreaNotIrrigationReasons = new List<IrrigationPlanItem_LandAreaNotIrrigationReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 3,
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 30,
                                                        ReasonId = 4
                                                    }
                                                },
                                                IrrigationPlanItem_LandAreaNotAgriculturalReasons = new List<IrrigationPlanItem_LandAreaNotAgriculturalReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 4
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 80,
                                                        ReasonId = 5
                                                    }
                                                }
                                            },
                                            new IrrigationPlanItem
                                            {
                                                IrrigationSystemId = 27,
                                                LandAreaOnBeginningOfYear = 1000,
                                                LandAreaAgriculturalUse = 950,
                                                LandAreaIncludedInIrrigationPlan = 500,
                                                LandAreaSowing =750,
                                                IrrigationPlanItem_CropSowingAndIrrigations = new List<IrrigationPlanItem_CropSowingAndIrrigation>
                                                {
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 2, Sowing = 150, Irrigation = 100 },
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 3, Sowing = 250, Irrigation = 220 }
                                                },
                                                IrrigationPlanItem_LandAreaNotIrrigationReasons = new List<IrrigationPlanItem_LandAreaNotIrrigationReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 3,
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 30,
                                                        ReasonId = 4
                                                    }
                                                },
                                                IrrigationPlanItem_LandAreaNotAgriculturalReasons = new List<IrrigationPlanItem_LandAreaNotAgriculturalReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 4
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 80,
                                                        ReasonId = 5
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
            organizations.Add(new Organization
            {
                OrganizationId = 2,
                OrganizationName = "Азовский филиал ФГБУ «Ростовмелиоводхоз»",
                ParentOrganizationId = 1,
                OrganizationToTypeOfActivities = new List<OrganizationToTypeOfActivity>
                {
                    new OrganizationToTypeOfActivity
                    {
                        TypeOfActivityId = 3,
                        OrganizationToTypeOfActivitiesToIrrigationSystems = new List<OrganizationToTypeOfActivitiesToIrrigationSystem>
                        {
                            new OrganizationToTypeOfActivitiesToIrrigationSystem { IrrigationSystemId = 12 }
                        }
                    }
                },
                //OrganizationToIrrigationSystems = new List<OrganizationToIrrigationSystem>
                //{
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 1, OrganizationToTypeOfActivityId = 1 },
                //    new OrganizationToIrrigationSystem { IrrigationSystemId = 12, OrganizationToTypeOfActivityId = 1 }
                //},
                OrganizationDocumentation = new List<OrganizationDocumentationItem>
                {
                    new OrganizationDocumentationItem
                    {
                        OrganizationDocumentationItemName = "Документация по мелиорации",
                        OrganizationDocumentationPlans = new List<OrganizationDocumentationPlans>
                        {
                            new OrganizationDocumentationPlans
                            {
                                OrganizationDocumentationPlansName = "Планы поливов",
                                IrrigationPlans = new List<IrrigationPlan>
                                {
                                    new IrrigationPlan
                                    {
                                        Year = 2019,
                                        IrrigationPlanItems = new List<IrrigationPlanItem>
                                        {
                                            new IrrigationPlanItem
                                            {
                                                IrrigationSystemId = 12,
                                                LandAreaOnBeginningOfYear = 1000,
                                                LandAreaAgriculturalUse = 950,
                                                LandAreaIncludedInIrrigationPlan = 500,
                                                LandAreaSowing =750,
                                                IrrigationPlanItem_CropSowingAndIrrigations = new List<IrrigationPlanItem_CropSowingAndIrrigation>
                                                {
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 2, Sowing = 150, Irrigation = 100 },
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 3, Sowing = 250, Irrigation = 220 }
                                                },
                                                IrrigationPlanItem_LandAreaNotIrrigationReasons = new List<IrrigationPlanItem_LandAreaNotIrrigationReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 3, 
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 30,
                                                        ReasonId = 4
                                                    }
                                                },
                                                IrrigationPlanItem_LandAreaNotAgriculturalReasons = new List<IrrigationPlanItem_LandAreaNotAgriculturalReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 4
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 80,
                                                        ReasonId = 5
                                                    }
                                                }
                                            },
                                            new IrrigationPlanItem
                                            {
                                                IrrigationSystemId = 27,
                                                LandAreaOnBeginningOfYear = 1000,
                                                LandAreaAgriculturalUse = 950,
                                                LandAreaIncludedInIrrigationPlan = 500,
                                                LandAreaSowing =750,
                                                IrrigationPlanItem_CropSowingAndIrrigations = new List<IrrigationPlanItem_CropSowingAndIrrigation>
                                                {
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 2, Sowing = 150, Irrigation = 100 },
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 3, Sowing = 250, Irrigation = 220 }
                                                },
                                                IrrigationPlanItem_LandAreaNotIrrigationReasons = new List<IrrigationPlanItem_LandAreaNotIrrigationReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 3,
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 30,
                                                        ReasonId = 4
                                                    }
                                                },
                                                IrrigationPlanItem_LandAreaNotAgriculturalReasons = new List<IrrigationPlanItem_LandAreaNotAgriculturalReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 4
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 80,
                                                        ReasonId = 5
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
            organizations.Add(new Organization { OrganizationId = 3,
                OrganizationName = "Аксайский филиал ФГБУ «Ростовмелиоводхоз»",
                ParentOrganizationId = 1,                
                OrganizationToTypeOfActivities = new List<OrganizationToTypeOfActivity>
                {
                    new OrganizationToTypeOfActivity
                    {
                        TypeOfActivityId = 3,
                        OrganizationToTypeOfActivitiesToIrrigationSystems = new List<OrganizationToTypeOfActivitiesToIrrigationSystem>
                        {
                            new OrganizationToTypeOfActivitiesToIrrigationSystem { IrrigationSystemId = 28 }
                        }
                    }
                },
                OrganizationDocumentation = new List<OrganizationDocumentationItem>
                {
                    new OrganizationDocumentationItem
                    {
                        OrganizationDocumentationItemName = "Документация по мелиорации",
                        OrganizationDocumentationPlans = new List<OrganizationDocumentationPlans>
                        {
                            new OrganizationDocumentationPlans
                            {
                                OrganizationDocumentationPlansName = "Планы поливов",
                                IrrigationPlans = new List<IrrigationPlan>
                                {
                                    new IrrigationPlan
                                    {
                                        Year = 2019,
                                        IrrigationPlanItems = new List<IrrigationPlanItem>
                                        {
                                            new IrrigationPlanItem
                                            {
                                                IrrigationSystemId = 1,
                                                LandAreaOnBeginningOfYear = 1000,
                                                LandAreaAgriculturalUse = 950,
                                                LandAreaIncludedInIrrigationPlan = 500,
                                                LandAreaSowing =750,
                                                IrrigationPlanItem_CropSowingAndIrrigations = new List<IrrigationPlanItem_CropSowingAndIrrigation>
                                                {
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 2, Sowing = 150, Irrigation = 100 },
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 3, Sowing = 250, Irrigation = 220 }
                                                },
                                                IrrigationPlanItem_LandAreaNotIrrigationReasons = new List<IrrigationPlanItem_LandAreaNotIrrigationReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 3,
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 30,
                                                        ReasonId = 4
                                                    }
                                                },
                                                IrrigationPlanItem_LandAreaNotAgriculturalReasons = new List<IrrigationPlanItem_LandAreaNotAgriculturalReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 4
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 80,
                                                        ReasonId = 5
                                                    }
                                                }
                                            },
                                            new IrrigationPlanItem
                                            {
                                                IrrigationSystemId = 25,
                                                LandAreaOnBeginningOfYear = 1000,
                                                LandAreaAgriculturalUse = 950,
                                                LandAreaIncludedInIrrigationPlan = 500,
                                                LandAreaSowing =750,
                                                IrrigationPlanItem_CropSowingAndIrrigations = new List<IrrigationPlanItem_CropSowingAndIrrigation>
                                                {
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 2, Sowing = 150, Irrigation = 100 },
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 3, Sowing = 250, Irrigation = 220 }
                                                },
                                                IrrigationPlanItem_LandAreaNotIrrigationReasons = new List<IrrigationPlanItem_LandAreaNotIrrigationReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 3,
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 30,
                                                        ReasonId = 4
                                                    }
                                                },
                                                IrrigationPlanItem_LandAreaNotAgriculturalReasons = new List<IrrigationPlanItem_LandAreaNotAgriculturalReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 4
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 80,
                                                        ReasonId = 5
                                                    }
                                                }
                                            },
                                            new IrrigationPlanItem
                                            {
                                                IrrigationSystemId = 28,
                                                LandAreaOnBeginningOfYear = 1000,
                                                LandAreaAgriculturalUse = 950,
                                                LandAreaIncludedInIrrigationPlan = 500,
                                                LandAreaSowing =750,
                                                IrrigationPlanItem_CropSowingAndIrrigations = new List<IrrigationPlanItem_CropSowingAndIrrigation>
                                                {
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 2, Sowing = 150, Irrigation = 100 },
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 3, Sowing = 250, Irrigation = 220 }
                                                },
                                                IrrigationPlanItem_LandAreaNotIrrigationReasons = new List<IrrigationPlanItem_LandAreaNotIrrigationReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 3,
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 30,
                                                        ReasonId = 4
                                                    }
                                                },
                                                IrrigationPlanItem_LandAreaNotAgriculturalReasons = new List<IrrigationPlanItem_LandAreaNotAgriculturalReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 4
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 80,
                                                        ReasonId = 5
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
            organizations.Add(new Organization
            {
                OrganizationId = 4,
                OrganizationName = "Багаевский филиал ФГБУ «Ростовмелиоводхоз»",
                ParentOrganizationId = 1,
                OrganizationDocumentation = new List<OrganizationDocumentationItem>
                {
                    new OrganizationDocumentationItem
                    {
                        OrganizationDocumentationItemName = "Документация по мелиорации",
                        OrganizationDocumentationPlans = new List<OrganizationDocumentationPlans>
                        {
                            new OrganizationDocumentationPlans
                            {
                                OrganizationDocumentationPlansName = "Планы поливов",
                                IrrigationPlans = new List<IrrigationPlan>
                                {
                                    new IrrigationPlan
                                    {
                                        Year = 2019,
                                        IrrigationPlanItems = new List<IrrigationPlanItem>
                                        {
                                            new IrrigationPlanItem
                                            {
                                                IrrigationSystemId = 1,
                                                LandAreaOnBeginningOfYear = 1000,
                                                LandAreaAgriculturalUse = 950,
                                                LandAreaIncludedInIrrigationPlan = 500,
                                                LandAreaSowing =750,
                                                IrrigationPlanItem_CropSowingAndIrrigations = new List<IrrigationPlanItem_CropSowingAndIrrigation>
                                                {
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 2, Sowing = 150, Irrigation = 100 },
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 3, Sowing = 250, Irrigation = 220 }
                                                },
                                                IrrigationPlanItem_LandAreaNotIrrigationReasons = new List<IrrigationPlanItem_LandAreaNotIrrigationReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 3,
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 30,
                                                        ReasonId = 4
                                                    }
                                                },
                                                IrrigationPlanItem_LandAreaNotAgriculturalReasons = new List<IrrigationPlanItem_LandAreaNotAgriculturalReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 4
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 80,
                                                        ReasonId = 5
                                                    }
                                                }
                                            },
                                            new IrrigationPlanItem
                                            {
                                                IrrigationSystemId = 2,
                                                LandAreaOnBeginningOfYear = 1000,
                                                LandAreaAgriculturalUse = 950,
                                                LandAreaIncludedInIrrigationPlan = 500,
                                                LandAreaSowing =750,
                                                IrrigationPlanItem_CropSowingAndIrrigations = new List<IrrigationPlanItem_CropSowingAndIrrigation>
                                                {
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 2, Sowing = 150, Irrigation = 100 },
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 3, Sowing = 250, Irrigation = 220 }
                                                },
                                                IrrigationPlanItem_LandAreaNotIrrigationReasons = new List<IrrigationPlanItem_LandAreaNotIrrigationReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 3,
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 30,
                                                        ReasonId = 4
                                                    }
                                                },
                                                IrrigationPlanItem_LandAreaNotAgriculturalReasons = new List<IrrigationPlanItem_LandAreaNotAgriculturalReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 4
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 80,
                                                        ReasonId = 5
                                                    }
                                                }
                                            },
                                            new IrrigationPlanItem
                                            {
                                                IrrigationSystemId = 10,
                                                LandAreaOnBeginningOfYear = 1000,
                                                LandAreaAgriculturalUse = 950,
                                                LandAreaIncludedInIrrigationPlan = 500,
                                                LandAreaSowing =750,
                                                IrrigationPlanItem_CropSowingAndIrrigations = new List<IrrigationPlanItem_CropSowingAndIrrigation>
                                                {
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 2, Sowing = 150, Irrigation = 100 },
                                                    new IrrigationPlanItem_CropSowingAndIrrigation{ CropId = 3, Sowing = 250, Irrigation = 220 }
                                                },
                                                IrrigationPlanItem_LandAreaNotIrrigationReasons = new List<IrrigationPlanItem_LandAreaNotIrrigationReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 3,
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotIrrigationReason
                                                    {
                                                        Area = 30,
                                                        ReasonId = 4
                                                    }
                                                },
                                                IrrigationPlanItem_LandAreaNotAgriculturalReasons = new List<IrrigationPlanItem_LandAreaNotAgriculturalReason>
                                                {
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 50,
                                                        ReasonId = 4
                                                    },
                                                    new IrrigationPlanItem_LandAreaNotAgriculturalReason
                                                    {
                                                        Area = 80,
                                                        ReasonId = 5
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
            organizations.Add(new Organization { OrganizationId = 5, OrganizationName = "Базковский филиал ФГБУ «Ростовмелиоводхоз»", ParentOrganizationId = 1 });
            organizations.Add(new Organization { OrganizationId = 6, OrganizationName = "Веселовский филиал ФГБУ «Ростовмелиоводхоз»", ParentOrganizationId = 1 });
            organizations.Add(new Organization { OrganizationId = 7, OrganizationName = "Волгодонской филиал ФГБУ «Ростовмелиоводхоз»", ParentOrganizationId = 1 });
            organizations.Add(new Organization { OrganizationId = 8, OrganizationName = "Верхне-Сальский филиал ФГБУ «Ростовмелиоводхоз»", ParentOrganizationId = 1 });
            organizations.Add(new Organization { OrganizationId = 9, OrganizationName = "Мартыновский филиал ФГБУ «Ростовмелиоводхоз»", ParentOrganizationId = 1 });
            organizations.Add(new Organization { OrganizationId = 10, OrganizationName = "Неклиновский филиал ФГБУ «Ростовмелиоводхоз»", ParentOrganizationId = 1 });
            organizations.Add(new Organization { OrganizationId = 11, OrganizationName = "Пролетарский филиал ФГБУ «Ростовмелиоводхоз»", ParentOrganizationId = 1 });
            organizations.Add(new Organization { OrganizationId = 12, OrganizationName = "Сальский филиал ФГБУ «Ростовмелиоводхоз»", ParentOrganizationId = 1 });
            organizations.Add(new Organization { OrganizationId = 13, OrganizationName = "Семикаракорский филиал ФГБУ «Ростовмелиоводхоз»", ParentOrganizationId = 1 });
            organizations.Add(new Organization
            {
                OrganizationId = 14,
                OrganizationName = "«50 лет ОКТЯБРЯ» СПК",
                ParentOrganizationId = null,
                OrganizationToTypeOfActivities = new List<OrganizationToTypeOfActivity>
                {
                    new OrganizationToTypeOfActivity { TypeOfActivityId = 2 }
                }                
            } );
            organizations.Add(new Organization { OrganizationId = 15, OrganizationName = "«АВАНГАРД» ЗАО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 16, OrganizationName = "«АГРАРНОЕ» ООО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 17, OrganizationName = "«АГРОКОМ» ООО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 18, OrganizationName = "«АГРОКОМПЛЕКС» КОЛХОЗ", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 19, OrganizationName = "«АГРОСЕРВИС» ООО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 20, OrganizationName = "«АЗОВСКОЕ» ЗАО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 21, OrganizationName = "«АКСАЙАГРОИНВЕСТ» ООО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 22, OrganizationName = "«АКСАЙСКАЯ ЗЕМЛЯ» ООО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 23, OrganizationName = "«АКСАЙСКАЯ НИВА» ЗАО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 24, OrganizationName = "«АКСАЙСКИЕ ОВОЩИ» ООО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 25, OrganizationName = "«АКСАЙСКОЕ МОЛОКО» ООО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 26, OrganizationName = "«АЛЕКСАНДРОВСКИЙ» СПК", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 27, OrganizationName = "«АНТОНОВСКОЕ» ЗАО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 28, OrganizationName = "«АНТРАЦИТ-А» ОАО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 29, OrganizationName = "«АТОММАШЕВЕЦ» ЗАО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 30, OrganizationName = "«АКСАЙСКАЯ» ПТИЦЕВОДЧЕСКАЯ ФАБРИКА (ЗАО)", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 31, OrganizationName = "«БАЗКОВСКИЙ» КОЛХОЗ", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 32, OrganizationName = "«БАКЛАННИКОВСКОЕ» ОАО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 33, OrganizationName = "«БАРАНИКОВСКИЙ» ООО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 34, OrganizationName = "«БЕЛОЗЕРНОЕ» ООО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 35, OrganizationName = "«БЕЛОКАЛИТВИНСКАЯ» ПТИЦЕФАБРИКА (ОАО)", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 36, OrganizationName = "«БЕРЕЗКА» КОЛХОЗ", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 37, OrganizationName = "«БЕРЕЗОВСКОЕ» ООО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 38, OrganizationName = "«БЕРЕЗОВЫЙ» СПК", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 39, OrganizationName = "«БЕССЕРГЕНЕВСКОЕ» АГРОПРОМЫШЛЕННОЕ ПРЕДПРИЯТИЕ (ООО)", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 40, OrganizationName = "БИРЮЧЕКУТСКАЯ ОВОЩНАЯ СЕЛЕКЦИОННАЯ ОПЫТНАЯ СТАНЦИЯ", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 41, OrganizationName = "«БОЛЬШИНСКОЕ» ЗАО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 42, OrganizationName = "«БОНДАРЕНКО» КОЛХОЗ", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 43, OrganizationName = "«БОРЕЦ» ЗАО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 44, OrganizationName = "«БРАТСКОЕ» ЗАО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 45, OrganizationName = "«БЫСТРЯНСКИЙ» СПК", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 46, OrganizationName = "«БРОЙЛЕР ДОН» ООО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 47, OrganizationName = "«ВАНТА» ООО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 48, OrganizationName = "«ВЕДЕРНИКИ» ОАО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 49, OrganizationName = "«ВЕЛЕС» ООО", ParentOrganizationId = null });
            organizations.Add(new Organization { OrganizationId = 50, OrganizationName = "«ВЕРА» СВИНОКОМПЛЕКС (ООО)", ParentOrganizationId = null });

            // Справочник сх производителей: http://www.kubanmakler.ru/9/Spisok_selhozpredpriyatiy/Spisok_selhozpredpriyatiy_Rostovskoy_oblasti.htm

            return organizations;
        }

        public static List<IrrigationSystem> GetIrrigationSystems()
        {
            var irrigationSystems = new List<IrrigationSystem>();

            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 1, IrrigationSystemName = "1 ор Азовская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 2, IrrigationSystemName = "2 ор Багаевская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 3, IrrigationSystemName = "3 ор Садковская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 4, IrrigationSystemName = "4 ор Верхне-Сальская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 5, IrrigationSystemName = "5 ор Донская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 6, IrrigationSystemName = "6 ор Мартыновск." });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 7, IrrigationSystemName = "7 ор Маныческая-1" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 8, IrrigationSystemName = "8 ор Маныческая-2" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 9, IrrigationSystemName = "9 ор Нижне-Донская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 10, IrrigationSystemName = "10 ор Нижне-Манычская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 11, IrrigationSystemName = "11 ор Константиновская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 12, IrrigationSystemName = "12 ор Приморская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 13, IrrigationSystemName = "14 ор Пролетарск." });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 14, IrrigationSystemName = "15 ор Право-Егорлыкская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 15, IrrigationSystemName = "17 ор Цимлянская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 16, IrrigationSystemName = "18 ор Миусская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 17, IrrigationSystemName = "19 ор Приазовск." });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 18, IrrigationSystemName = "21 ор Чирская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 19, IrrigationSystemName = "21 ор Болыловск." });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 20, IrrigationSystemName = "22 ор Троицк.-1" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 21, IrrigationSystemName = "23 ор Троицк.-2" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 22, IrrigationSystemName = "24 ор Краснополянская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 23, IrrigationSystemName = "25 ор Зубовская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 24, IrrigationSystemName = "26 ор Летниковская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 25,  IrrigationSystemName = "27 ор Темерницкая" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 26, IrrigationSystemName = "28 вх ДМК" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 27, IrrigationSystemName = "29 ос Зерногрдская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 28,  IrrigationSystemName = "31 ос Аксайская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 29, IrrigationSystemName = "31 ор Зерноградская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 30, IrrigationSystemName = "32 ор Веселовская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 31, IrrigationSystemName = "32 ос Веселовская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 32, IrrigationSystemName = "33 ос Целинская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 33, IrrigationSystemName = "35 ор Нептун" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 34, IrrigationSystemName = "36 ор Струя" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 35, IrrigationSystemName = "37 ор Вяжа" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 36, IrrigationSystemName = "38 ор Поднятая Целина" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 37, IrrigationSystemName = "39 ор БКНС Первомайская-1" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 38, IrrigationSystemName = "40 ор БКНС Первомайская-2" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 39, IrrigationSystemName = "41 ор БКНС Земцовская" });
            irrigationSystems.Add(new IrrigationSystem { IrrigationSystemId = 40, IrrigationSystemName = "42 ор БКНС Малаховская" });            

            return irrigationSystems;
        }

    }
}
