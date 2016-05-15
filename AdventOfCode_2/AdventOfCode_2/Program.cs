using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<GiftBox> giftList = getData(Constants.inputFileName);
            reportResult(processWrappingPaper(giftList), "wrapping paper");
            reportResult(processRibbon(giftList), "ribbon");
            Console.ReadKey();
        }

        public static List<GiftBox> getData(String fileName)
        {
            FileStream inputFile = null;
            StreamReader inputLine = null;
            List<GiftBox> giftList = new List<GiftBox>();

            try
            {
                inputFile = new FileStream(fileName, FileMode.Open);
                inputLine = new StreamReader(inputFile);
                String rawInputText;
                String[] giftBoxDimensions;

                while ((rawInputText = inputLine.ReadLine()) != null)
                {
                    giftBoxDimensions = rawInputText.Split(Constants.stringSplitKey);

                    giftList.Add(new GiftBox(
                        Convert.ToInt32(giftBoxDimensions[0]),
                        Convert.ToInt32(giftBoxDimensions[1]),
                        Convert.ToInt32(giftBoxDimensions[2])));
                }
            }

            catch (IOException e)
            {
                Console.WriteLine("Cannot open file: " + e.Message + ".");
                throw e;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Input file is malformed.");
                throw e;
            }

            finally
            {
                if (inputFile != null) inputFile.Close();
                if (inputLine != null) inputLine.Close();
            }

            return giftList;
        }

        public static int processWrappingPaper(List<GiftBox> giftList)
        {
            int totalWrappingPaper = 0;

            foreach (var item in giftList)
                totalWrappingPaper = totalWrappingPaper + item.calcPaperOfBox();

            return totalWrappingPaper;
        }

        public static int processRibbon(List<GiftBox> giftList)
        {
            int totalRibbon = 0;

            foreach (var item in giftList)
                totalRibbon = totalRibbon + item.calcRibbon();

            return totalRibbon;
        }

        private static void reportResult(int reportValue, string type)
        {
            Console.WriteLine("The elves will need {0} feet of {1}.", reportValue.ToString("N0"), type);
        }
    }
}
