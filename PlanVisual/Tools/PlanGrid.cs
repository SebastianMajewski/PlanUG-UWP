namespace PlanVisual.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Controls;
    using Plan.DataClasses;
    using Plan.Enums;
    using Plan.Tools;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class PlanGrid
    {
        private readonly Dictionary<NamedDay, int> dayColumns;
        private readonly Dictionary<TimeSpan, int> hourRows;
        private readonly Dictionary<TimeSpan, int> exactHourRow;
        private readonly MinMaxValues minMaxValues;
        private readonly DaysAndHours daysAndHours;

        public PlanGrid(List<ExtendedClasses> classes)
        {
            if (classes.Count == 0)
            {
                this.Grid = new Grid();
            }

            classes = classes.OrderBy(x => x.StartsAt).ToList();
            this.dayColumns = new Dictionary<NamedDay, int>();
            this.hourRows = new Dictionary<TimeSpan, int>();
            this.exactHourRow = new Dictionary<TimeSpan, int>();
            this.ResolveHourRows(classes);
            this.ResolveDayColumns(classes);
            this.minMaxValues = this.GetMinMax(classes);
            this.daysAndHours = this.GetDaysAndHours();           
            this.Grid = this.GetGrid();
            this.AddBasicItems();
            this.ResolveExacthourRows(classes);
            foreach (var c in classes)
            {
                var tile = new PlanGridTile { Classes = c };
                this.Grid.Children.Add(tile);
                var position = this.CalculatePosition(c);
                Grid.SetColumn(tile, position[0]);
                Grid.SetRow(tile, position[1]);
                Grid.SetRowSpan(tile, this.CalculateSpan(c.Hours));
            }
        }

        public Grid Grid { get; private set; }

        private void ResolveDayColumns(List<ExtendedClasses> classes)
        {
            var minMax = this.GetMinMax(classes);
            var byDay = classes.GroupBy(x => x.Day.Day);
            foreach (var day in byDay)
            {
                var max = 0;
                for (var hour = minMax.MinHour.Hours; hour <= minMax.MaxHour.Hours; hour++)
                {
                    var inHour = 0;
                    foreach (var c in day)
                    {
                        if (c.Hours.TimeTo.HasValue)
                        {
                            if (c.Hours.TimeFrom != null && (hour >= c.Hours.TimeFrom.Value.Hours && hour <= c.Hours.TimeTo.Value.Hours))
                            {
                                inHour++;
                            }
                        }
                        else
                        {
                            if (c.Hours.TimeFrom != null && hour == c.Hours.TimeFrom.Value.Hours)
                            {
                                inHour++;
                            }
                        }
                    }

                    if (inHour > max)
                    {
                        max = inHour;
                    }
                }

                this.dayColumns.Add(day.Key, max);
            }
        }

        private void ResolveHourRows(List<ExtendedClasses> classes)
        {
            var byHour = classes.GroupBy(x => 
            {
                if (x.StartsAt != null)
                {
                    return TimeSpan.FromHours(x.StartsAt.Value.Hours);
                }
                else
                {
                    return TimeSpan.FromHours(0);
                }
            });
            foreach (var hour in byHour)
            {
                var byDay = hour.GroupBy(x => x.Day.Day);
                var h = new List<TimeSpan?>(); 
                foreach (var day in byDay)
                {
                    foreach (var c in day)
                    {
                        if (!h.Contains(c.StartsAt))
                        {
                            h.Add(c.StartsAt);
                        }
                    }
                }

                this.hourRows.Add(hour.Key, h.Count);
            }
        }

        private void ResolveExacthourRows(List<ExtendedClasses> classes)
        {
            var hours = classes.Where(x => x.Hours.TimeFrom.HasValue).Select(x => x.Hours.TimeFrom.Value).ToList();
            hours.AddRange(classes.Where(x => x.Hours.TimeTo.HasValue).Select(x => x.Hours.TimeTo.Value));
            hours.AddRange(this.daysAndHours.Hours);
            var actualRow = 1;
            foreach (var h in hours.OrderBy(x => x))
            {
                if (!this.exactHourRow.ContainsKey(h))
                {
                    this.exactHourRow.Add(h, actualRow);
                    actualRow++;
                }               
            }
        }

        private MinMaxValues GetMinMax(List<ExtendedClasses> classes)
        {
            var result = new MinMaxValues();
            foreach (var c in classes)
            {
                if (c.Day.Day > result.MaxDay)
                {
                    result.MaxDay = c.Day.Day;
                }

                if (c.Day.Day < result.MinDay)
                {
                    result.MinDay = c.Day.Day;
                }

                if (c.Hours.TimeFrom.HasValue && c.Hours.TimeFrom.Value > result.MaxHour)
                {
                    result.MaxHour = c.Hours.TimeFrom.Value;
                }

                if (c.Hours.TimeTo.HasValue && c.Hours.TimeTo.Value > result.MaxHour)
                {
                    result.MaxHour = c.Hours.TimeTo.Value;
                }

                if (c.Hours.TimeFrom.HasValue && c.Hours.TimeFrom.Value < result.MinHour)
                {
                    result.MinHour = c.Hours.TimeFrom.Value;
                }

                if (c.Hours.TimeTo.HasValue && c.Hours.TimeTo.Value < result.MinHour)
                {
                    result.MinHour = c.Hours.TimeTo.Value;
                }
            }

            return result;
        }

        private DaysAndHours GetDaysAndHours()
        {
            var result = new DaysAndHours();
            var hourToAdd = this.minMaxValues.MinHour;
            do
            {
                result.Hours.Add(hourToAdd);
                hourToAdd = hourToAdd.Add(TimeSpan.FromHours(1));
            }
            while (hourToAdd <= this.minMaxValues.MaxHour);

            if (this.minMaxValues.MinDay == NamedDay.Saturday)
            {
                result.Days.Add(NamedDay.Saturday);
                result.Days.Add(NamedDay.Sunday);
            }
            else
            {
                result.Days.Add(NamedDay.Monday);
                result.Days.Add(NamedDay.Tuesday);
                result.Days.Add(NamedDay.Wednesday);
                result.Days.Add(NamedDay.Thursday);
                result.Days.Add(NamedDay.Friday);
                if (this.minMaxValues.MaxDay == NamedDay.Saturday)
                {
                    result.Days.Add(NamedDay.Saturday);
                }

                if (this.minMaxValues.MaxDay == NamedDay.Sunday)
                {
                    result.Days.Add(NamedDay.Saturday);
                    result.Days.Add(NamedDay.Sunday);
                }
            }

            return result;
        }

        private Grid GetGrid()
        {
            var grid = new Grid();
            foreach (var day in this.daysAndHours.Days)
            {
                var count = 1;
                if (this.dayColumns.ContainsKey(day))
                {
                    count = this.dayColumns[day];
                }

                for (var i = 0; i <= count; i++)
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                }
            }

            foreach (var hour in this.daysAndHours.Hours)
            {
                var count = 1;
                if (this.hourRows.ContainsKey(hour))
                {
                    count = this.hourRows[hour];
                }

                for (var i = 0; i <= count; i++)
                {
                    grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                }
            }
            return grid;
        }

        private void AddBasicItems()
        {
            var actualColumn = 1;
            foreach (var d in this.daysAndHours.Days)
            {
                var day = new PlanGridHeader { Text = d.ToDisplayString() };
                this.Grid.Children.Add(day);
                Grid.SetColumn(day, actualColumn);
                if (this.dayColumns.ContainsKey(d))
                {
                    var span = this.dayColumns[d];
                    Grid.SetColumnSpan(day, span);
                    actualColumn += span;
                }
                else
                {
                    actualColumn++;
                }
            }

            var actualRow = 1;
            foreach (var h in this.daysAndHours.Hours)
            {
                var hour = new PlanGridHeader { Text = h.Hours.ToString("00") + ":00" };
                this.Grid.Children.Add(hour);
                Grid.SetRow(hour, actualRow);
                if (this.hourRows.ContainsKey(h))
                {
                    var span = this.hourRows[h];
                    Grid.SetRowSpan(hour, span);
                    actualRow += span;
                }
                else
                {
                    actualRow++;
                }               
            }
        }

        private int[] CalculatePosition(ExtendedClasses classes)
        {
            var result = new[] { 1, 1 };
            foreach (var day in this.daysAndHours.Days)
            {
                if (classes.Day.Day != day)
                {
                    if (this.dayColumns.ContainsKey(day))
                    {
                        result[0] += this.dayColumns[day];
                    }
                    else
                    {
                        result[0]++;
                    }
                }
                else
                {
                    break;
                }
            }

            result[1] = this.exactHourRow[classes.StartsAt.Value];

            while (!this.IsEmpty(result[0], result[1]))
            {
                result[0]++;
            }

            return result;
        }

        private int CalculateSpan(TimeInterval hours)
        {
            if (hours.TimeFrom != null)
            {
                if (hours.TimeTo.HasValue)
                {
                    var start = this.exactHourRow[hours.TimeFrom.Value];
                    var end = this.exactHourRow[hours.TimeTo.Value];
                    return end - start;
                }
                else
                {
                    var start = this.exactHourRow[hours.TimeFrom.Value];
                    var end = this.exactHourRow[hours.TimeFrom.Value + TimeSpan.FromHours(1)];
                    return end - start;
                }
            }
            else
            {
                return 1;
            }
        }

        private bool IsEmpty(int col, int row)
        {
            var columns = this.Grid.Children.Where(e => Grid.GetColumn((FrameworkElement)e) == col);
            foreach (var column in columns)
            {
                if (Grid.GetRow((FrameworkElement)column) + Grid.GetRowSpan((FrameworkElement)column) - 1 >= row)
                {
                    return false;
                }
            }

            return true;
        }

        private class DaysAndHours
        {
            public DaysAndHours()
            {
                this.Days = new List<NamedDay>();
                this.Hours = new List<TimeSpan>();
            }

            public List<NamedDay> Days { get; set; }

            public List<TimeSpan> Hours { get; set; }
        }

        private class MinMaxValues
        {
            public MinMaxValues()
            {
                this.MinDay = NamedDay.Sunday;
                this.MaxDay = NamedDay.Monday;
                this.MinHour = TimeSpan.FromHours(24);
                this.MaxHour = TimeSpan.FromHours(0);
            }

            public NamedDay MinDay { get; set; }

            public NamedDay MaxDay { get; set; }

            public TimeSpan MinHour { get; set; }

            public TimeSpan MaxHour { get; set; }
        }
    }
}
