﻿using System;
using System.Collections.Generic;

namespace UniRx.Operators
{
    internal class ObserveOnObservable<T> : OperatorObservableBase<T>
    {
        readonly IObservable<T> source;
        readonly IScheduler scheduler;

        public ObserveOnObservable(IObservable<T> source, IScheduler scheduler)
            : base(source.IsRequiredSubscribeOnCurrentThread())
        {
            this.source = source;
            this.scheduler = scheduler;
        }

        protected override IDisposable SubscribeCore(IObserver<T> observer, IDisposable cancel)
        {
            var queueing = scheduler as ISchedulerQueueing;
            if (queueing == null)
            {
                return new ObserveOn(this, observer, cancel).Run();
            }
            else
            {
                return new ObserveOn_(this, queueing, observer, cancel).Run();
            }
        }

        class ObserveOn : OperatorObserverBase<T, T>
        {
            readonly ObserveOnObservable<T> parent;
            readonly LinkedList<IDisposable> scheduleDisposables = new LinkedList<IDisposable>();
            bool isDisposed;

            public ObserveOn(ObserveOnObservable<T> parent, IObserver<T> observer, IDisposable cancel) : base(observer, cancel)
            {
                this.parent = parent;
            }

            public IDisposable Run()
            {
                isDisposed = false;

                var sourceDisposable = parent.source.Subscribe(this);

                return StableCompositeDisposable.Create(sourceDisposable, Disposable.Create(() =>
                {
                    lock (scheduleDisposables)
                    {
                        isDisposed = true;

                        foreach (var item in scheduleDisposables)
                        {
                            item.Dispose();
                        }
                        scheduleDisposables.Clear();
                    }
                }));
            }

            public override void OnNext(T value)
            {
                var self = new SingleAssignmentDisposable();
                LinkedListNode<IDisposable> node;
                lock (scheduleDisposables)
                {
                    if (isDisposed) return;

                    node = scheduleDisposables.AddLast(self);
                }
                self.Disposable = parent.scheduler.Schedule(() =>
                {
                    self.Dispose();
                    lock (scheduleDisposables)
                    {
                        if (node.List != null)
                        {
                            node.List.Remove(node);
                        }
                    }
                    base.observer.OnNext(value);
                });
            }

            public override void OnError(Exception error)
            {
                var self = new SingleAssignmentDisposable();
                LinkedListNode<IDisposable> node;
                lock (scheduleDisposables)
                {
                    if (isDisposed) return;

                    node = scheduleDisposables.AddLast(self);
                }
                self.Disposable = parent.scheduler.Schedule(() =>
                {
                    self.Dispose();
                    lock (scheduleDisposables)
                    {
                        if (node.List != null)
                        {
                            node.List.Remove(node);
                        }
                    }
                    try { observer.OnError(error); } finally { Dispose(); };
                });
            }

            public override void OnCompleted()
            {
                var self = new SingleAssignmentDisposable();
                LinkedListNode<IDisposable> node;
                lock (scheduleDisposables)
                {
                    if (isDisposed) return;

                    node = scheduleDisposables.AddLast(self);
                }
                self.Disposable = parent.scheduler.Schedule(() =>
                {
                    self.Dispose();
                    lock (scheduleDisposables)
                    {
                        if (node.List != null)
                        {
                            node.List.Remove(node);
                        }
                    }
                    try { observer.OnCompleted(); } finally { Dispose(); };
                });
            }
        }

        class ObserveOn_ : OperatorObserverBase<T, T>
        {
            readonly ObserveOnObservable<T> parent;
            readonly ISchedulerQueueing scheduler;
            readonly BooleanDisposable isDisposed;

            public ObserveOn_(ObserveOnObservable<T> parent, ISchedulerQueueing scheduler, IObserver<T> observer, IDisposable cancel) : base(observer, cancel)
            {
                this.parent = parent;
                this.scheduler = scheduler;
                this.isDisposed = new BooleanDisposable();
            }

            public IDisposable Run()
            {
                var sourceDisposable = parent.source.Subscribe(this);
                return StableCompositeDisposable.Create(sourceDisposable, isDisposed);
            }

            void OnNext_(T value)
            {
                base.observer.OnNext(value);
            }

            public override void OnNext(T value)
            {
                scheduler.ScheduleQueueing(isDisposed, value, OnNext_);
            }

            public override void OnError(Exception error)
            {
                try { observer.OnError(error); } finally { Dispose(); };
            }

            public override void OnCompleted()
            {
                try { observer.OnCompleted(); } finally { Dispose(); };
            }
        }
    }
}