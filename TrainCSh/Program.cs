using System;
using System.Globalization;

namespace トレイン // Train
{
    public record 電車(string 行き先, int 列車番号, DateTime 出発時間)
    {
        public 電車(string 行き先, int 列車番号, string 出発時間) : this(行き先, 列車番号, DateTime.ParseExact(出発時間, "HH:mm", new CultureInfo("ja-JP")))
        {
        }

        public override string ToString()
        {
            return $"列車番号: {列車番号}, 行き先: {行き先}, 出発時間: {出発時間:HH:mm}";
        }
    }
    class プログラム // Program
    {
        static void Main()
        {
            電車[] 電車の配列 =
            [
                new 電車("神楽坂 (カグラザカ)", 6710, "15:30"),
                new 電車("市ヶ谷 (イチガヤ)", 9814, "14:00"),
                new 電車("四谷 (ヨツヤ)", 3125, "16:45"),
                new 電車("神保町 (ジンボウチョウ)", 1638, "13:20"),
                new 電車("秋葉原 (アキハバラ)", 6946, "17:05"),
            ];

            // Сначала сортируем по номеру поезда
            Array.Sort(電車の配列, (電車1, 電車2) => 電車1.列車番号.CompareTo(電車2.列車番号));

            // Затем сортируем по направлению и времени отправления
            Array.Sort(電車の配列, (電車1, 電車2) =>
            {
                int 行き先比較 = 電車1.行き先.CompareTo(電車2.行き先);
                if (行き先比較 != 0)
                    return 行き先比較;
                else
                    return 電車1.出発時間.CompareTo(電車2.出発時間);
            });

            // Выводим отсортированный список поездов
            Console.WriteLine("目的地と時刻ごとに並べられた列車:");
            foreach (var 電車 in 電車の配列)
            {
                Console.WriteLine(電車);
            }
        }
    }
}

// English Translations for Comments:
// public record 電車(string 行き先, int 列車番号, DateTime 出発時間) -> public record Train(string Destination, int TrainNumber, DateTime DepartureTime)
// public Train(string destination, int trainNumber, string departureTime) : this(destination, trainNumber, DateTime.ParseExact(departureTime, "HH:mm", new CultureInfo("ja-JP")))
// return $"Train Number: {TrainNumber}, Destination: {Destination}, Departure Time: {DepartureTime:HH:mm}";
// Train[] trains =
// new Train("Kagurazaka", 6710, "15:30"),
// new Train("Ichigaya", 9814, "14:00"),
// new Train("Yotsuya", 3125, "16:45"),
// new Train("Jimbocho", 1638, "13:20"),
// new Train("Akihabara", 6946, "17:05"),
// Array.Sort(trains, (train1, train2) => train1.TrainNumber.CompareTo(train2.TrainNumber));
// Forward Sort by Train Number
// Then Sort by Destination and Departure Time
// Trains sorted by destination and time:
// foreach (var train in trains)
// Console.WriteLine(train);