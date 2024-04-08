using System;
using System.Globalization;

namespace トレイン
{
    public record 電車(string Destination, int TrainNumber, DateTime DepartureTime)
    {
        public 電車(string destination, int trainNumber, string departureTime) : this(destination, trainNumber, DateTime.ParseExact(departureTime, "HH:mm", new CultureInfo("ja-JP")))
        {
        }

        public override string ToString()
        {
            return $"列車番号(Train Number): {TrainNumber}, 行き先(Destination): {Destination}, 出発時間(Departure Time): {DepartureTime:HH:mm}";
        }
    }
    class プログラム
    {
        static void Main()
        {
            電車[] trains =
            [
                new 電車("神楽坂(Kagurazaka)", 6710, "15:30"),
                new 電車("市ヶ谷(Ichigaya)", 9814, "14:00"),
                new 電車("四谷(Yotsuya)", 3125, "16:45"),
                new 電車("神保町(Jimbocho)", 1638, "13:20"),
                new 電車("秋葉原(Akihabara)", 6946, "17:05"),
            ];

            Array.Sort(trains, (t1, t2) => t1.TrainNumber.CompareTo(t2.TrainNumber));

            foreach (var train in trains)
            {
                Console.WriteLine(train);
            }

            Console.Write("列車番号を入力してください(Please enter your train number): ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());
            電車 trainInfo = Array.Find(trains, t => t.TrainNumber == trainNumber);
            if (trainInfo != null)
            {
                Console.WriteLine(trainInfo);
            }
            else
            {
                Console.WriteLine("このレベルの列車はありません.(Please enter your train number:)");
            }

            Array.Sort(trains, (t1, t2) =>
            {
                int destinationComparison = t1.Destination.CompareTo(t2.Destination);
                if (destinationComparison != 0)
                    return destinationComparison;
                else
                    return t1.DepartureTime.CompareTo(t2.DepartureTime);
            });

            Console.WriteLine("目的地と時刻ごとに並べられた列車(Trains sorted by destination and time):");
            foreach (var train in trains)
            {
                Console.WriteLine(train);
            }
        }
    }
}