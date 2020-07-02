/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   文件名称 ：NotEmptyValidationRule
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2020/6/17 14:14:38
*   功能描述 ：
*   =================================
*   修 改 者 ：
*   修改日期 ：
*   修改内容 ：
*   ================================= 
***************************************************************************/
using System.Globalization;
using System.Windows.Controls;

namespace TableProcess.Common.Validation
{
	public class NotEmptyValidationRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			return string.IsNullOrWhiteSpace((value ?? "").ToString())
				? new ValidationResult(false, "Field is required.")
				: ValidationResult.ValidResult;
		}
	}
}