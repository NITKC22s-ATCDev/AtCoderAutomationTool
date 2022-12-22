using System.Diagnostics;

namespace AtCoderAutomationTool
{
   internal class Login
   {
      internal static void Acc()
      {
         CommandRunner.Run("acc login");
      }

      internal static void Oj()
      {
         CommandRunner.Run("oj login https://atcoder.jp");
      }

   }
}
