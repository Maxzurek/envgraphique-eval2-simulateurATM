using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

/*
 * Title: Custom form input field.
 * Author: Maxime Cesare-Zurek
 * Date: 9/16/2021
 * Purpose: Use in any wpf application form page
 * 
 * Public API:
 *              _________Highlight the field to display an error_________
 *              displayError()
 *              displayError(Brush highlightColor)
 *              displayError(string errorMessage)
 *              displayError(string errorMessage, Brush highlightColor)
 *              
 *              __________________Remove the error_______________________
 *              removeError()
 *    
 *    
 * Properties using Dependency Property:
 *          Input,
 *          TooltipFontsize,
 *          FieldNameRowPosition,
 *          FieldNameRowPosition,
 *          
 */

namespace WPFCustomControl
{

    /// <summary>
    /// Interaction logic for InputField.xaml
    /// </summary>
    public partial class InputField : UserControl
    {
        /// <summary>
        /// Used to store some of the user control default properties
        /// when the object is loaded by the form.
        /// </summary>
        public struct ResetValues
        {
            public Brush fieldBorderColor;
            public Brush fieldNameForegroundColor;
            public Brush tooltipForegroundColor;
            public string tooltip;
        }


        /**********************************************************************************************************
        * Properties
        ***********************************************************************************************************/
        private readonly double fieldNameUpFontRatio = 0.80;

        private bool fieldNameUp = true;

        private ResetValues resetValues;

        //Represents the field.Text input
        public string Input
        {
            get { return (string)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }
        public static readonly DependencyProperty InputProperty =
            DependencyProperty.Register("Input", typeof(string), typeof(InputField), new PropertyMetadata("", OnPropertyChanged));

        [Description("Sets the tooltip's font size"), Category("Custom InputField")]
        public double TooltipFontsize
        {
            get { return (double)GetValue(TooltipFontsizeProperty); }
            set { SetValue(TooltipFontsizeProperty, value); }
        }
        public static readonly DependencyProperty TooltipFontsizeProperty =
            DependencyProperty.Register("TooltipFontsize", typeof(double), typeof(InputField), new PropertyMetadata(12.0, OnPropertyChanged));

        public int FieldNameRowPosition
        {
            get { return (int)GetValue(FieldNameRowPositionProperty); }
            set { SetValue(FieldNameRowPositionProperty, value); }
        }
        public static readonly DependencyProperty FieldNameRowPositionProperty =
            DependencyProperty.Register("FieldNameRowPosition", typeof(int), typeof(InputField), new PropertyMetadata(0));

        [Description("Sets the default highlight color when the method showError() is called"), Category("Custom InputField")]
        public Brush DefaultErrorHighlightColor
        {
            get { return (Brush)GetValue(DefaultErrorHighlightColorProperty); }
            set { SetValue(DefaultErrorHighlightColorProperty, value); }
        }
        public static readonly DependencyProperty DefaultErrorHighlightColorProperty =
            DependencyProperty.Register("DefaultErrorHighlightColor", typeof(Brush), typeof(InputField), new PropertyMetadata(Brushes.Red));


        [Description("Determine if the field is editable "), Category("Custom InputField")]
        public bool Editable
        {
            get { return (bool)GetValue(EditableProperty); }
            set { SetValue(EditableProperty, value); }
        }
        public static readonly DependencyProperty EditableProperty =
            DependencyProperty.Register("Editable", typeof(bool), typeof(InputField), new PropertyMetadata(true, OnPropertyChanged));

        [Description("Sets the field's font size"), Category("Custom InputField")]
        public double FieldFontSize
        {
            get { return (double)GetValue(FieldFontSizeProperty); }
            set { SetValue(FieldFontSizeProperty, value); }
        }
        public static readonly DependencyProperty FieldFontSizeProperty =
            DependencyProperty.Register("FieldFontSize", typeof(double), typeof(InputField), new PropertyMetadata(18.0, OnPropertyChanged));

        [Description("Sets the field's max character"), Category("Custom InputField")]
        public int FieldMaxLength
        {
            get { return (int)GetValue(FieldMaxLengthProperty); }
            set { SetValue(FieldMaxLengthProperty, value); }
        }
        public static readonly DependencyProperty FieldMaxLengthProperty =
            DependencyProperty.Register("FieldMaxLength", typeof(int), typeof(InputField), new PropertyMetadata(100, OnPropertyChanged));

        [Description("Sets the field's foreground color"), Category("Custom InputField")]
        public Brush FieldForegroundColor
        {
            get { return (Brush)GetValue(FieldForegroundColorProperty); }
            set { SetValue(FieldForegroundColorProperty, value); }
        }
        public static readonly DependencyProperty FieldForegroundColorProperty =
            DependencyProperty.Register("FieldForegroundColor", typeof(Brush), typeof(InputField), new PropertyMetadata(Brushes.Black, OnPropertyChanged));

        [Description("Sets the field's background color"), Category("Custom InputField")]
        public Brush FieldBackgroundColor
        {
            get { return (Brush)GetValue(FieldBackgroundColorProperty); }
            set { SetValue(FieldBackgroundColorProperty, value); }
        }
        public static readonly DependencyProperty FieldBackgroundColorProperty =
            DependencyProperty.Register("FieldBackgroundColor", typeof(Brush), typeof(InputField), new PropertyMetadata(Brushes.Black, OnPropertyChanged));

        [Description("Sets the field's border color"), Category("Custom InputField")]
        public Brush FieldBorderColor
        {
            get { return (Brush)GetValue(FieldBorderColorProperty); }
            set { SetValue(FieldBorderColorProperty, value); }
        }
        public static readonly DependencyProperty FieldBorderColorProperty =
            DependencyProperty.Register("FieldBorderColor", typeof(Brush), typeof(InputField), new PropertyMetadata(Brushes.Gray, OnPropertyChanged));


        [Description("Sets the field's border size"), Category("Custom InputField")]
        public Thickness FieldBorderThickness
        {
            get { return (Thickness)GetValue(FieldBorderThicknessProperty); }
            set { SetValue(FieldBorderThicknessProperty, value); }
        }
        public static readonly DependencyProperty FieldBorderThicknessProperty =
            DependencyProperty.Register(
                "FieldBorderThickness", typeof(Thickness), typeof(InputField), new PropertyMetadata(new Thickness(2, 2, 2, 2), OnPropertyChanged));

        [Description("Sets the field's title name"), Category("Custom InputField")]
        public string FieldName
        {
            get { return (string)GetValue(FieldNameProperty); }
            set { SetValue(FieldNameProperty, value); }
        }
        public static readonly DependencyProperty FieldNameProperty =
            DependencyProperty.Register("FieldName", typeof(string), typeof(InputField), new PropertyMetadata("FieldName", OnPropertyChanged));

        [Description("Sets the field's title name foreground color"), Category("Custom InputField")]
        public Brush FieldNameForegroundColor
        {
            get { return (Brush)GetValue(FieldNameForegroundColorProperty); }
            set { SetValue(FieldNameForegroundColorProperty, value); }
        }
        public static readonly DependencyProperty FieldNameForegroundColorProperty =
            DependencyProperty.Register("FieldNameForegroundColor", typeof(Brush), typeof(InputField), new PropertyMetadata(Brushes.Black, OnPropertyChanged));

        [Description("Sets the tootip's text"), Category("Custom InputField")]
        public string Tooltip
        {
            get { return (string)GetValue(TooltipProperty); }
            set { SetValue(TooltipProperty, value); }
        }
        public static readonly DependencyProperty TooltipProperty =
            DependencyProperty.Register("Tooltip", typeof(string), typeof(InputField), new PropertyMetadata("Tooltip", OnPropertyChanged));

        [Description("Sets the tootip's foreground color"), Category("Custom InputField")]
        public Brush TooltipForegroundColor
        {
            get { return (Brush)GetValue(TooltipForegroundColorProperty); }
            set { SetValue(TooltipForegroundColorProperty, value); }
        }
        public static readonly DependencyProperty TooltipForegroundColorProperty =
            DependencyProperty.Register("TooltipForegroundColor", typeof(Brush), typeof(InputField), new PropertyMetadata(Brushes.Black, OnPropertyChanged));

        [Description("Sets the tooltip to be always visible when the application starts"), Category("Custom InputField")]
        public bool TooltipAlwaysVisible
        {
            get { return (bool)GetValue(TooltipAlwaysVisibleProperty); }
            set { SetValue(TooltipAlwaysVisibleProperty, value); }
        }
        public static readonly DependencyProperty TooltipAlwaysVisibleProperty =
            DependencyProperty.Register("TooltipAlwaysVisible", typeof(bool), typeof(InputField), new PropertyMetadata(false, OnPropertyChanged));


        /**********************************************************************************************************
        * Contructor
        ***********************************************************************************************************/
        public InputField()
        {
            InitializeComponent();
        }

        /**********************************************************************************************************
        * Public Event
        ***********************************************************************************************************/
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public event EventHandler TextChanged;

        /**********************************************************************************************************
        * Property Changed Callback
        ***********************************************************************************************************/
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var userControl = d as InputField;

            switch (e.Property.Name)
            {
                case "Input":

                    string input = (string)e.NewValue;
                    userControl.field.Text = input;

                    break;
                case "Editable":

                    bool isEnabled = (bool)e.NewValue;
                    userControl.field.IsEnabled = isEnabled;

                    break;
                case "FieldFontSize":

                    double fontSize = (double)e.NewValue;
                    userControl.field.FontSize = fontSize;
                    userControl.fieldNameLabel.FontSize = fontSize;

                    break;
                case "FieldMaxLength":

                    int maxLength = (int)e.NewValue;
                    userControl.field.MaxLength = maxLength;

                    break;
                case "FieldForegroundColor":

                    Brush fieldForegroundBrush = (Brush)e.NewValue;
                    userControl.field.Foreground = fieldForegroundBrush;

                    break;
                case "FieldBackgroundColor":

                    Brush fieldBackgroundBrush = (Brush)e.NewValue;
                    userControl.field.Background = fieldBackgroundBrush;

                    break;
                case "FieldBorderColor":

                    Brush fieldBorderColor = (Brush)e.NewValue;
                    userControl.field.BorderBrush = fieldBorderColor;

                    break;
                case "FieldBorderThickness":

                    Thickness thickness = (Thickness)e.NewValue;
                    userControl.field.BorderThickness = thickness;

                    break;
                case "FieldName":

                    string fieldName = (string)e.NewValue;
                    userControl.fieldNameLabel.Content = fieldName;

                    break;
                case "FieldNameForegroundColor":

                    Brush fieldNameForegroundBrush = (Brush)e.NewValue;
                    userControl.fieldNameLabel.Foreground = fieldNameForegroundBrush;

                    break;
                case "Tooltip":

                    string tooltip = (string)e.NewValue;
                    userControl.tooltipLabel.Content = tooltip;

                    break;
                case "TooltipForegroundColor":

                    Brush tooltipForegroundColor = (Brush)e.NewValue;
                    userControl.tooltipLabel.Foreground = tooltipForegroundColor;

                    break;
                case "TooltipFontsize":

                    double tooltipFontSize = (double)e.NewValue;
                    userControl.tooltipLabel.FontSize = tooltipFontSize;

                    break;
                default:
                    break;
            }
        }



        /**********************************************************************************************************
        * Public API
        ***********************************************************************************************************/

        /// <summary>
        /// Border, input text, tooltip and title colors are set to the DefaultErrorHighlightColor.
        /// Displays de predefined tooltip.
        /// </summary>
        public void displayError()
        {
            FieldBorderColor = DefaultErrorHighlightColor;
            FieldNameForegroundColor = DefaultErrorHighlightColor;
            TooltipForegroundColor = DefaultErrorHighlightColor;
            tooltipLabel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Sets the Border, input text, tooltip and title color as the given parameter.
        /// Displays de predefined tooltip.
        /// </summary>
        public void displayError(Brush highlightColor)
        {
            FieldBorderColor = highlightColor;
            FieldNameForegroundColor = highlightColor;
            TooltipForegroundColor = highlightColor;
            tooltipLabel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Border, input text, tooltip and title colors are set to the DefaultErrorHighlightColor.
        /// Set the tooltip message.
        /// </summary>
        /// <param name="errorMessage"></param>
        public void displayError(string errorMessage)
        {
            FieldBorderColor = DefaultErrorHighlightColor;
            FieldNameForegroundColor = DefaultErrorHighlightColor;
            TooltipForegroundColor = DefaultErrorHighlightColor;
            Tooltip = errorMessage;
            tooltipLabel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Sets the Border, input text, tooltip and title color as the given parameter.
        /// Sets the tooltip message.
        /// </summary>
        /// <param name="highlightColor"></param>
        /// <param name="errorMessage"></param>
        public void displayError(string errorMessage, Brush highlightColor)
        {
            FieldBorderColor = highlightColor;
            FieldNameForegroundColor = highlightColor;
            TooltipForegroundColor = highlightColor;
            Tooltip = errorMessage;
            tooltipLabel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Reset ForeColor, BorderColor and Tooltip propertied to their original states.
        /// The original propertied are saved when the UserControl Onload method is called.
        /// Any of those properties changed inside the Design windows will be saved at runtime.
        /// </summary>
        public void removeError()
        {
            FieldBorderColor = resetValues.fieldBorderColor;
            FieldNameForegroundColor = resetValues.fieldNameForegroundColor;
            TooltipForegroundColor = resetValues.tooltipForegroundColor;
            Tooltip = resetValues.tooltip;
            tooltipLabel.Visibility = Visibility.Hidden;
        }



        /**********************************************************************************************************
        * Private Methods
        ***********************************************************************************************************/

        /// <summary>
        /// Save FieldBorderColor, FieldNameForegroundColor, TooltipForegroundColor and Tooltip properties to a struct when the UserControl is loaded.
        /// Used when removeError() is called, restoring those properties to their initial states.
        /// </summary>
        private void saveFactoryValues()
        {
            resetValues.fieldBorderColor = FieldBorderColor;
            resetValues.fieldNameForegroundColor = FieldNameForegroundColor;
            resetValues.tooltipForegroundColor = TooltipForegroundColor;
            resetValues.tooltip = Tooltip;
        }

        /// <summary>
        /// Move fieldNameLabel to the grid's row position 0 (above the field).
        /// Used when we want to focus the field.
        /// </summary>
        private void moveFieldNameUp()
        {
            if (!fieldNameUp)
            {
                fieldNameUp = true;
                FieldNameRowPosition = 0;
                fieldNameLabel.FontSize *= fieldNameUpFontRatio;
            }
        }

        /// <summary>
        /// Move the fieldNameLabel to the grid's row position 1. (inside the field).
        /// Used when we the field is loses focus IF it is empty of when the field is disabled.
        /// </summary>
        private void moveFieldNameDown()
        {
            if (fieldNameUp)
            {
                fieldNameUp = false;
                FieldNameRowPosition = 1;
                fieldNameLabel.FontSize = field.FontSize;
            }
        }

        ///// <summary>
        ///// Basic password placeholder for the field since the TextBox class doesn't have any with the WPF framework
        ///// </summary>
        ///// <param name="e"></param>
        //private void replaceInputTextWithPasswordPlaceholder(TextChangedEventArgs e)
        //{
        //    if(!placeholderInserted) // Block the event callback from the text insertion
        //    {
        //        ICollection<TextChange> textChange = e.Changes;
        //        int addedLength = 0;
        //        int removedLength = 0;
        //        int caretIndex = field.CaretIndex;

        //        foreach (TextChange change in textChange)
        //        {
        //            addedLength += change.AddedLength;
        //            removedLength += change.RemovedLength;
        //        }

        //        if(addedLength != 0 && removedLength != 0) // We had an insertion
        //        {
        //            Input = Input.Remove(caretIndex - 1, removedLength);
        //            Input = Input.Insert(caretIndex -1, field.Text.Substring(caretIndex - 1, addedLength));
        //        }
        //        else if(addedLength > 0) // Appended text
        //        {
        //            Input = Input.Insert(caretIndex -1, field.Text.Substring(caretIndex -1, addedLength));
        //        }
        //        else // Text removed from the end of the string
        //        {
        //            Input = Input.Remove(caretIndex, removedLength);
        //        }

        //        // Block the event callback from the text insertion
        //        placeholderInserted = true;
        //        field.Text = new string('*', field.Text.Length);
        //        placeholderInserted = false;
        //        // Set the caret to it's initial position
        //        field.CaretIndex = caretIndex;
        //    }
        //}


        /**********************************************************************************************************
        * Event Handling
        ***********************************************************************************************************/

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Only hide the tooltip label during runtime, keep it visible during design time
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()) && !TooltipAlwaysVisible)
            {
                tooltipLabel.Visibility = Visibility.Hidden;
            }

            saveFactoryValues();

            if (Editable)
            {
                if (field.Text.Length == 0)
                {
                    moveFieldNameDown();
                }
                else
                {
                    moveFieldNameUp();
                }
            }
        }

        private void field_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Editable)
            {
                moveFieldNameUp();
            }
        }

        private void field_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Editable && field.Text.Length == 0)
            {
                moveFieldNameDown();
            }
        }

        private void field_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Editable)
            {
                moveFieldNameUp();
            }
        }

        private void fieldName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Editable)
            {
                moveFieldNameUp();
                field.Focus();
            }
        }

        private void field_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }
    }
}
