namespace PlanBackground
{
    using Microsoft.Toolkit.Uwp.Notifications;
    using Windows.UI.Notifications;

    public sealed class TileController
    {
        private const string Large = @"Assets\Square150x150Logo.scale-200.png";
        private const string Wide = @"Assets\SplashScreen.scale-200.png";
        private const string Medium = @"Assets\Square150x150Logo.scale-200.png";
        private const string Small = @"Assets\StoreLogo.png";

        public void UpdateNormal()
        {
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(new TileNotification(this.GenerateNormalTileContent().GetXml()));
        }

        public void UpdateClasses(SimpleClasses classses)
        {
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(new TileNotification(this.GenerateClassesTileContent(classses).GetXml()));
        }

        private TileContent GenerateNormalTileContent()
        {
            return new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = this.GenerateNormalTileBindingMedium(),
                    TileWide = this.GenerateNormalTileBindingWide(),
                    TileLarge = this.GenerateNormalTileBindingLarge(),
                    TileSmall = this.GenerateNormalTileBindingSmall()
                }
            };
        }

        private TileContent GenerateClassesTileContent(SimpleClasses classes)
        {
            return new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = this.GenerateNormalTileBindingMedium(),
                    TileWide = this.GenerateClassesTileBindingWide(classes),
                    TileLarge = this.GenerateClassesTileBindingLarge(classes),
                    TileSmall = this.GenerateNormalTileBindingSmall()
                }
            };
        }

        private TileBinding GenerateNormalTileBindingMedium()
        {
            return new TileBinding()
            {
                Content = new TileBindingContentAdaptive()
                {
                    PeekImage = new TilePeekImage()
                    {
                        Source = Medium,
                        HintCrop = TilePeekImageCrop.Circle
                    },
                    TextStacking = TileTextStacking.Center
                }
            };
        }

        private TileBinding GenerateNormalTileBindingSmall()
        {
            return new TileBinding()
            {
                Content = new TileBindingContentAdaptive()
                {
                    PeekImage = new TilePeekImage()
                    {
                        Source = Small,
                        HintCrop = TilePeekImageCrop.Circle
                    },
                    TextStacking = TileTextStacking.Center
                }
            };
        }

        private TileBinding GenerateNormalTileBindingWide()
        {
            return new TileBinding()
            {
                Content = new TileBindingContentAdaptive()
                {
                    Children =
                    {
                        new AdaptiveGroup()
                        {
                            Children =
                            {
                                new AdaptiveSubgroup()
                                {
                                    HintWeight = 33,
                                    Children = { new AdaptiveImage { Source = Wide, HintCrop = AdaptiveImageCrop.Circle } }
                                }
                            }
                        }
                    }
                }
            };
        }

        private TileBinding GenerateNormalTileBindingLarge()
        {
            return new TileBinding()
            {
                Content = new TileBindingContentAdaptive()
                {
                    TextStacking = TileTextStacking.Center,

                    Children =
                    {
                        new AdaptiveGroup()
                        {
                            Children =
                            {
                                new AdaptiveSubgroup()
                                {
                                    HintWeight = 2,
                                    Children =
                                    {
                                        new AdaptiveImage()
                                        {
                                            Source = Large,
                                            HintCrop = AdaptiveImageCrop.Circle
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        private TileBinding GenerateClassesTileBindingWide(SimpleClasses classes)
        {
            return new TileBinding()
            {
                Content = new TileBindingContentAdaptive()
                {
                    Children =
                {
                    new AdaptiveText()
                    {
                        Text = classes.Subject,
                        HintStyle = AdaptiveTextStyle.Caption,
                        HintWrap = true
                    },

                    new AdaptiveText()
                    {
                        Text = "Rozpoczęcie: " + classes.Start.ToString(@"hh\:mm"),
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },

                    new AdaptiveText()
                    {
                        Text = "Sala: " + classes.Room,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                }
                }
            };
        }

        private TileBinding GenerateClassesTileBindingLarge(SimpleClasses classes)
        {
            return new TileBinding()
            {
                Content = new TileBindingContentAdaptive()
                {
                    Children =
                {
                    new AdaptiveText()
                    {
                        Text = classes.Subject,
                        HintStyle = AdaptiveTextStyle.Caption,
                        HintWrap = true
                    },

                    new AdaptiveText()
                    {
                        Text = "Rozpoczęcie: " + classes.Start.ToString(@"hh\:mm"),
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },

                    new AdaptiveText()
                    {
                        Text = "Sala: " + classes.Room,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                }
                }
            };
        }
    }
}
