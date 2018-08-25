using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    /// <summary>
    /// Given n non-negative integers a1, a2, ..., an , 
    /// where each represents a point at coordinate (i, ai). 
    /// n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). 
    /// Find two lines, which together with x-axis forms a container, 
    /// such that the container contains the most water.
    /// Note: You may not slant the container and n is at least 2.
    /// The above vertical lines are represented by array[1, 8, 6, 2, 5, 4, 8, 3, 7]. 
    /// In this case, the max area of water (blue section) the container can contain is 49. 
    ///   Example:
    ///     Input: [1,8,6,2,5,4,8,3,7]
    ///     Output: 49
    /// </summary>
    public class ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            if (height == null || height.Length == 0)
                return 0;

            int res = 0;
            int h, w, area = 0;
            int last = height.Length - 1;

            for (int i = 0; i < last; i++)
            {
                if (i > 0 && height[i] < height[i - 1]) continue;

                for (int j = last; j > i; j--)
                {
                    if ((j != last) && height[j] < height[j + 1]) continue;

                    h = Math.Min(height[i], height[j]);
                    w = j - i;
                    area = h * w;

                    if (area > res) res = area;
                }
            }

            return res;
        }
    }
}
