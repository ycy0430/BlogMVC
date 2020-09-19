using System.Text.RegularExpressions;

namespace rui
{
    /// <summary>
    /// 正则表达式检查数据合法性
    /// </summary>
    public class dataCheck
    {
        /// <summary>
        /// 检查身份证是否合法
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isThrow">是否抛出异常</param>
        /// <returns></returns>
        public static bool check身份证(string value,bool isThrow=false)
        {
            Regex regex = new Regex(@"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");
            bool result = regex.IsMatch(value);
            if (result == false && isThrow == true)
                rui.excptHelper.throwEx("身份证不合法");
            return result;
        }

        /// <summary>
        /// 检查手机号是否合法
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isThrow">是否抛出异常</param>
        /// <returns></returns>
        public static bool check手机号(string value,bool isThrow=false)
        {
            Regex regex = new Regex(@"^[1]([1-9])[0-9]{9}$");
            bool result = regex.IsMatch(value);
            if (result == false && isThrow == true)
                rui.excptHelper.throwEx("手机号不合法");
            return result;
        }


        /// <summary>
        /// 检查变量值是否等于某个值，等于则抛出异常
        /// </summary>
        /// <param name="boolExpr">布尔表达式</param>
        /// <param name="errorMsg">成立时抛出的错误提醒</param>
        public static void checkExpr(bool boolExpr, string errorMsg)
        {
            if (boolExpr == true)
                rui.excptHelper.throwEx(errorMsg);
        }
    }
}
