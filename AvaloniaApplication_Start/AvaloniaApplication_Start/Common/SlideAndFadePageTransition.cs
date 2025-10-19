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
    public class SlideAndFadePageTransition : IPageTransition
    {
        /// <summary>
        /// 动画持续时间
        /// </summary>
        public TimeSpan Duration { get; set; } = TimeSpan.FromMilliseconds(400);

        /// <summary>
        /// 缓动函数，默认使用三次贝塞尔曲线（类似 WPF 的流畅效果）
        /// </summary>
        public Easing Easing { get; set; } = new CubicEaseInOut();

        public async Task Start(Visual? from, Visual? to, bool forward, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            var tasks = new List<Task>();

            // 处理离开的页面
            if (from != null)
            {
                // 向左滑出并淡出
                var slideOutAnimation = new Animation
                {
                    Duration = Duration,
                    Easing = Easing,
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
                                new Setter(TranslateTransform.XProperty, -50d) // 轻微滑动，不要整个宽度
                            }
                        }
                    }
                };

                tasks.Add(slideOutAnimation.RunAsync(from, cancellationToken));
            }

            // 处理进入的页面
            if (to != null)
            {
                // 确保有 RenderTransform
                if (to.RenderTransform == null || to.RenderTransform is not TranslateTransform)
                {
                    to.RenderTransform = new TranslateTransform();
                }

                // 从右滑入并淡入
                var slideInAnimation = new Animation
                {
                    Duration = Duration,
                    Easing = Easing,
                    Children =
                    {
                        new KeyFrame
                        {
                            Cue = new Cue(0d),
                            Setters =
                            {
                                new Setter(Visual.OpacityProperty, 0d),
                                new Setter(TranslateTransform.XProperty, 80d) // 从右侧开始
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

            await Task.WhenAll(tasks);

            // 清理：重置 transform
            if (from != null && from.RenderTransform is TranslateTransform fromTransform)
            {
                fromTransform.X = 0;
            }
            if (to != null && to.RenderTransform is TranslateTransform toTransform)
            {
                toTransform.X = 0;
            }
        }
    }
}
