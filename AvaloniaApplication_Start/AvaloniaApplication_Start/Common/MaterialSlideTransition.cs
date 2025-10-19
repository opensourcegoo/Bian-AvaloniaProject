using Avalonia;
using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Media;
using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.Common
{
    #region 有闪烁问题
    //public class MaterialSlideTransition : IPageTransition
    //{
    //    /// <summary>
    //    /// 动画持续时间
    //    /// </summary>
    //    public TimeSpan Duration { get; set; } = TimeSpan.FromMilliseconds(300);

    //    /// <summary>
    //    /// 滑动方向
    //    /// </summary>
    //    public SlideDirection Direction { get; set; } = SlideDirection.Left;

    //    /// <summary>
    //    /// 滑动距离（像素）
    //    /// </summary>
    //    public double SlideDistance { get; set; } = 100;

    //    public async Task Start(Visual? from, Visual? to, bool forward, CancellationToken cancellationToken)
    //    {
    //        if (cancellationToken.IsCancellationRequested)
    //            return;

    //        var tasks = new List<Task>();

    //        // Material Design 使用的标准缓动曲线
    //        var decelerateEasing = new SplineEasing(0.0, 0.0, 0.2, 1.0); // 减速曲线
    //        var accelerateEasing = new SplineEasing(0.4, 0.0, 1.0, 1.0); // 加速曲线

    //        // 计算滑动方向
    //        double fromEndX = Direction == SlideDirection.Left ? -SlideDistance : SlideDistance;
    //        double toStartX = Direction == SlideDirection.Left ? SlideDistance : -SlideDistance;

    //        // 处理离开的页面（加速离开）
    //        if (from != null)
    //        {
    //            if (from.RenderTransform == null || from.RenderTransform is not TranslateTransform)
    //            {
    //                from.RenderTransform = new TranslateTransform();
    //            }

    //            var slideOutAnimation = new Animation
    //            {
    //                Duration = Duration,
    //                Easing = accelerateEasing,
    //                Children =
    //                {
    //                    new KeyFrame
    //                    {
    //                        Cue = new Cue(0d),
    //                        Setters =
    //                        {
    //                            new Setter(Visual.OpacityProperty, 1d),
    //                            new Setter(TranslateTransform.XProperty, 0d)
    //                        }
    //                    },
    //                    new KeyFrame
    //                    {
    //                        Cue = new Cue(1d),
    //                        Setters =
    //                        {
    //                            new Setter(Visual.OpacityProperty, 0d),
    //                            new Setter(TranslateTransform.XProperty, fromEndX)
    //                        }
    //                    }
    //                }
    //            };

    //            tasks.Add(slideOutAnimation.RunAsync(from, cancellationToken));
    //        }

    //        // 处理进入的页面（减速进入，Material Design 特色）
    //        if (to != null)
    //        {
    //            if (to.RenderTransform == null || to.RenderTransform is not TranslateTransform)
    //            {
    //                to.RenderTransform = new TranslateTransform();
    //            }

    //            var slideInAnimation = new Animation
    //            {
    //                Duration = Duration,
    //                Easing = decelerateEasing, // 关键：使用减速曲线让进入更流畅
    //                Children =
    //                {
    //                    new KeyFrame
    //                    {
    //                        Cue = new Cue(0d),
    //                        Setters =
    //                        {
    //                            new Setter(Visual.OpacityProperty, 0d),
    //                            new Setter(TranslateTransform.XProperty, toStartX)
    //                        }
    //                    },
    //                    new KeyFrame
    //                    {
    //                        Cue = new Cue(1d),
    //                        Setters =
    //                        {
    //                            new Setter(Visual.OpacityProperty, 1d),
    //                            new Setter(TranslateTransform.XProperty, 0d)
    //                        }
    //                    }
    //                }
    //            };

    //            tasks.Add(slideInAnimation.RunAsync(to, cancellationToken));
    //        }

    //        await Task.WhenAll(tasks);

    //        // 清理
    //        if (from != null && from.RenderTransform is TranslateTransform fromTransform)
    //        {
    //            fromTransform.X = 0;
    //        }
    //        if (to != null && to.RenderTransform is TranslateTransform toTransform)
    //        {
    //            toTransform.X = 0;
    //        }
    //    }
    //}
    #endregion

    public class MaterialSlideTransition : IPageTransition
    {
        /// <summary>
        /// 动画持续时间
        /// </summary>
        public TimeSpan Duration { get; set; } = TimeSpan.FromMilliseconds(300);

        /// <summary>
        /// 滑动方向
        /// </summary>
        public SlideDirection Direction { get; set; } = SlideDirection.Left;

        /// <summary>
        /// 滑动距离（像素）
        /// </summary>
        public double SlideDistance { get; set; } = 100;

        public async Task Start(Visual? from, Visual? to, bool forward, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            // Material Design 使用的标准缓动曲线
            var decelerateEasing = new SplineEasing(0.0, 0.0, 0.2, 1.0); // 减速曲线
            var accelerateEasing = new SplineEasing(0.4, 0.0, 1.0, 1.0); // 加速曲线

            // 根据 forward 参数决定实际滑动方向
            double fromEndX = forward
                ? (Direction == SlideDirection.Left ? -SlideDistance : SlideDistance)
                : (Direction == SlideDirection.Left ? SlideDistance : -SlideDistance);

            double toStartX = -fromEndX;

            var tasks = new List<Task>();

            // 处理离开的页面
            if (from != null)
            {
                // 确保初始状态正确
                var fromTransform = new TranslateTransform();
                from.RenderTransform = fromTransform;
                from.Opacity = 1.0;

                var slideOutAnimation = new Animation
                {
                    Duration = Duration,
                    Easing = accelerateEasing,
                    FillMode = FillMode.Forward, // 保持最终状态
                    Children =
                {
                    new KeyFrame
                    {
                        Cue = new Cue(0d),
                        Setters =
                        {
                            new Setter(Visual.OpacityProperty, 1d),
                            new Setter(TranslateTransform.XProperty, 0d)
                        }
                    },
                    new KeyFrame
                    {
                        Cue = new Cue(1d),
                        Setters =
                        {
                            new Setter(Visual.OpacityProperty, 0d),
                            new Setter(TranslateTransform.XProperty, fromEndX)
                        }
                    }
                }
                };

                tasks.Add(slideOutAnimation.RunAsync(from, cancellationToken));
            }

            // 处理进入的页面
            if (to != null)
            {
                // 确保初始状态正确
                var toTransform = new TranslateTransform();
                to.RenderTransform = toTransform;
                to.Opacity = 0.0;

                var slideInAnimation = new Animation
                {
                    Duration = Duration,
                    Easing = decelerateEasing,
                    FillMode = FillMode.Forward, // 保持最终状态
                    Children =
                {
                    new KeyFrame
                    {
                        Cue = new Cue(0d),
                        Setters =
                        {
                            new Setter(Visual.OpacityProperty, 0d),
                            new Setter(TranslateTransform.XProperty, toStartX)
                        }
                    },
                    new KeyFrame
                    {
                        Cue = new Cue(1d),
                        Setters =
                        {
                            new Setter(Visual.OpacityProperty, 1d),
                            new Setter(TranslateTransform.XProperty, 0d)
                        }
                    }
                }
                };

                tasks.Add(slideInAnimation.RunAsync(to, cancellationToken));
            }

            // 等待所有动画完成
            await Task.WhenAll(tasks);

            // 动画完成后清理，确保状态正确
            if (from != null)
            {
                from.RenderTransform = null;
                from.Opacity = 1.0;
            }

            if (to != null)
            {
                to.RenderTransform = null;
                to.Opacity = 1.0;
            }
        }
    }

    /// <summary>
    /// 增强版 Material Design 过渡，带有更复杂的效果
    /// 包含轻微的缩放效果，更接近真实的 Material Design
    /// </summary>
    public class MaterialSlideScaleTransition : IPageTransition
    {
        public TimeSpan Duration { get; set; } = TimeSpan.FromMilliseconds(350);
        public SlideDirection Direction { get; set; } = SlideDirection.Left;
        public double SlideDistance { get; set; } = 100;

        /// <summary>
        /// 缩放比例（0.9 表示缩小到 90%）
        /// </summary>
        public double ScaleFactor { get; set; } = 0.95;

        public async Task Start(Visual? from, Visual? to, bool forward, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            var tasks = new List<Task>();
            var decelerateEasing = new SplineEasing(0.0, 0.0, 0.2, 1.0);
            var accelerateEasing = new SplineEasing(0.4, 0.0, 1.0, 1.0);

            double fromEndX = Direction == SlideDirection.Left ? -SlideDistance : SlideDistance;
            double toStartX = Direction == SlideDirection.Left ? SlideDistance : -SlideDistance;

            // 离开页面：滑出 + 淡出 + 轻微缩小
            if (from != null)
            {
                var transformGroup = new TransformGroup();
                transformGroup.Children.Add(new TranslateTransform());
                transformGroup.Children.Add(new ScaleTransform());
                from.RenderTransform = transformGroup;
                from.RenderTransformOrigin = new RelativePoint(0.5, 0.5, RelativeUnit.Relative);

                var slideOutAnimation = new Animation
                {
                    Duration = Duration,
                    Easing = accelerateEasing,
                    Children =
                    {
                        new KeyFrame
                        {
                            Cue = new Cue(0d),
                            Setters =
                            {
                                new Setter(Visual.OpacityProperty, 1d),
                                new Setter(TranslateTransform.XProperty, 0d),
                                new Setter(ScaleTransform.ScaleXProperty, 1d),
                                new Setter(ScaleTransform.ScaleYProperty, 1d)
                            }
                        },
                        new KeyFrame
                        {
                            Cue = new Cue(1d),
                            Setters =
                            {
                                new Setter(Visual.OpacityProperty, 0d),
                                new Setter(TranslateTransform.XProperty, fromEndX),
                                new Setter(ScaleTransform.ScaleXProperty, ScaleFactor),
                                new Setter(ScaleTransform.ScaleYProperty, ScaleFactor)
                            }
                        }
                    }
                };

                tasks.Add(slideOutAnimation.RunAsync(from, cancellationToken));
            }

            // 进入页面：滑入 + 淡入 + 从缩小到正常
            if (to != null)
            {
                var transformGroup = new TransformGroup();
                transformGroup.Children.Add(new TranslateTransform());
                transformGroup.Children.Add(new ScaleTransform());
                to.RenderTransform = transformGroup;
                to.RenderTransformOrigin = new RelativePoint(0.5, 0.5, RelativeUnit.Relative);

                var slideInAnimation = new Animation
                {
                    Duration = Duration,
                    Easing = decelerateEasing,
                    Children =
                    {
                        new KeyFrame
                        {
                            Cue = new Cue(0d),
                            Setters =
                            {
                                new Setter(Visual.OpacityProperty, 0d),
                                new Setter(TranslateTransform.XProperty, toStartX),
                                new Setter(ScaleTransform.ScaleXProperty, ScaleFactor),
                                new Setter(ScaleTransform.ScaleYProperty, ScaleFactor)
                            }
                        },
                        new KeyFrame
                        {
                            Cue = new Cue(1d),
                            Setters =
                            {
                                new Setter(Visual.OpacityProperty, 1d),
                                new Setter(TranslateTransform.XProperty, 0d),
                                new Setter(ScaleTransform.ScaleXProperty, 1d),
                                new Setter(ScaleTransform.ScaleYProperty, 1d)
                            }
                        }
                    }
                };

                tasks.Add(slideInAnimation.RunAsync(to, cancellationToken));
            }

            await Task.WhenAll(tasks);

            // 清理
            if (from != null) from.RenderTransform = null;
            if (to != null) to.RenderTransform = null;
        }
    }

    public enum SlideDirection
    {
        Left,
        Right,
        Up,
        Down
    }
}

