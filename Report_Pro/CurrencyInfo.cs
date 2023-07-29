﻿using System;

namespace Report_Pro
{
    public class CurrencyInfo
    {
        public enum Currencies { Syria = 0, UAE, S, Tunisia, Gold ,Bahrain, Kuwait, Oman,Qatar,D,EUR};

        #region Constructors

        public CurrencyInfo(Currencies currency)
        {
            switch (currency)
            {
                case Currencies.Syria:
                    CurrencyID = 0;
                    CurrencyCode = "SYP";
                    IsCurrencyNameFeminine = true;
                    EnglishCurrencyName = "Syrian Pound";
                    EnglishPluralCurrencyName = "Syrian Pounds";
                    EnglishCurrencyPartName = "Piaster";
                    EnglishPluralCurrencyPartName = "Piasteres";
                    Arabic1CurrencyName = "ليرة سورية";
                    Arabic2CurrencyName = "ليرتان سوريتان";
                    Arabic310CurrencyName = "ليرات سورية";
                    Arabic1199CurrencyName = "ليرة سورية";
                    Arabic1CurrencyPartName = "قرش";
                    Arabic2CurrencyPartName = "قرشان";
                    Arabic310CurrencyPartName = "قروش";
                    Arabic1199CurrencyPartName = "قرشاً";
                    PartPrecision = 2;
                    IsCurrencyPartNameFeminine = false;
                    break;

                case Currencies.UAE:
                    CurrencyID = 1;
                    CurrencyCode = "AED";
                    IsCurrencyNameFeminine = false;
                    EnglishCurrencyName = "UAE Dirham";
                    EnglishPluralCurrencyName = "UAE Dirhams";
                    EnglishCurrencyPartName = "Fils";
                    EnglishPluralCurrencyPartName = "Fils";
                    Arabic1CurrencyName = "درهم إماراتي";
                    Arabic2CurrencyName = "درهمان إماراتيان";
                    Arabic310CurrencyName = "دراهم إماراتية";
                    Arabic1199CurrencyName = "درهماً إماراتياً";
                    Arabic1CurrencyPartName = "فلس";
                    Arabic2CurrencyPartName = "فلسان";
                    Arabic310CurrencyPartName = "فلوس";
                    Arabic1199CurrencyPartName = "فلساً";
                    PartPrecision = 2;
                    IsCurrencyPartNameFeminine = false;
                    break;

                case Currencies.S:
                    CurrencyID = 2;
                    CurrencyCode = "SAR";
                    IsCurrencyNameFeminine = false;
                    EnglishCurrencyName = "Saudi Riyal";
                    EnglishPluralCurrencyName = "Saudi Riyals";
                    EnglishCurrencyPartName = "Halala";
                    EnglishPluralCurrencyPartName = "Halalas";
                    Arabic1CurrencyName = "ريال سعودي";
                    Arabic2CurrencyName = "ريالان سعوديان";
                    Arabic310CurrencyName = "ريالات سعودية";
                    Arabic1199CurrencyName = "ريالاً سعودياً";
                    Arabic1CurrencyPartName = "هللة";
                    Arabic2CurrencyPartName = "هللتان";
                    Arabic310CurrencyPartName = "هللات";
                    Arabic1199CurrencyPartName = "هللة";
                    PartPrecision = 2;
                    IsCurrencyPartNameFeminine = true;
                    break;


             

                case Currencies.Tunisia:
                    CurrencyID = 3;
                    CurrencyCode = "TND";
                    IsCurrencyNameFeminine = false;
                    EnglishCurrencyName = "Tunisian Dinar";
                    EnglishPluralCurrencyName = "Tunisian Dinars";
                    EnglishCurrencyPartName = "milim";
                    EnglishPluralCurrencyPartName = "millimes";
                    Arabic1CurrencyName = "دينار تونسي";
                    Arabic2CurrencyName = "ديناران تونسيان";
                    Arabic310CurrencyName = "دنانير تونسية";
                    Arabic1199CurrencyName = "ديناراً تونسياً";
                    Arabic1CurrencyPartName = "مليم";
                    Arabic2CurrencyPartName = "مليمان";
                    Arabic310CurrencyPartName = "ملاليم";
                    Arabic1199CurrencyPartName = "مليماً";
                    PartPrecision = 3;
                    IsCurrencyPartNameFeminine = false;
                    break;

                case Currencies.Gold:
                    CurrencyID = 4;
                    CurrencyCode = "XAU";
                    IsCurrencyNameFeminine = false;
                    EnglishCurrencyName = "Gram";
                    EnglishPluralCurrencyName = "Grams";
                    EnglishCurrencyPartName = "Milligram";
                    EnglishPluralCurrencyPartName = "Milligrams";
                    Arabic1CurrencyName = "جرام";
                    Arabic2CurrencyName = "جرامان";
                    Arabic310CurrencyName = "جرامات";
                    Arabic1199CurrencyName = "جراماً";
                    Arabic1CurrencyPartName = "ملجرام";
                    Arabic2CurrencyPartName = "ملجرامان";
                    Arabic310CurrencyPartName = "ملجرامات";
                    Arabic1199CurrencyPartName = "ملجراماً";
                    PartPrecision = 2;
                    IsCurrencyPartNameFeminine = false;
                    break;

                case Currencies.Bahrain:
                    CurrencyID = 5;
                    CurrencyCode = "BHD";
                    IsCurrencyNameFeminine = false;
                    EnglishCurrencyName = "Bahraini dinar";
                    EnglishPluralCurrencyName = "Bahraini dinars";
                    EnglishCurrencyPartName = "Fils ";
                    EnglishPluralCurrencyPartName = "Fils";
                    Arabic1CurrencyName = "دينار بحريني";
                    Arabic2CurrencyName = "ديناران بحرينيان";
                    Arabic310CurrencyName = "دينارات بحرينية";
                    Arabic1199CurrencyName = "ديناراً بحرينياً";
                    Arabic1CurrencyPartName = "فلس";
                    Arabic2CurrencyPartName = "فلسان";
                    Arabic310CurrencyPartName = "فلوس";
                    Arabic1199CurrencyPartName = "فلس";
                    PartPrecision = 3;
                    IsCurrencyPartNameFeminine = true;
                    break;

                case Currencies.Kuwait:
                    CurrencyID = 6;
                    CurrencyCode = "KWD";
                    IsCurrencyNameFeminine = false;
                    EnglishCurrencyName = "Kuwaiti dinar";
                    EnglishPluralCurrencyName = "Kuwaiti dinars";
                    EnglishCurrencyPartName = "Fils ";
                    EnglishPluralCurrencyPartName = "Fils";
                    Arabic1CurrencyName = "دينار كويتي";
                    Arabic2CurrencyName = "ديناران كويتيان";
                    Arabic310CurrencyName = "دينارات كويتيه";
                    Arabic1199CurrencyName = "ديناراً كويتياً";
                    Arabic1CurrencyPartName = "فلس";
                    Arabic2CurrencyPartName = "فلسان";
                    Arabic310CurrencyPartName = "فلوس";
                    Arabic1199CurrencyPartName = "فلس";
                    PartPrecision = 3;
                    IsCurrencyPartNameFeminine = true;
                    break;
                case Currencies.Oman:
                    CurrencyID = 7;
                    CurrencyCode = "OMR";
                    IsCurrencyNameFeminine = false;
                    EnglishCurrencyName = "Omani Rial";
                    EnglishPluralCurrencyName = "Omani Rials";
                    EnglishCurrencyPartName = "Baisa ";
                    EnglishPluralCurrencyPartName = "Baisas";
                    Arabic1CurrencyName = "ريال عماني";
                    Arabic2CurrencyName = "ريالان عمانيان";
                    Arabic310CurrencyName = "ريالات عمانية";
                    Arabic1199CurrencyName = "ريالاً عمانياً";
                    Arabic1CurrencyPartName = "بيسه";
                    Arabic2CurrencyPartName = "بيستان";
                    Arabic310CurrencyPartName = "بيسات";
                    Arabic1199CurrencyPartName = "بيسه";
                    PartPrecision = 3;
                    IsCurrencyPartNameFeminine = true;
                    break;


                case Currencies.Qatar:
                    CurrencyID = 8;
                    CurrencyCode = "QAR";
                    IsCurrencyNameFeminine = false;
                    EnglishCurrencyName = "Qatari Rial";
                    EnglishPluralCurrencyName = "Qatari Rials";
                    EnglishCurrencyPartName = "Dirham ";
                    EnglishPluralCurrencyPartName = "Dirhams";
                    Arabic1CurrencyName = "ريال قطري";
                    Arabic2CurrencyName = "ريالان قطريان";
                    Arabic310CurrencyName = "ريالات قطرية";
                    Arabic1199CurrencyName = "ريالاً قطرياً";
                    Arabic1CurrencyPartName = "درهم";
                    Arabic2CurrencyPartName = "درهمان";
                    Arabic310CurrencyPartName = "دراهم";
                    Arabic1199CurrencyPartName = "درهم";
                    PartPrecision = 3;
                    IsCurrencyPartNameFeminine = true;
                    break;

                case Currencies.D:
                    CurrencyID = 9;
                    CurrencyCode = "USD";
                    IsCurrencyNameFeminine = false;
                    EnglishCurrencyName = "USD";
                    EnglishPluralCurrencyName = "USD";
                    EnglishCurrencyPartName = "Cent ";
                    EnglishPluralCurrencyPartName = "Cents";
                    Arabic1CurrencyName = "دولار";
                    Arabic2CurrencyName = "دولاران";
                    Arabic310CurrencyName = "دولارات";
                    Arabic1199CurrencyName = "دولارا امريكيا";
                    Arabic1CurrencyPartName = "سنت";
                    Arabic2CurrencyPartName = "سنتان";
                    Arabic310CurrencyPartName = "سنتات";
                    Arabic1199CurrencyPartName = "سنت";
                    PartPrecision = 3;
                    IsCurrencyPartNameFeminine = true;
                    break;

                case Currencies.EUR:
                    CurrencyID = 10;
                    CurrencyCode = "Euro";
                    IsCurrencyNameFeminine = false;
                    EnglishCurrencyName = "Euro";
                    EnglishPluralCurrencyName = "Euro";
                    EnglishCurrencyPartName = "Cent ";
                    EnglishPluralCurrencyPartName = "Cents";
                    Arabic1CurrencyName = "يورو";
                    Arabic2CurrencyName = "يورو";
                    Arabic310CurrencyName = "يوروات";
                    Arabic1199CurrencyName = "يورو";
                    Arabic1CurrencyPartName = "سنت";
                    Arabic2CurrencyPartName = "سنتان";
                    Arabic310CurrencyPartName = "سنتات";
                    Arabic1199CurrencyPartName = "سنت";
                    PartPrecision = 3;
                    IsCurrencyPartNameFeminine = true;
                    break;



            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Currency ID
        /// </summary>
        public int CurrencyID { get; set; }

        /// <summary>
        /// Standard Code
        /// Syrian Pound: SYP
        /// UAE Dirham: AED
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Is the currency name feminine ( Mua'anath مؤنث)
        /// ليرة سورية : مؤنث = true
        /// درهم : مذكر = false
        /// </summary>
        public Boolean IsCurrencyNameFeminine { get; set; }

        /// <summary>
        /// English Currency Name for single use
        /// Syrian Pound
        /// UAE Dirham
        /// </summary>
        public string EnglishCurrencyName { get; set; }

        /// <summary>
        /// English Plural Currency Name for Numbers over 1
        /// Syrian Pounds
        /// UAE Dirhams
        /// </summary>
        public string EnglishPluralCurrencyName { get; set; }

        /// <summary>
        /// Arabic Currency Name for 1 unit only
        /// ليرة سورية
        /// درهم إماراتي
        /// </summary>
        public string Arabic1CurrencyName { get; set; }

        /// <summary>
        /// Arabic Currency Name for 2 units only
        /// ليرتان سوريتان
        /// درهمان إماراتيان
        /// </summary>
        public string Arabic2CurrencyName { get; set; }

        /// <summary>
        /// Arabic Currency Name for 3 to 10 units
        /// خمس ليرات سورية
        /// خمسة دراهم إماراتية
        /// </summary>
        public string Arabic310CurrencyName { get; set; }

        /// <summary>
        /// Arabic Currency Name for 11 to 99 units
        /// خمس و سبعون ليرةً سوريةً
        /// خمسة و سبعون درهماً إماراتياً
        /// </summary>
        public string Arabic1199CurrencyName { get; set; }

        /// <summary>
        /// Decimal Part Precision
        /// for Syrian Pounds: 2 ( 1 SP = 100 parts)
        /// for Tunisian Dinars: 3 ( 1 TND = 1000 parts)
        /// </summary>
        public Byte PartPrecision { get; set; }

        /// <summary>
        /// Is the currency part name feminine ( Mua'anath مؤنث)
        /// هللة : مؤنث = true
        /// قرش : مذكر = false
        /// </summary>
        public Boolean IsCurrencyPartNameFeminine { get; set; }

        /// <summary>
        /// English Currency Part Name for single use
        /// Piaster
        /// Fils
        /// </summary>
        public string EnglishCurrencyPartName { get; set; }

        /// <summary>
        /// English Currency Part Name for Plural
        /// Piasters
        /// Fils
        /// </summary>
        public string EnglishPluralCurrencyPartName { get; set; }

        /// <summary>
        /// Arabic Currency Part Name for 1 unit only
        /// قرش
        /// هللة
        /// </summary>
        public string Arabic1CurrencyPartName { get; set; }

        /// <summary>
        /// Arabic Currency Part Name for 2 unit only
        /// قرشان
        /// هللتان
        /// </summary>
        public string Arabic2CurrencyPartName { get; set; }

        /// <summary>
        /// Arabic Currency Part Name for 3 to 10 units
        /// قروش
        /// هللات
        /// </summary>
        public string Arabic310CurrencyPartName { get; set; }

        /// <summary>
        /// Arabic Currency Part Name for 11 to 99 units
        /// قرشاً
        /// هللةً
        /// </summary>
        public string Arabic1199CurrencyPartName { get; set; }
        #endregion
    }
}
