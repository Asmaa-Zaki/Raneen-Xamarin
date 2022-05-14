using System;
using System.Collections.Generic;
using System.Text;

namespace Raneen.Data
{
    internal class AddressData
    {
        public static List<string> states = new List<string>()
        {
            "Alexandria", "Aswan", "Asyut", "Beheira", "Beni_Suef", "Cairo", "Dakahlia",
            "Damietta", "Faiyum", "Gharbia", "Giza", "Ismailia", "Kafr_El_Sheikh", "Luxor",
            "Matruh", "Minya", "Monufia", "New_Valley", "North_Sinai", "Port_Said", "Qalyubia",
            "Qena", "Red_Sea", "Sharqia", "Sohag", "South_Sinai", "Suez"
        };

        public static List<string> Alexandria = new List<string>()
        {
            "Abu Qir", "Agami", "Alexandria", "Ar-Raml", "Borg El Arab", "Montaza", "New Borg El Arab", "Sidi Bishr"
        };
        public static List<string> Aswan = new List<string>()
        {
            "Aswan", "Daraw", "Edfu", "El Basaliya", "El Radisia", "Kom Ombo", "New Aswan", "New Kalabsha", "Sebaiya"
        };
        public static List<string> Asyut = new List<string>()
        {
            "Abnub" ,"Abu Tig", "Asyut", "Dairut", "El Badari", "El Ghanayem", "Manfalut", "El Quseyya",
            "Sahel Selim", "Sanabo", "Sodfa"
        };
        public static List<string> Beheira = new List<string>()
        {
            "Abu Hummus", "Abu El Matamir", "Damanhur", "Edku", "El Delengat", "El Mahmoudiyah", "El Rahmaniya",
            "Itay El Barud", "Hosh Issa", "Kafr El Dawwar", "Koum Hamada", "Rosetta", "Shubrakhit", "Wadi El Natrun",
            "El Nubaria"
        };
        public static List<string> Beni_Suef = new List<string>()
        {
            "El Fashn", "El Wasta", "Biba", "Ihnasiya", "New Beni Suef", "Nasser", "Sumusta El Waqf"
        };
        public static List<string> Cairo = new List<string>()
        {
            "15 May City", "Abdeen", "El Darb El Ahmar", "Ain Shams", "Amreya", "Azbakeya", "El Basatin", "El Gamaliya",
            "El Khalifa", "Maadi", "El Marg", "El Masara", "El Matareya", "El Mokattam", "El Muski", "New Cairo",
            "El Weili", "El Nozha", "El Sharabiya", "El Shorouk", "El Salam", "El Sayeda Zeinab", "El Tebbin", "El Zaher",
            "Zamalek", "El Zawya El Hamra", "Zeitoun", "Bab El Sharia", "Bulaq", "Dar El Salam", "Helwan", "Nasr City",
            "Heliopolis", "Manshiyat Nase", "Shubra", "Tura"
        };
        public static List<string> Dakahlia = new List<string>()
        {
            "Aga", "Bilqas", "Damas", "Dikirnis", "El Gamaliya", "El Kurdi", "El Matareya", "El Senbellawein", "Gamasa",
            "Gogar", "Mansoura", "Manzala", "Mit Elkorama", "Mit Ghamr", "Mit Salsil", "Nabaroh", "Sherbin",
            "Temay El Amdeed", "Talkha"
        };
        public static List<string> Damietta = new List<string>()
        {
            "El Zarqa", "Damietta", "Faraskur", "Kafr El Battikh", "Kafr Saad", "New Damietta", "Ras El Bar"
        };
        public static List<string> Faiyum = new List<string>()
        {
            "Faiyum", "Ibsheway", "Itsa", "New Faiyum", "Sinnuris", "Tamiya", "Yousef El Seddik"
        };
        public static List<string> Gharbia = new List<string>()
        {
            "El Mahalla El Kubra", "Kafr El Zayat", "Samanoud", "Tanta", "Zifta", "El Santa", "Kotoor", "Basyoun"
        };
        public static List<string> Giza = new List<string>()
        {
            "Dokki", "Pyramids", "Agouza", "El Ayyat", "El Badrashein", "El Hawamdeya", "El Omraniya",
            "El Wahat El Bahariya", "El Warraq", "Sheikh Zayed City", "El Saff", "Atfeh", "Talbia", "Ossim",
            "Bulaq", "Imbaba", "Kerdasa"
        };
        public static List<string> Ismailia = new List<string>()
        {
            "Abu Suwir El Mahata", "Ismalia", "El Qantara", "El Qantara El Sharqiya", "New Kasaseen", "Tell El Kebir", "Fayid"
        };
        public static List<string> Kafr_El_Sheikh = new List<string>()
        {
            "El Hamool", "Baltim", "Biyala", "Desouk", "Fuwwah", "Kafr El Sheikh", "Metoubes", "Qallin", "El Reyad",
            "Sidi Salem"
        };
        public static List<string> Luxor = new List<string>()
        {
            "Qurna", "Luxor", "Armant", "Esna", "Tiba"
        };
        public static List<string> Matruh = new List<string>()
        {
            "El Daba", "El Alamein", "El Hamam", "El Negaila", "North Coast", "Sallum", "Mersa Matruh", "Sidi Barrani",
            "Siwa Oasis"
        };
        public static List<string> Minya = new List<string>()
        {
            "Abu Qirqas", "El Idwa", "Minya", "New Minya", "Beni Mazar", "Deir Mawas", "Maghagha", "Mallawi",
            "Matai", "Samalut"
        };
        public static List<string> Monufia = new List<string>()
        {
            "Shibin El Kom", "Menouf", "Ashmoun", "Sers El Lyan", "Tala", "El Bagour", "El Shohada", "Sadat City",
            "Quesna", "Birket El Sab", "Shanawan"
        };
        public static List<string> New_Valley = new List<string>()
        {
            "Kharga", "Balat", "Dakhla", "Farafra", "Baris"
        };
        public static List<string> North_Sinai = new List<string>()
        {
            "El Arishˇthe", "Nekhel", "Rafah", "Bir al-Abed", "Hassana", "Sheikh Zuweid"
        };
        public static List<string> Port_Said = new List<string>()
        {
            "El Dawahy", "El Arab", "El Ganoub", "El Manakh", "El Manasra", "El Sharq", "El Zohur", "Port Fuad",
            "Mubarak East"
        };
        public static List<string> Qalyubia = new List<string>()
        {
            "Banha", "Khanka", "Qaha", "Qalyub", "Shibin El Qanater", "Shubra El Kheima", "Tukh", "El Qanater El Khayreya",
            "Kafr Shukr", "Obour City", "Khusus"
        };
        public static List<string> Qena = new List<string>()
        {
            "Abu Tesht", "El Waqf", "Dishna", "Farshut", "Nag Hammadi", "Naqada", "Qift", "Qena", "Qus"
        };
        public static List<string> Red_Sea = new List<string>()
        {
            "El Qusair", "Shalateen", "Halaib", "Marsa Alam", "Ras Gharib"
        };
        public static List<string> Sharqia = new List<string>()
        {
            "10th of Ramadan", "Abu Hammad", "Abu Kebir", "Awlad Saqr", "Bilbeis", "Diyarb Negm", "El Husseiniya",
            "El Ibrahimiya", "El Qurein", "Faqous", "Hihya", "Kafr Saqr", "Mashtool El Souk", "Minya El Qamh",
            "El Salheya El Gedida", "Zagazig"
        };
        public static List<string> Sohag = new List<string>()
        {
            "Akhmim", "Dar El Salam", "El Balyana", "El Mansha", "El Maragha", "El Usayrat", "Girga", "Juhayna",
            "Sakulta", "Sohag", "Tahta", "Tima"
        };
        public static List<string> South_Sinai = new List<string>()
        {
            "Abu Radis", "El Tor", "Dahab", "Nuweiba", "Ras Sidr", "Saint Catherine", "Sharm El Sheikh", "Taba"
        };
        public static List<string> Suez = new List<string>()
        {
            "Arbaeen", "Ganayen", "Suez", "Attaka", "Faisal"
        };
    }
}
