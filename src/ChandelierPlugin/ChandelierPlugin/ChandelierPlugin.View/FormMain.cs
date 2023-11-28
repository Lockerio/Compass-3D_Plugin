namespace ChandelierPlugin.View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using ChandelierPlugin.Model;

    /// <summary>
    /// Главная форма приложения.
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// Экземпляр класса параметров.
        /// </summary>
        private readonly Parameters _parameters = new Parameters();

        /// <summary>
        /// Экземпляр класса строителя.
        /// </summary>
        private readonly Builder _builder = new Builder();

        /// <summary>
        /// Словарь, содержащий элементы управления формы для каждого типа
        /// параметра.
        /// </summary>
        private readonly Dictionary<
            ParameterType,
            Dictionary<string, Control>> _parameterFormElements =
            new Dictionary<ParameterType, Dictionary<string, Control>>();

        /// <summary>
        /// Цвет по умолчанию для элементов формы.
        /// </summary>
        private readonly Color _defaultColor = Color.White;

        /// <summary>
        /// Цвет для обозначения ошибок ввода.
        /// </summary>
        private readonly Color _errorColor =
            Color.FromArgb(255, 192, 192);

        /// <summary>
        /// Инициализирует новый экземпляр класса FormMain.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события загрузки формы.
        /// </summary>
        private void FormMain_Load(object sender, EventArgs e)
        {
            InitializeParameterFormElements();
            SetTextFormElements();
        }

        /// <summary>
        /// Инициализирует элементы управления формы для каждого типа
        /// параметра.
        /// </summary>
        private void InitializeParameterFormElements()
        {
            _parameterFormElements.Add(
                ParameterType.RadiusOuterCircle,
                new Dictionary<string, Control>
            {
                { "textBox", textBox_RadiusOuterCircle },
                { "label", label_RadiusOuterCircle },
            });
            _parameterFormElements.Add(
                ParameterType.RadiusInnerCircle,
                new Dictionary<string, Control>
            {
                { "textBox", textBox_RadiusInnerCircle },
                { "label", label_RadiusInnerCircle },
            });
            _parameterFormElements.Add(
                ParameterType.RadiusBaseCircle,
                new Dictionary<string, Control>
            {
                { "textBox", textBox_RadiusBaseCircle },
                { "label", label_RadiusBaseCircle },
            });
            _parameterFormElements.Add(
                ParameterType.FoundationThickness,
                new Dictionary<string, Control>
            {
                { "textBox", textBox_FoundationThickness },
                { "label", label_FoundationThickness },
            });
            _parameterFormElements.Add(
                ParameterType.LampsAmount,
                new Dictionary<string, Control>
            {
                { "textBox", textBox_LampsAmount },
                { "label", label_LampsAmount },
            });
            _parameterFormElements.Add(
                ParameterType.LampRadius,
                new Dictionary<string, Control>
            {
                { "textBox", textBox_LampRadius },
                { "label", label_LampRadius },
            });

            SetTextFormElements();
        }

        /// <summary>
        /// Обработчик события изменения текста в текстовом поле.
        /// </summary>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string textBoxName = textBox.Name;
                ParameterType parameterType = ParameterType.Unknown;

                string parameterTypeStr =
                    textBoxName.Split('_')[1];

                foreach (var item in _parameterFormElements.Keys)
                {
                    if (item.ToString() == parameterTypeStr)
                    {
                        parameterType = item;
                        break;
                    }
                }

                try
                {
                    _parameters.AssertParameter(
                        parameterType,
                        _parameters.ParametersDict[parameterType],
                        Convert.ToDouble(textBox.Text));
                    SetTextFormElements();
                    _parameterFormElements[parameterType]["textBox"].
                        BackColor = _defaultColor;
                    buttonBuild.Enabled = true;
                }
                catch (Exception ex)
                {
                    Parameter _parameter =
                        _parameters.ParametersDict[parameterType];
                    var _minValue = _parameter.MinValue;
                    var _maxValue = _parameter.MaxValue;
                    var message =
                        ex.Message + "\nВведите число от "
                                   + $"{_minValue} до {_maxValue}";
                    _parameterFormElements[parameterType]["label"].
                        Text = message;
                    _parameterFormElements[parameterType]["textBox"].
                        BackColor = _errorColor;
                    buttonBuild.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Устанавливает текст и значения элементов управления формы на
        /// основе текущих параметров.
        /// </summary>
        private void SetTextFormElements()
        {
            foreach (var item
                in _parameters.ParametersDict)
            {
                var _key = item.Key;
                var _value = item.Value;

                _parameterFormElements[_key]["textBox"].Text =
                    _value.CurrentValue.ToString();
                _parameterFormElements[_key]["label"].Text =
                    $"от {_value.MinValue} до {_value.MaxValue}";
            }
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Построить".
        /// </summary>
        private void buttonBuild_Click(object sender, EventArgs e)
        {
            _builder.BuildDetail(_parameters);
        }
    }
}