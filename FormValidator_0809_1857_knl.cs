// 代码生成时间: 2025-08-09 18:57:02
using System;

using System.Windows.Controls;

using System.Globalization;



/// <summary>
/// FormValidator class to validate form data and handle errors.
/// </summary>
public class FormValidator : IDataErrorInfo
{
    private readonly string _propertyName;

    /// <summary>
    /// Initializes a new instance of the FormValidator class with a property name.
    /// </summary>
    /// <param name=\