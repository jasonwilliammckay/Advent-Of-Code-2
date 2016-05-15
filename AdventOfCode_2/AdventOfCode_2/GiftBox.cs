using System;

namespace AdventOfCode_2
{
    public class GiftBox
    {
        private int height = 0;
        private int length = 0;
        private int width = 0;

        public GiftBox(int height, int length, int width)
        {
            // assume negative values should be positive instead
            this.height = Math.Abs(height);
            this.length = Math.Abs(length);
            this.width  = Math.Abs(width);
        }

        internal int calcPaperOfBox()
        {
            int area = getAreaOfBox() + getSlack();
            return area;
        }

        private int getAreaOfBox()
        {
            int area = (2 * length * width) + (2 * width * height) + (2 * height * length);
            return area;
        }

        private int getSlack()
        {
            int[] boxDimensions = { height, length, width };
            Array.Sort(boxDimensions);
            int area = boxDimensions[0] * boxDimensions[1];
            return area;
        }

        internal int calcRibbon()
        {
            int totalRibbon = ribbonPerimeter() + ribbonBow();
            return totalRibbon;
        }

        private int ribbonPerimeter()
        {
            int[] boxDimensions = { height, length, width };
            Array.Sort(boxDimensions);
            int area = (boxDimensions[0] * 2) + (boxDimensions[1] * 2);
            return area;
        }

        private int ribbonBow()
        {
            int volume = (height * length * width);
            return volume;
        }
    }
}