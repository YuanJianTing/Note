namespace NoteClient.Controls
{
    internal class AnimationManager
    {

        public static void AnimIn(Control control)
        {
            new Animation(-40, 0, 5, Value =>
            {
                control.Location = new Point(control.Left, Value);
            })
                 .StartCallback(() => control.Visible = true)
                 .SetSpeed(2)
                .StartAnimation();
        }
        public static void AnimOut(Control control)
        {
            new Animation(0, -40, 5, Value =>
            {
                control.Location = new Point(control.Left, Value);
            })
                .EndCallback(() => control.Visible = false)
                .SetSpeed(-2)
                .StartAnimation();
        }

        class Animation
        {
            private readonly System.Windows.Forms.Timer _animationTimer;
            private readonly int max = 0;
            private int start;
            private Action? OnStart;
            private Action? OnEnd;

            public Animation(int start, int max, int interval = 5, Action<int>? onUpdate = null)
            {
                this.OnUpdate = onUpdate;
                this.max = max;
                this.start = start;
                _animationTimer = new System.Windows.Forms.Timer();
                _animationTimer.Interval = interval;
                _animationTimer.Tick += AnimationTimerOnTick;
            }

            public int Value { get; private set; }
            public int Speed { get; set; } = 1;

            public Action<int>? OnUpdate { get; set; }

            private void AnimationTimerOnTick(object sender, EventArgs eventArgs)
            {
                Value += Speed;
                OnUpdate?.Invoke(Value);
                if (Value == max)
                {
                    _animationTimer.Stop();
                    OnEnd?.Invoke();
                }
            }

            public Animation SetSpeed(int speed)
            {
                Speed = speed;
                return this;
            }

            public Animation EndCallback(Action action)
            {
                this.OnEnd = action;
                return this;
            }

            public Animation StartCallback(Action action)
            {
                this.OnStart = action;
                return this;
            }

            public void StartAnimation()
            {
                if (IsAnimating()) return;
                Value = start;
                OnStart?.Invoke();
                _animationTimer.Start();
            }

            public bool IsAnimating()
            {
                return _animationTimer.Enabled;
            }
        }
    }
}
