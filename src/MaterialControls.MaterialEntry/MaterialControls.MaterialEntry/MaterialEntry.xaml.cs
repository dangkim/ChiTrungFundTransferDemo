﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaterialControls.MaterialEntry
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialEntry : ContentView
    {
        public static void Init() { }
        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialEntry), defaultBindingMode: BindingMode.TwoWay);
        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(MaterialEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.EntryField.Placeholder = (string)newval;
            matEntry.HiddenLabel.Text = (string)newval;
        });

        public static BindableProperty ValidationTextProperty = BindableProperty.Create(nameof(ValidationText), typeof(string), typeof(MaterialEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.HiddenValidationLabel.Text = (string)newval;
        });

        public static BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(MaterialEntry), defaultValue: true, propertyChanged: (bindable, oldVal, newval) =>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.HiddenValidationLabel.IsVisible = (bool)newval;
        });

        public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(MaterialEntry), defaultValue: false, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.EntryField.IsPassword = (bool)newVal;
        });

        public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(MaterialEntry), defaultValue: Keyboard.Default, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.EntryField.Keyboard = (Keyboard)newVal;
        });

        public static BindableProperty AccentColorProperty = BindableProperty.Create(nameof(AccentColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.Accent);

        public static BindableProperty ValidationColorProperty = BindableProperty.Create(nameof(ValidationColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.Accent);

        public Color AccentColor
        {
            get
            {
                return (Color)GetValue(AccentColorProperty);
            }
            set
            {
                SetValue(AccentColorProperty, value);
            }
        }

        public Color ValidationColor
        {
            get
            {
                return (Color)GetValue(AccentColorProperty);
            }
            set
            {
                SetValue(AccentColorProperty, value);
            }
        }
        public Keyboard Keyboard
        {
            get
            {
                return (Keyboard)GetValue(KeyboardProperty);
            }
            set
            {
                SetValue(KeyboardProperty, value);
            }
        }

        public bool IsPassword
        {
            get
            {
                return (bool)GetValue(IsPasswordProperty);
            }
            set
            {
                SetValue(IsPasswordProperty, value);
            }
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        public string Placeholder
        {
            get
            {
                return (string)GetValue(PlaceholderProperty);
            }
            set
            {
                SetValue(PlaceholderProperty, value);
            }
        }

        public string ValidationText
        {
            get
            {
                return (string)GetValue(ValidationTextProperty);
            }
            set
            {
                SetValue(ValidationTextProperty, value);
            }
        }

        public bool IsValid
        {
            get
            {
                return (bool)GetValue(IsValidProperty);
            }
            set
            {
                SetValue(IsValidProperty, value);
            }
        }

        public MaterialEntry()
        {
            InitializeComponent();

            HiddenValidationLabel.IsVisible = false;
            HiddenValidationLabel.TextColor = ValidationColor;

            HiddenLabel.IsVisible = false;

            EntryField.BindingContext = this;
            EntryField.Focused += async (s, a) =>
            {
                HiddenBottomBorder.BackgroundColor = AccentColor;

                HiddenLabel.TextColor = AccentColor;
                HiddenLabel.IsVisible = true;

                if (string.IsNullOrEmpty(EntryField.Text))
                {
                    // animate both at the same time
                    await Task.WhenAll(
                        HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, BottomBorder.Width, BottomBorder.Height), 200),
                        HiddenLabel.FadeTo(1, 60),
                        HiddenLabel.TranslateTo(HiddenLabel.TranslationX, EntryField.Y - EntryField.Height + 4, 200, Easing.SinIn)
                     );
                    EntryField.Placeholder = null;
                }
                else
                {
                    await HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, BottomBorder.Width, BottomBorder.Height), 200);
                }
            };
            EntryField.Unfocused += async (s, a) =>
            {
                HiddenLabel.TextColor = Color.Gray;
                if (string.IsNullOrEmpty(EntryField.Text))
                {
                    // animate both at the same time
                    await Task.WhenAll(
                        HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, 0, BottomBorder.Height), 200),
                        HiddenLabel.FadeTo(0, 180),
                        HiddenLabel.TranslateTo(HiddenLabel.TranslationX, EntryField.Y, 200, Easing.SinIn)
                     );
                    EntryField.Placeholder = Placeholder;
                }
                else
                {
                    await HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, 0, BottomBorder.Height), 200);
                }
            };
        }
    }
}