﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace H.Framework.WPF.Control.Controls
{
    [TemplatePart(Name = "PART_PreviousBtn", Type = typeof(RadioButtonEx))]
    [TemplatePart(Name = "PART_FirstPageBtn", Type = typeof(RadioButtonEx))]
    [TemplatePart(Name = "PART_LastPageBtn", Type = typeof(RadioButtonEx))]
    [TemplatePart(Name = "PART_NextBtn", Type = typeof(RadioButtonEx))]
    [TemplatePart(Name = "PART_PageNumberTxt", Type = typeof(TextBoxEx))]
    public class ClassicPager : System.Windows.Controls.Control
    {
        static ClassicPager()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ClassicPager), new FrameworkPropertyMetadata(typeof(ClassicPager)));
        }

        public ClassicPager()
        {
        }

        public ObservableCollection<KeyValuePair<string, int>> ListPageSize { get; set; } = new ObservableCollection<KeyValuePair<string, int>> { new KeyValuePair<string, int>("10", 10), new KeyValuePair<string, int>("20", 20), new KeyValuePair<string, int>("50", 50) };

        private KeyValuePair<string, int> _selectedPageSize;

        public KeyValuePair<string, int> SelectedPageSize
        {
            get => _selectedPageSize;
            set
            {
                _selectedPageSize = value;
                PageSize = _selectedPageSize.Value;
                MaxPageNubmer = (int)Math.Ceiling(DataCount / (decimal)PageSize);
            }
        }

        public int PageNumber
        {
            get;
            set;
        } = 1;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            CreateControl();
        }

        private ButtonEx _nextBtn, _previousBtn, _firstPageBtn, _lastPageBtn, _goToBtn;
        private TextBoxEx _pageNumberTxt;

        private void CreateControl()
        {
            _previousBtn = (ButtonEx)GetTemplateChild("PART_PreviousBtn");
            _firstPageBtn = (ButtonEx)GetTemplateChild("PART_FirstPageBtn");
            _lastPageBtn = (ButtonEx)GetTemplateChild("PART_LastPageBtn");
            _nextBtn = (ButtonEx)GetTemplateChild("PART_NextBtn");
            _goToBtn = (ButtonEx)GetTemplateChild("PART_GoToBtn");
            _pageNumberTxt = (TextBoxEx)GetTemplateChild("PART_PageNumberTxt");
            _firstPageBtn.Click += BTNClick;
            _lastPageBtn.Click += BTNClick;
            _previousBtn.Click += BTNClick;
            _nextBtn.Click += BTNClick;
            _goToBtn.Click += BTNClick;

            if (PageSize <= 0)
                throw new Exception("每页数据量不能为0或负数");
        }

        private void BTNClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as ButtonEx;
            switch (btn.Name)
            {
                case "PART_PreviousBtn":
                    if (CurrentPage > 1)
                        CurrentPage--;
                    break;

                case "PART_FirstPageBtn":
                    if (CurrentPage != 1)
                        CurrentPage = 1;
                    break;

                case "PART_LastPageBtn":
                    var max = MaxPageNubmer;
                    if (CurrentPage != max && max != 0)
                        CurrentPage = max;
                    break;

                case "PART_NextBtn":
                    if (CurrentPage < MaxPageNubmer)
                        CurrentPage++;
                    break;

                case "PART_GoToBtn":
                    if (PageNumber <= MaxPageNubmer && PageNumber > 0 && CurrentPage != PageNumber)
                        CurrentPage = PageNumber;
                    break;
            }
        }

        public static readonly DependencyProperty MaxPageNubmerProperty = DependencyProperty.Register("MaxPageNubmer", typeof(int), typeof(ClassicPager), new PropertyMetadata(0, null));

        /// <summary>
        /// 总页数
        /// </summary>
        [Description("获取或设置总页数")]
        [Category("Defined Properties")]
        public int MaxPageNubmer
        {
            get => (int)GetValue(MaxPageNubmerProperty);
            set => SetValue(MaxPageNubmerProperty, value);
        }

        public static readonly DependencyProperty DataCountProperty = DependencyProperty.Register("DataCount", typeof(int), typeof(ClassicPager), new PropertyMetadata(0, OnDataCountPropertyChangedCallback));

        /// <summary>
        /// 数据总数
        /// </summary>
        [Description("获取或设置数据总数")]
        [Category("Defined Properties")]
        public int DataCount
        {
            get => (int)GetValue(DataCountProperty);
            set => SetValue(DataCountProperty, value);
        }

        public static void OnDataCountPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as ClassicPager;
            var newCount = (int)e.NewValue;
            c.MaxPageNubmer = (int)Math.Ceiling(newCount / (decimal)c.PageSize);
        }

        public static readonly DependencyProperty PageSizeProperty = DependencyProperty.Register("PageSize", typeof(int), typeof(ClassicPager), new FrameworkPropertyMetadata(10, FrameworkPropertyMetadataOptions.None, null, null, false, UpdateSourceTrigger.PropertyChanged));

        /// <summary>
        /// 每页数据数
        /// </summary>
        [Description("获取或设置每页数据数")]
        [Category("Defined Properties")]
        public int PageSize
        {
            get => (int)GetValue(PageSizeProperty);
            set => SetValue(PageSizeProperty, value);
        }

        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register("CurrentPage", typeof(int), typeof(ClassicPager), new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.None, OnCurrentPagePropertyChangedCallback, null, false, UpdateSourceTrigger.PropertyChanged));

        /// <summary>
        /// 当前页码
        /// </summary>
        [Description("获取或设置当前页码")]
        [Category("Defined Properties")]
        public int CurrentPage
        {
            get => (int)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        public static void OnCurrentPagePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as ClassicPager;
            c.OnPageIndexChanged(e.OldValue, e.NewValue);
            c._pageNumberTxt.Text = e.NewValue.ToString();
        }

        public static readonly DependencyProperty BtnMouseOverColorProperty = DependencyProperty.Register("BtnMouseOverColor", typeof(Brush), typeof(ClassicPager), new PropertyMetadata(new SolidColorBrush(Colors.CadetBlue), null));

        /// <summary>
        /// MouseOver色
        /// </summary>
        [Description("获取或设置MouseOver色")]
        [Category("Defined Properties")]
        public Brush BtnMouseOverColor
        {
            get => (Brush)GetValue(BtnMouseOverColorProperty);
            set => SetValue(BtnMouseOverColorProperty, value);
        }

        public static readonly RoutedEvent PageIndexChangedEvent = EventManager.RegisterRoutedEvent("PageIndexChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(ClassicPager));

        [Description("选择项后触发")]
        public event RoutedPropertyChangedEventHandler<object> PageIndexChanged
        {
            add { AddHandler(PageIndexChangedEvent, value); }
            remove { RemoveHandler(PageIndexChangedEvent, value); }
        }

        protected virtual void OnPageIndexChanged(object oldValue, object newValue)
        {
            RaiseEvent(new RoutedPropertyChangedEventArgs<object>(oldValue, newValue, PageIndexChangedEvent));
        }

        public static readonly DependencyProperty ButtonBGProperty = DependencyProperty.Register("ButtonBG", typeof(Brush), typeof(ClassicPager), new UIPropertyMetadata(new SolidColorBrush(Colors.White), null));

        /// <summary>
        /// 按钮背景色
        /// </summary>
        [Description("获取或设置按钮背景色")]
        [Category("Defined Properties")]
        public Brush ButtonBG
        {
            get => (Brush)GetValue(ButtonBGProperty);
            set => SetValue(ButtonBGProperty, value);
        }

        public static readonly DependencyProperty ComboBoxBGProperty = DependencyProperty.Register("ComboBoxBG", typeof(Brush), typeof(ClassicPager), new UIPropertyMetadata(new SolidColorBrush(Colors.White), null));

        /// <summary>
        /// 下拉背景色
        /// </summary>
        [Description("获取或设置下拉背景色")]
        [Category("Defined Properties")]
        public Brush ComboBoxBG
        {
            get => (Brush)GetValue(ComboBoxBGProperty);
            set => SetValue(ComboBoxBGProperty, value);
        }

        public static readonly DependencyProperty ComboBoxDropBGProperty = DependencyProperty.Register("ComboBoxDropBG", typeof(Brush), typeof(ClassicPager), new UIPropertyMetadata(new SolidColorBrush(Colors.White), null));

        /// <summary>
        /// 下拉背景色
        /// </summary>
        [Description("获取或设置下拉背景色")]
        [Category("Defined Properties")]
        public Brush ComboBoxDropBG
        {
            get => (Brush)GetValue(ComboBoxDropBGProperty);
            set => SetValue(ComboBoxDropBGProperty, value);
        }

        public static readonly DependencyProperty ComboBoxDropShadowProperty = DependencyProperty.Register("ComboBoxDropShadow", typeof(Brush), typeof(ClassicPager), new UIPropertyMetadata(new SolidColorBrush(Colors.White), null));

        /// <summary>
        /// 下拉阴影色
        /// </summary>
        [Description("获取或设置下拉阴影色")]
        [Category("Defined Properties")]
        public Brush ComboBoxDropShadow
        {
            get => (Brush)GetValue(ComboBoxDropShadowProperty);
            set => SetValue(ComboBoxDropShadowProperty, value);
        }
    }
}