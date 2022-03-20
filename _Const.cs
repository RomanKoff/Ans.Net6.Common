using System.Globalization;
using System.Numerics;
using System.Text;

namespace Ans.Net6.Common
{

	public static partial class _Const
    {

        public static readonly string TEXT_MASK
            = "###MASK###";


        public static readonly string KEYS_CHARS
            = "qwertyuiop[] asdfghjkl;'\\zxcvbnm,./`1234567890-=~!@#$%^&*()_+";
        public static readonly char[] KEYS_CHARS_ARRAY
            = KEYS_CHARS.ToArray();


        public static readonly string STOP_CHARS
            = " .,:;!-_–—()[]{}\"\'«»“”„|/\\\t\r\n";
        public static readonly char[] STOP_CHARS_ARRAY
            = STOP_CHARS.ToArray();


        public static readonly CultureInfo CULTURE_RU
            = CultureInfo.CreateSpecificCulture("ru-RU");
        public static readonly CultureInfo CULTURE_EN
            = CultureInfo.CreateSpecificCulture("en-US");


        public static readonly string[] MONTH_NAMES_RU
            = new string[] { "" }
                .Concat(CULTURE_RU.DateTimeFormat.MonthNames)
                .ToArray();
        public static readonly string[] MONTH_GENINAMES_RU
            = new string[] { "" }
                .Concat(CULTURE_RU.DateTimeFormat.MonthGenitiveNames)
                .ToArray();

        public static readonly Registry REG_MONTH_NAMES_RU
            = new(MONTH_NAMES_RU.Skip(1).Take(12).ToArray(), 1);
        public static readonly Registry REG_MONTH_GENINAMES_RU
            = new(MONTH_GENINAMES_RU.Skip(1).Take(12).ToArray(), 1);


        public const string REGEX_VARNAME
            = @"^([a-zA-Z_][0-9a-zA-Z_]+)$";
        public const string REGEX_EMAIL
            = @"^(?("")(""[^""]+""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        public const string REGEX_INT
            = @"\d+";
        public const string REGEX_IP4
            = @"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";
        public const string REGEX_PASSWORD
            = @"^([0-9a-zA-Z `\'"":;,\.<>+=\~_\?\!\@#\$%\^\&\*\(\)\[\]\{\}/\\\|-]+)$";


        public static readonly char[] SPLIT_ITEMS = new char[] { ';', ',' };
        public static readonly char[] SPLIT_PARAMS = new char[] { '|', '=' };
        public static readonly char[] SPLIT_LN = new char[] { '\n' };
        public static readonly char[] SPLIT_SPACE = new char[] { ' ' };
        public static readonly char[] SPLIT_COMMA = new char[] { ',' };
        public static readonly char[] SPLIT_COLON = new char[] { ':' };
        public static readonly char[] SPLIT_SEMICOLON = new char[] { ';' };
        public static readonly char[] SPLIT_VLINE = new char[] { '|' };
        public static readonly char[] SPLIT_SLASH = new char[] { '/' };
        public static readonly char[] SPLIT_BSLASH = new char[] { '\\' };
        public static readonly char[] SPLIT_ASTERISK = new char[] { '*' };
        public static readonly char[] SPLIT_EQUALLY = new char[] { '=' };


        public static readonly Encoding ENCODING_UTF8
            = Encoding.UTF8;
        public static readonly Encoding ENCODING_ISO88591
            = Encoding.GetEncoding("iso-8859-1");
        //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        public static readonly Encoding ENCODING_WINDOWS1251
            = ENCODING_ISO88591; // Encoding.GetEncoding(1252);
        public static readonly Encoding ENCODING_KOI8R
            = ENCODING_ISO88591; // Encoding.GetEncoding(20866);


        public static readonly string FORMAT_SAFE_DATETIME
            = "yyyy-0MM-dd HH:mmmm:ss";
        public static readonly string FORMAT_SAFE_DATE
            = "yyyy-0MM-dd";
        public static readonly string FORMAT_SAFE_DATETIME_FILE
            = "yyyy-0MM-dd_HH-mmmm-ss";
        public static readonly string FORMAT_SAFE_DATETIME_MIN
            = "yyyy0MMddHHmmmmss";


        public static readonly uint[] IPv4_MASKS = new uint[]
        {
            0xFFFFFFFF,
            0xFF000000,
            0x00FF0000,
            0x0000FF00,
            0x000000FF
        };

        public static readonly BigInteger[] IPv6_MASKS = new BigInteger[]
        {
            BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF", NumberStyles.HexNumber),
            BigInteger.Parse("00FF000000000000000000000000000000", NumberStyles.HexNumber),
            BigInteger.Parse("0000FF0000000000000000000000000000", NumberStyles.HexNumber),
            BigInteger.Parse("000000FF00000000000000000000000000", NumberStyles.HexNumber),
            BigInteger.Parse("00000000FF000000000000000000000000", NumberStyles.HexNumber),
            BigInteger.Parse("0000000000FF0000000000000000000000", NumberStyles.HexNumber),
            BigInteger.Parse("000000000000FF00000000000000000000", NumberStyles.HexNumber),
            BigInteger.Parse("00000000000000FF000000000000000000", NumberStyles.HexNumber),
            BigInteger.Parse("0000000000000000FF0000000000000000", NumberStyles.HexNumber),
            BigInteger.Parse("000000000000000000FF00000000000000", NumberStyles.HexNumber),
            BigInteger.Parse("00000000000000000000FF000000000000", NumberStyles.HexNumber),
            BigInteger.Parse("0000000000000000000000FF0000000000", NumberStyles.HexNumber),
            BigInteger.Parse("000000000000000000000000FF00000000", NumberStyles.HexNumber),
            BigInteger.Parse("00000000000000000000000000FF000000", NumberStyles.HexNumber),
            BigInteger.Parse("0000000000000000000000000000FF0000", NumberStyles.HexNumber),
            BigInteger.Parse("000000000000000000000000000000FF00", NumberStyles.HexNumber),
            BigInteger.Parse("00000000000000000000000000000000FF", NumberStyles.HexNumber)
        };


        public static readonly byte[] TRANSPARENT_MASK = new byte[]
        {
            0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99,
            0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc,
            0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99,
            0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc,
            0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99,
            0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc,
            0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99,
            0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc,
            0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc,
            0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99,
            0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc,
            0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99,
            0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc,
            0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99,
            0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc, 0xcc,0xcc,0xcc,
            0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99, 0x99,0x99,0x99
        };


        public const int KEYCODE_BACKSPACE = 8;
        public const int KEYCODE_TAB = 9;
        public const int KEYCODE_ENTER = 13;
        public const int KEYCODE_SHIFT = 16;
        public const int KEYCODE_CTRL = 17;
        public const int KEYCODE_ALT = 18;
        public const int KEYCODE_PAUSE_BREAK = 19;
        public const int KEYCODE_CAPS_LOCK = 20;
        public const int KEYCODE_ESCAPE = 27;
        public const int KEYCODE_PAGE_UP = 33;
        public const int KEYCODE_PAGE_DOWN = 34;
        public const int KEYCODE_END = 35;
        public const int KEYCODE_HOME = 36;
        public const int KEYCODE_LEFT_ARROW = 37;
        public const int KEYCODE_UP_ARROW = 38;
        public const int KEYCODE_RIGHT_ARROW = 39;
        public const int KEYCODE_DOWN_ARROW = 40;
        public const int KEYCODE_INSERT = 45;
        public const int KEYCODE_DELETE = 46;
        public const int KEYCODE_0 = 48;
        public const int KEYCODE_1 = 49;
        public const int KEYCODE_2 = 50;
        public const int KEYCODE_3 = 51;
        public const int KEYCODE_4 = 52;
        public const int KEYCODE_5 = 53;
        public const int KEYCODE_6 = 54;
        public const int KEYCODE_7 = 55;
        public const int KEYCODE_8 = 56;
        public const int KEYCODE_9 = 57;
        public const int KEYCODE_A = 65;
        public const int KEYCODE_B = 66;
        public const int KEYCODE_C = 67;
        public const int KEYCODE_D = 68;
        public const int KEYCODE_E = 69;
        public const int KEYCODE_F = 70;
        public const int KEYCODE_G = 71;
        public const int KEYCODE_H = 72;
        public const int KEYCODE_I = 73;
        public const int KEYCODE_J = 74;
        public const int KEYCODE_K = 75;
        public const int KEYCODE_L = 76;
        public const int KEYCODE_M = 77;
        public const int KEYCODE_N = 78;
        public const int KEYCODE_O = 79;
        public const int KEYCODE_P = 80;
        public const int KEYCODE_Q = 81;
        public const int KEYCODE_R = 82;
        public const int KEYCODE_S = 83;
        public const int KEYCODE_T = 84;
        public const int KEYCODE_U = 85;
        public const int KEYCODE_V = 86;
        public const int KEYCODE_W = 87;
        public const int KEYCODE_X = 88;
        public const int KEYCODE_Y = 89;
        public const int KEYCODE_Z = 90;
        public const int KEYCODE_LEFT_WINDOW_KEY = 91;
        public const int KEYCODE_RIGHT_WINDOW_KEY = 92;
        public const int KEYCODE_SELECT_KEY = 93;
        public const int KEYCODE_NUMPAD_0 = 96;
        public const int KEYCODE_NUMPAD_1 = 97;
        public const int KEYCODE_NUMPAD_2 = 98;
        public const int KEYCODE_NUMPAD_3 = 99;
        public const int KEYCODE_NUMPAD_4 = 100;
        public const int KEYCODE_NUMPAD_5 = 101;
        public const int KEYCODE_NUMPAD_6 = 102;
        public const int KEYCODE_NUMPAD_7 = 103;
        public const int KEYCODE_NUMPAD_8 = 104;
        public const int KEYCODE_NUMPAD_9 = 105;
        public const int KEYCODE_MULTIPLY = 106;
        public const int KEYCODE_ADD = 107;
        public const int KEYCODE_SUBTRACT = 109;
        public const int KEYCODE_DECIMAL_POINT = 110;
        public const int KEYCODE_DIVIDE = 111;
        public const int KEYCODE_F1 = 112;
        public const int KEYCODE_F2 = 113;
        public const int KEYCODE_F3 = 114;
        public const int KEYCODE_F4 = 115;
        public const int KEYCODE_F5 = 116;
        public const int KEYCODE_F6 = 117;
        public const int KEYCODE_F7 = 118;
        public const int KEYCODE_F8 = 119;
        public const int KEYCODE_F9 = 120;
        public const int KEYCODE_F10 = 121;
        public const int KEYCODE_F11 = 122;
        public const int KEYCODE_F12 = 123;
        public const int KEYCODE_NUM_LOCK = 144;
        public const int KEYCODE_SCROLL_LOCK = 145;
        public const int KEYCODE_SEMICOLON = 186;
        public const int KEYCODE_EQUAL_SIGN = 187;
        public const int KEYCODE_COMMA = 188;
        public const int KEYCODE_DASH = 189;
        public const int KEYCODE_PERIOD = 190;
        public const int KEYCODE_FORWARD_SLASH = 191;
        public const int KEYCODE_GRAVE_ACCENT = 192;
        public const int KEYCODE_OPEN_BRACKET = 219;
        public const int KEYCODE_BACK_SLASH = 220;
        public const int KEYCODE_CLOSE_BRAKET = 221;
        public const int KEYCODE_SINGLE_QUOTE = 222;


        public static string GetSampleRu()
            => SAMPLES_RU[SuppRandom.Next(0, SAMPLES_RU.Length - 1)];

        public static string GetSampleRu_Small()
            => SAMPLES_SMALL_RU[
                SuppRandom.Next(0, SAMPLES_SMALL_RU.Length - 1)];

        public static string GetSampleRu_Smaller()
            => SAMPLES_SMALLER_RU[
                SuppRandom.Next(0, SAMPLES_SMALLER_RU.Length - 1)];

        public static readonly string[] SAMPLES_RU = new string[]
        {
            "Эй, цирюльникъ, ёжик выстриги, да щетину ряхи сбрей, феном вошь за печь гони",
            "Экс-граф? Плюш изъят. Бьём чуждый цен хвощ",
            "Эй, жлоб! Где туз? Прячь юных съёмщиц в шкаф",
            "Любя, съешь щипцы, — вздохнёт мэр, — кайф жгуч",
            "В чащах юга жил-был цитрус… — да, но фальшивый экземпляръ",
            "Южно-эфиопский грач увёл мышь за хобот на съезд ящериц",
            "Аэрофотосъёмка ландшафта уже выявила земли богачей и процветающих крестьян",
            "Шифровальщица попросту забыла ряд ключевых множителей и тэгов",
            "Съешь ещё этих мягких французских булок, да выпей [же] чаю. 1234567890",
            "Щипцами брюки разлохмачу, Гребёнкой волосы взъерошу. Эффектно ожидать удачу. До самой смерти я не брошу",
            "Подъём с затонувшего эсминца легко бьющейся древнегреческой амфоры сопряжён с техническими трудностями",
            "Завершён ежегодный съезд эрудированных школьников, мечтающих глубоко проникнуть в тайны физических явлений и химических реакций",
            "Всё ускоряющаяся эволюция компьютерных технологий предъявила жёсткие требования к производителям как собственно вычислительной техники, так и периферийных устройств",
            "Шалящий фавн прикинул объём горячих звезд этих вьюжных царств",
            "Эх, жирафы честно в цель шагают, да щук объять за память ёлкой",
            "Объявляю: туфли у камина, где этот хищный ёж цаплю задел",
            "Лингвисты в ужасе: фиг выговоришь этюд: «подъём челябинский, запах щец»",
            "Съел бы ёж лимонный пьезокварц, где электрическая юла яшму с туфом похищает",
            "Официально заявляю читающим: даёшь подъем операции Ы! Хуже с ёлкой бог экспериментирует",
            "Эти ящерицы чешут вперёд за ключом, но багаж в сейфах, поди подъедь",
            "Бегом марш! У месторождения кварцующихся фей без слёз хочется электрическую пыль",
            "Хрюкнул ёж «Тыща», а ведь село Фершампенуаз — это центр Нагайбакского района Челябинской области",
            "Эх, взъярюсь, толкну флегматика: «Дал бы щец жарчайших, Пётр!»",
            "Здесь фабула объять не может всех эмоций — шепелявый скороход в юбке тащит горячий мёд",
            "Художник-эксперт с компьютером всего лишь яйца в объёмный низкий ящик чохом фасовал",
            "Юный директор целиком сжевал весь объём продукции фундука (товара дефицитного и деликатесного), идя энергично через хрустящий камыш",
            "Мюзикл-буфф «Огнедышащий простужается ночью» (в 12345 сценах и 67890 эпизодах)",
            "Обдав его удушающей пылью, множество ярких фаэтонов исчезло из цирка",
            "Безмозглый широковещательный цифровой передатчик сужающихся экспонент",
            "Однажды съев фейхоа, я, как зацикленный, ностальгирую всё чаще и больше по этому чуду",
            "Вопрос футбольных энциклопедий замещая чушью: эй, где съеден ёж",
            "Борец за идею Чучхэ выступил с гиком, шумом, жаром и фырканьем на съезде — и в ящик",
            "Твёрдый, как ъ, но и мягкий, словно ь, юноша из Бухары ищет фемину-москвичку для просмотра цветного экрана жизни",
            "Блеф разъедает ум, чаще цыгана живёшь беспокойно, юля — грех это",
            "БУКВОПЕЧАТАЮЩЕЙ СВЯЗИ НУЖНЫ ХОРОШИЕ Э/МАГНИТНЫЕ РЕЛЕ. ДАТЬ ЦИФРЫ (1234567890+= .?-)",
            "Пиши: зять съел яйцо, ещё чан брюквы… эх! Ждем фигу",
            "Флегматичная эта верблюдица жует у подъезда засыхающий горький шиповник",
            "Вступив в бой с шипящими змеями — эфой и гадюкой, — маленький, цепкий, храбрый ёж съел их",
            "Подъехал шофёр на рефрижераторе грузить яйца для обучающихся элитных медиков",
            "Широкая электрификация южных губерний даст мощный толчок подъёму сельского хозяйства",
            "Государев указ: душегубцев да шваль всякую высечь, да калёным железом по щекам этих физиономий съездить",
            "§ Проверка шрифта — «№–0123456789». 123−456+789=456 QWERTYUIOP{} ASDFGHJKL:\"| ZXCVBNM<>? ~!@#$%^&*()_+ qwertyuiop[] asdfghjkl;'\\ zxcvbnm,./ `1234567890-= ЙЦУКЕНГШЩЗХЪ ФЫВАПРОЛДЖЭ/ ЯЧСМИТЬБЮ, Ё!\"№;%:?*()_+ йцукенгшщзхъ фывапролджэ\\ ячсмитьбю. ё1234567890-="
        };

        public static readonly string[] SAMPLES_SMALL_RU = new string[]
        {
            "Эй, цирюльникъ, ёжик выстриги",
            "Экс-граф? Плюш изъят",
            "Эй, жлоб! Где туз",
            "Любя, съешь щипцы, — вздохнёт мэр",
            "В чащах юга жил-был цитрус",
            "Южно-эфиопский грач увёл мышь",
            "Аэрофотосъёмка ландшафта уже выявила",
            "Шифровальщица попросту забыла",
            "Съешь ещё этих мягких французских булок",
            "Щипцами брюки разлохмачу",
            "Подъём с затонувшего эсминца",
            "Завершён ежегодный съезд эрудированных",
            "Всё ускоряющаяся эволюция",
            "Шалящий фавн прикинул объём",
            "Эх, жирафы честно в цель шагают",
            "Объявляю: туфли у камина",
            "Лингвисты в ужасе: фиг выговоришь",
            "Съел бы ёж лимонный пьезокварц",
            "Официально заявляю читающим",
            "Эти ящерицы чешут вперёд за ключом",
            "Бегом марш",
            "Хрюкнул ёж «Тыща»",
            "Эх, взъярюсь, толкну флегматика",
            "Здесь фабула объять не может всех эмоций",
            "Художник-эксперт с компьютером",
            "Юный директор целиком сжевал",
            "Мюзикл-буфф «Огнедышащий простужается ночью»",
            "Обдав его удушающей пылью",
            "Безмозглый широковещательный",
            "Однажды съев фейхоа",
            "Вопрос футбольных энциклопедий",
            "Борец за идею Чучхэ выступил с гиком",
            "Твёрдый, как ъ, но и мягкий, словно ь",
            "Блеф разъедает ум",
            "Пиши: зять съел яйцо",
            "Флегматичная эта верблюдица",
            "Вступив в бой с шипящими змеями",
            "Подъехал шофёр на рефрижераторе",
            "Широкая электрификация южных губерний",
            "Государев указ"
        };

        public static readonly string[] SAMPLES_SMALLER_RU = new string[]
        {
            "Ёжик выстриги",
            "Плюш изъят",
            "Прячь юных съёмщиц",
            "Любя, съешь щипцы",
            "Фальшивый экземпляръ",
            "Увёл мышь за хобот",
            "Земли богачей",
            "Шифровальщица попросту",
            "Французских булок",
            "Эффектно ожидать удачу",
            "С техническими трудностями",
            "Явлений и химических реакций",
            "Периферийных устройств",
            "Этих вьюжных царств",
            "За память ёлкой",
            "Ёж цаплю задел",
            "Челябинский, запах щец»",
            "С туфом похищает",
            "Хуже с ёлкой бог",
            "В сейфах, поди подъедь",
            "Электрическую пыль",
            "Челябинской области",
            "Дал бы щец жарчайших, Пётр",
            "Тащит горячий мёд",
            "Ящик чохом фасовал",
            "Через хрустящий камыш",
            "Исчезло из цирка",
            "Сужающихся экспонент",
            "Больше по этому чуду",
            "Где съеден ёж",
            "И в ящик",
            "Цветного экрана жизни",
            "Юля — грех это",
            "Ждем фигу",
            "Горький шиповник",
            "Храбрый ёж съел их",
            "Элитных медиков",
            "Сельского хозяйства",
            "Этих физиономий съездить"
        };

    }

}